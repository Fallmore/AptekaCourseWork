using Apteka.Model;
using Apteka.ViewModel.EmployeeVM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Apteka.ViewModel.ProductsLogisticVM
{
	internal class WaybillViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public WaybillViewModel()
		{
			_general = GeneralViewModel.Instance;
		}

		/// <summary>
		/// Привязка данных накладных к источникам данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDefaultDataSource<T>(DataGridView dgv) where T : class
		{
			switch (typeof(T).Name)
			{
				case "WaybillWrapper":
					List<WaybillWrapper> list = WaybillWrapper.ToList(_general.Waybills, this);

					if (_general.ChoosedRole != (int)Roles.Директор)
						list = list
							.Where(l => l.IdDepartment == EmployeeAccountViewModel.GetCurrentDepartment())
							.ToList();

					dgv.DataSource = new SortableBindingList<WaybillWrapper>(list);

					if (dgv.Columns.Contains("IdMedicineProduct"))
						dgv.Columns["IdMedicineProduct"].Visible =
						dgv.Columns["IdDepartment"].Visible =
						dgv.Columns["IdSupplier"].Visible =
						dgv.Columns["IdEmployee"].Visible = false;

					break;
				case "WaybillMedicineProductWrapper":
					dgv.DataSource = new SortableBindingList<WaybillMedicineProductWrapper>(
						WaybillMedicineProductWrapper.ToList(_general.WaybillsMedicineProduct, this));
					if (dgv.Columns.Contains("IdMedicineProduct"))
						dgv.Columns["IdMedicineProduct"].Visible =
						dgv.Columns["IdWaybill"].Visible = false;
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Настраивает таблицу под вывод данных накладных
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGV<T>(DataGridView dgv)
		{
			_general.SetDefaultSettingsToDGV(dgv);
			_general.ConfigureGrid<T>(dgv);
		}

		/// <summary>
		/// Поиск накладных
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="w"></param>
		/// <param name="doParams">Обязательны следующие параметры: DateWaybillMin, DateWaybillMax</param>
		/// <returns></returns>
		internal async Task<List<Waybill>?> SearchWaybillAsync(Waybill w, Guid idMedicineProduct,
			DateOnly[] doParams)
		{
			try
			{
				List<Waybill> results = await _general.AptekaContext.Waybills
					.FromSqlRaw("SELECT * FROM search_waybill({0}, {1}, {2}, {3}, {4}," +
					"{5}, {6});", w.IdWaybill,
					w.IdEmployee == new Guid() ? null : w.IdEmployee,
					idMedicineProduct == new Guid() ? null : idMedicineProduct,
					w.IdSupplier, w.IdDepartment, doParams[0], doParams[1])
					.ToListAsync();

				return results;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск накладной",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		internal DateOnly[] GetMinMaxDatesWaybill()
		{
			List<Waybill> waybills = _general.Waybills;
			DateOnly[] results = [];

			if (waybills.Count != 0)
				results =
				[
					waybills.Min(e => e.DateWaybill),
					waybills.Max(e => e.DateWaybill),
				];

			return results;
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

		internal List<Post> GetPost(int? idPost = null)
		{
			if (idPost == null)
				return _general.Posts;
			else
				return _general.Posts
				.Where(p => p.IdPost == idPost)
				.ToList();
		}

		internal List<Supplier> GetSupplier(int? idSupplier = null)
		{
			if (idSupplier == null)
				return _general.Suppliers;
			else
				return _general.Suppliers
				.Where(p => p.IdSupplier == idSupplier)
				.ToList();
		}

		internal List<Employee> GetEmployee(Guid? idEmployee = null)
		{
			if (idEmployee == null)
				return _general.Employees;
			else
				return _general.Employees
				.Where(e => e.IdEmployee == idEmployee)
				.ToList();
		}

		internal List<MedicineProduct> GetMedicineProduct(Guid? idMedicineProduct = null)
		{
			if (idMedicineProduct == null)
				return _general.MedicineProducts;
			else
				return _general.MedicineProducts
				.Where(p => p.IdMedicineProduct == idMedicineProduct)
				.ToList();
		}
	}
}
