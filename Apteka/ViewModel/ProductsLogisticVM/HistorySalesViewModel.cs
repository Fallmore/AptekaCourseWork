using Apteka.Model;
using Apteka.ViewModel.EmployeeVM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Apteka.ViewModel.ProductsLogisticVM
{
	internal class HistorySalesViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public HistorySalesViewModel()
		{
			_general = GeneralViewModel.Instance;
		}

		/// <summary>
		/// Привязка данных продаж к источникам данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDefaultDataSource<T>(DataGridView dgv) where T : class
		{
			switch (typeof(T).Name)
			{
				case "HistorySaleWrapper":
					List<HistorySaleWrapper> list =	HistorySaleWrapper.ToList(_general.HistorySales, this);

					if (_general.ChoosedRole != (int)Roles.Директор)
						list = list
							.Where(l => l.IdDepartment == EmployeeAccountViewModel.GetCurrentDepartment())
							.ToList();

					dgv.DataSource = new SortableBindingList<HistorySaleWrapper>(list);

					if (dgv.Columns.Contains("IdDepartment"))
						dgv.Columns["IdDepartment"].Visible =
						dgv.Columns["IdEmployee"].Visible =
						dgv.Columns["IdSale"].Visible = false;
					break;
				case "HistorySaleMedicineProductWrapper":
					dgv.DataSource = new SortableBindingList<HistorySaleMedicineProductWrapper>(
						HistorySaleMedicineProductWrapper.ToList(_general.HistorySalesMedicineProduct, this));
					if (dgv.Columns.Contains("IdMedicineProduct"))
						dgv.Columns["IdMedicineProduct"].Visible =
						dgv.Columns["IdStorage"].Visible =
						dgv.Columns["IdPlace"].Visible =
						dgv.Columns["IdSale"].Visible = false;
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Настраивает таблицу под вывод данных продаж
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGV<T>(DataGridView dgv)
		{
			_general.SetDefaultSettingsToDGV(dgv);
			_general.ConfigureGrid<T>(dgv);
		}

		/// <summary>
		/// Поиск продаж
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="intParams">Обязательны следующие параметры: IdDepartment, IdStorage, IdPlace</param>
		/// <param name="dtParams">Обязательны следующие параметры: DateSaleMin, DateSaleMax</param>
		/// <param name="guidParams">Обязательны следующие параметры: IdMedicineProduct, IdEmployee</param>
		/// <returns></returns>
		internal async Task<List<HistorySale>?> SearchSalesAsync(int[] intParams, DateTime[] dtParams, Guid[] guidParams)
		{
			try
			{
				// Преобразуем даты в UTC
				dtParams[0] = DateTime.SpecifyKind(dtParams[0], DateTimeKind.Utc);
				dtParams[1] = DateTime.SpecifyKind(dtParams[1], DateTimeKind.Utc);

				List<HistorySale> results = await _general.AptekaContext.HistorySales
					.FromSqlRaw("SELECT * FROM search_sale({0}, {1}, {2}, {3}, {4}," +
					"{5}::timestamp, {6}::timestamp, {7});", intParams[0], intParams[1], intParams[2],
						guidParams[0] == new Guid() ? null : guidParams[0],
						"", dtParams[0], dtParams[1],
						guidParams[1] == new Guid() ? null : guidParams[1])
					.AsNoTracking()
					.ToListAsync();

				return results;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск продаж",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		internal DateTime[] GetMinMaxDatesSales()
		{
			List<HistorySale> sales = _general.HistorySales;
			DateTime[] results = [];

			if (sales.Count != 0)
				results =
				[
					sales.Min(s => s.DateSale),
					sales.Max(s => s.DateSale),
				];

			return results;
		}

		internal List<StoragePharmacy> GetStoragePharmacy(int? idStorage = null)
		{
			if (idStorage == null)
				return _general.StoragePharmacies;
			else
				return _general.StoragePharmacies
					.Where(sp => sp.IdStorage == idStorage)
					.ToList();
		}

		internal List<StoragePlace> GetStoragePlace(int? idPlace = null)
		{
			if (idPlace == null)
				return _general.StoragePlaces;
			else
				return _general.StoragePlaces
				.Where(sp => sp.IdPlace == idPlace)
				.ToList();
		}

		internal List<MedicineProduct> GetMedicineProduct(Guid? idMedicineProduct = null)
		{
			if (idMedicineProduct == null)
				return _general.MedicineProducts;
			else
				return _general.MedicineProducts
				.Where(mp => mp.IdMedicineProduct == idMedicineProduct)
				.ToList();
		}

		internal List<Department> GetDepartment(int? idDepartment = null)
		{
			if (idDepartment == null)
				return _general.Departments;
			else
				return _general.Departments
				.Where(d => d.IdDepartment == idDepartment)
				.ToList();
		}

		internal List<Employee> GetEmployee(Guid? idEmployee = null)
		{
			if (idEmployee == null)
				return _general.Employees;
			else
				return _general.Employees
				.Where(d => d.IdEmployee == idEmployee)
				.ToList();
		}
	}
}
