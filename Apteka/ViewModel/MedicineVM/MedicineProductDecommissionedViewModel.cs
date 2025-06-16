using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Npgsql;
using NpgsqlTypes;

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
				List<MedicineProductDecommissioned> results = await _general.AptekaContext.MedicineProductDecommissioneds
					.FromSqlRaw("SELECT * FROM search_medicine_product_decommissioned_trgm({0}, {1}, {2}, " +
					"{3}, {4});", 
						idMedicineProduct == new Guid() ? null : idMedicineProduct, 
						reason, "", 
						new NpgsqlParameter("p3", NpgsqlDbType.Timestamp) { Value = dtParams[0] },
						new NpgsqlParameter("p4", NpgsqlDbType.Timestamp) { Value = dtParams[1] })
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
