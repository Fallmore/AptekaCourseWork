using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Apteka.ViewModel
{
	internal class MedicinesViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public MedicinesViewModel()
		{
			_general = GeneralViewModel.Instance;
		}

		/// <summary>
		/// Привязка лекарств к источникам данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDefaultDataSource(DataGridView dgv)
		{
			dgv.DataSource = new SortableBindingList<Medicine>(General.Medicines);
		}

		/// <summary>
		/// Обновляет данные лекарств таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void RefreshMedicines(DataGridView dgv)
		{
			SetDefaultDataSource(dgv);
		}

		/// <summary>
		/// Настраивает таблицу под вывод лекарств
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGV(DataGridView dgv)
		{
			General.SetDefaultSettingsToDGV(dgv);
			General.ConfigureGrid<Medicine>(dgv);
		}

		/// <summary>
		/// Поиск лекарства и привязка данных к таблице
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="name"></param>
		/// <param name="mnn"></param>
		/// <param name="pharmGroup"></param>
		/// <param name="conditionRelease"></param>
		internal async Task<bool> SearchMedicineAsync(
			DataGridView dgv, string name, string mnn, string pharmGroup, string conditionRelease, int idMedicine)
		{
			try
			{
				List<Medicine> results;

				if (idMedicine == -1)
				{
					results = await General.AptekaContext.Medicines
					.FromSqlRaw("SELECT * FROM search_medicine_trgm(" +
						"_name => {0}," +
						"_mnn => {1}," +
						"_pharm_group => {2}," +
						"_condition_release => {3});", name, mnn, pharmGroup, conditionRelease)
					.AsNoTracking()
					.ToListAsync();
				}
				else
				{
					results = await General.AptekaContext.Medicines
					.Where(m => m.IdMedicine == idMedicine)
					.AsNoTracking()
					.ToListAsync();
				}

				if (results.Count != 0)
				{
					dgv.DataSource = new SortableBindingList<Medicine>(results);
					return true;
				}
				else
				{
					MessageBox.Show("Лекарство не найдено", "Поиск лекарства",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск лекарства",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

	}
}
