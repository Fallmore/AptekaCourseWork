using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Apteka.ViewModel.MedicineVM
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

			if (dgv.Columns.Contains("IdMedicineProduct"))
				dgv.Columns["IdMedicineProduct"].Visible = false;
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
		internal async Task<List<MedicineProductDecommissioned>?> SearchMedicineProductDecommissionedAsync(
			Guid idMedicineProduct, string reason, DateTime[] dtParams)
		{
			try
			{
				// Преобразуем даты в UTC
				dtParams[0] = DateTime.SpecifyKind(dtParams[0], DateTimeKind.Utc);
				dtParams[1] = DateTime.SpecifyKind(dtParams[1], DateTimeKind.Utc);

				List<MedicineProductDecommissioned> results = await _general.AptekaContext.MedicineProductDecommissioneds
					.FromSqlRaw("SELECT * FROM search_medicine_product_decommissioned_trgm({0}, {1}, {2}, " +
					"{3}::timestamp, {4}::timestamp);", idMedicineProduct, reason,
						"", dtParams[0], dtParams[1])
					.AsNoTracking()
					.ToListAsync();

				return results;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск списанных ЛП",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
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
	}
}
