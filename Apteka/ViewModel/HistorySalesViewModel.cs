using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Apteka.ViewModel
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
		/// Привязка данных склада к источникам данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDefaultDataSource(DataGridView dgv)
		{
			dgv.DataSource = new SortableBindingList<HistorySaleWrapper>(
				HistorySaleWrapper.ToHistorySaleWrapper(_general.HistorySales, this));
		}

		/// <summary>
		/// Обновляет данные склада таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void RefreshHistorySales(DataGridView dgv)
		{
			_general.LoadTableForWrite<HistorySale>();
			SetDefaultDataSource(dgv);
		}

		/// <summary>
		/// Настраивает таблицу под вывод данных склада
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGV(DataGridView dgv)
		{
			_general.SetDefaultSettingsToDGV(dgv);
			_general.ConfigureGrid<HistorySaleWrapper>(dgv);
		}

		/// <summary>
		/// Поиск продаж
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="intParams">Обязательны следующие параметры: IdDepartment, IdStorage, IdPlace</param>
		/// <param name="dtParams">Обязательны следующие параметры: DateSaleMin, DateSaleMax</param>
		/// <param name="guidParams">Обязательны следующие параметры: IdMedicineProduct, IdEmployee</param>
		/// <returns></returns>
		internal async Task<bool> SearchSalesAsync(DataGridView dgv, int[] intParams, DateTime[] dtParams, Guid[] guidParams)
		{
			try
			{
				// Преобразуем даты в UTC
				dtParams[0] = DateTime.SpecifyKind(dtParams[0], DateTimeKind.Utc);
				dtParams[1] = DateTime.SpecifyKind(dtParams[1], DateTimeKind.Utc);

				List<HistorySale> results = await _general.AptekaContext.HistorySales
					.FromSqlRaw("SELECT * FROM search_sale({0}, {1}, {2}, {3}, {4}," +
					"{5}::timestamp, {6}::timestamp, {7});", intParams[0], intParams[1], intParams[2],
						(guidParams[0] == new Guid() ? null : guidParams[0]),
						"", dtParams[0], dtParams[1],
						(guidParams[1] == new Guid() ? null : guidParams[1]))
					.AsNoTracking()
					.ToListAsync();

				if (results.Count != 0)
				{
					dgv.DataSource = new SortableBindingList<HistorySaleWrapper>(
						HistorySaleWrapper.ToHistorySaleWrapper(results, this));
					return true;
				}
				else
				{
					MessageBox.Show("Ничего не найдено", "Поиск продаж",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск продаж",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		internal DateTime[] GetMinMaxDatesDecommission()
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
