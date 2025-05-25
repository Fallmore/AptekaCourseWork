using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Apteka.ViewModel
{
	internal class MedicineProductDecommissionedViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public MedicineProductDecommissionedViewModel()
		{
			_general = GeneralViewModel.Instance;
		}

		/// <summary>
		/// Привязка данных склада к источникам данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDefaultDataSource(DataGridView dgv)
		{
			dgv.DataSource = new SortableBindingList<MedicineProductDecommissionedWrapper>(
				MedicineProductDecommissionedWrapper.ToMedicineProductDecommissionedWrapper(
					_general.MedicineProductDecommissioneds, this));
		}

		/// <summary>
		/// Обновляет данные склада таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void RefreshMedicineProductDecommissioned(DataGridView dgv)
		{
			_general.LoadTableForWrite<MedicineProductDecommissioned>();
			SetDefaultDataSource(dgv);
		}

		/// <summary>
		/// Настраивает таблицу под вывод данных склада
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGV(DataGridView dgv)
		{
			_general.SetDefaultSettingsToDGV(dgv);
			_general.ConfigureGrid<MedicineProductDecommissionedWrapper>(dgv);
		}

		/// <summary>
		/// Поиск списанных ЛП
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="idDepartment"></param>
		/// <param name="idMedicineProduct"></param>
		/// <param name="reason"></param>
		/// <param name="dtParams"></param>
		/// <returns></returns>
		internal async Task<bool> SearchMedicineProductDecommissionedAsync(DataGridView dgv, int idDepartment,
			Guid idMedicineProduct, string reason, DateTime[] dtParams)
		{
			try
			{
				// Преобразуем даты в UTC
				dtParams[0] = DateTime.SpecifyKind(dtParams[0], DateTimeKind.Utc);
				dtParams[1] = DateTime.SpecifyKind(dtParams[1], DateTimeKind.Utc);

				List<MedicineProductDecommissioned> results = await _general.AptekaContext.MedicineProductDecommissioneds
					.FromSqlRaw("SELECT * FROM search_medicine_product_decommissioned_trgm({0}, {1}, {2}, {3}, " +
					"{4}::timestamp, {5}::timestamp);", idDepartment, idMedicineProduct, reason,
						"", dtParams[0], dtParams[1])
					.AsNoTracking()
					.ToListAsync();

				if (results.Count != 0)
				{
					dgv.DataSource = new SortableBindingList<MedicineProductDecommissionedWrapper>(
						MedicineProductDecommissionedWrapper.ToMedicineProductDecommissionedWrapper(results, this));
					return true;
				}
				else
				{
					MessageBox.Show("Списанные ЛП найдены", "Поиск списанных ЛП",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск списанных ЛП",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		internal DateTime[] GetMinMaxDatesDecommission()
		{
			List<MedicineProductDecommissioned> mpd = _general.MedicineProductDecommissioneds;
			DateTime[] results = [];

			if (mpd.Count != 0)
				results =
				[
					mpd.Min(s => s.DateDecommission),
					mpd.Max(s => s.DateDecommission),
				];

			return results;
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
	}
}
