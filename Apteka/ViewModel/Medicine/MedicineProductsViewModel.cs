using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Apteka.ViewModel
{
	internal class MedicineProductsViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public MedicineProductsViewModel()
		{
			_general = GeneralViewModel.Instance;
		}

		/// <summary>
		/// Привязка ЛП к источникам данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDefaultDataSourceMedicineProduct(DataGridView dgv)
		{
			dgv.DataSource = new SortableBindingList<MedicineProductWrapper>(
				MedicineProductWrapper.ToMedicineProductWrapper(_general.MedicineProducts));
		}

		/// <summary>
		/// Привязка данных к источнику данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDataSourceMedicineProduct(DataGridView dgv, List<MedicineProduct> mp)
		{
			dgv.DataSource = new SortableBindingList<MedicineProductWrapper>(
				MedicineProductWrapper.ToMedicineProductWrapper(mp));
		}

		/// <summary>
		/// Привязка цен ЛП к источникам данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDefaultDataSourceMedicineProductCost(DataGridView dgv)
		{
			dgv.DataSource = new SortableBindingList<MedicineCost>([new MedicineCost()]);
		}

		/// <summary>
		/// Настраивает таблицу под вывод ЛП
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGVMedicineProduct(DataGridView dgv)
		{
			_general.SetDefaultSettingsToDGV(dgv);
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			_general.ConfigureGrid<MedicineProductWrapper>(dgv);
		}

		/// <summary>
		/// Настраивает таблицу под вывод цен ЛП
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGVMedicineProductCost(DataGridView dgv)
		{
			_general.SetDefaultSettingsToDGV(dgv);
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			_general.ConfigureGrid<MedicineCost>(dgv);
		}

		/// <summary>
		/// Поиск ЛП и привязка данных к таблице
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="idMedicine"></param>
		/// <param name="strParams">Обязательны следующие параметры: SearchText, SerialNumber,
		/// MedicineForm, WayEnter, PackagingForm, Producer, PharmGroup, StorageCondition, ConditionRelease,
		/// Component, ComponentMeasure</param>
		/// <param name="doParams">Обязательны следующие параметры: DateReleaseMin, 
		/// DateReleaseMax, DateExpirationMin, DateExpirationMax</param>
		/// <param name="decommissioned"></param>
		/// <param name="expired"></param>
		/// <returns></returns>
		internal async Task<bool> SearchMedicineProductAsync(
			DataGridView dgv, int idMedicine, string[] strParams, DateOnly[] doParams,
			string decommissioned, string expired, bool isExtendedSearch)
		{
			try
			{
				List<MedicineProduct> results;

				if (isExtendedSearch)
				{
					results = await _general.AptekaContext.MedicineProducts
					.FromSqlRaw("SELECT * FROM search_medicine_products_trgm(" +
						"{0}, {1}, {2}, {3}, {4}::real, {5}::real, {6}, {7}, {8}, {9}, {10}, {11}, " +
						"{12}, {13}, {14}, {15}, {16}, {17}, {18});",
						strParams[0], idMedicine, strParams[1], strParams[2], -1.0, -1.0,
					strParams[3], strParams[4], strParams[5],
					doParams[0], doParams[1], doParams[2], doParams[3],
					decommissioned == "" ? null : decommissioned == "Да",
					expired == "" ? null : expired == "Да",
					strParams[6], strParams[7], strParams[8], strParams[9], strParams[10])
					.AsNoTracking()
					.ToListAsync();
				}
				else
				{
					results = await _general.AptekaContext.MedicineProducts
					.FromSqlRaw("SELECT * FROM search_medicine_products_trgm({0}, {1});",
						strParams[0], idMedicine)
					.AsNoTracking()
					.ToListAsync();
				}

				if (results.Count != 0)
				{
					dgv.DataSource = new SortableBindingList<MedicineProductWrapper>(
						MedicineProductWrapper.ToMedicineProductWrapper(results));
					return true;
				}
				else
				{
					MessageBox.Show("ЛП не найдено", "Поиск ЛП",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск ЛП",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		internal DateOnly[] GetMinMaxDatesMedicineProducts()
		{
			List<MedicineProduct> products = _general.MedicineProducts;
			DateOnly[] results = [];

			if (products.Count != 0)
				results =
				[
					products.Min(p => p.DateRelease),
					products.Max(p => p.DateRelease),
					products.Min(p => p.DateExpiration),
					products.Max(p => p.DateExpiration)
				];

			return results;
		}

		internal List<MedicineProduct> GetMedicineProductAnalogues(Guid idMedicineProduct)
		{
			List<int>? idMedicines = _general.MedicineProducts
				.First(mp => mp.IdMedicineProduct == idMedicineProduct).Analogues;
			List<MedicineProduct> analogues = [];

			if (idMedicines != null)
				analogues = _general.MedicineProducts
				.Where(mp => idMedicines.Contains(mp.IdMedicine) 
					&& mp.IdMedicineProduct != idMedicineProduct)
				.ToList();

			return analogues;
		}

		internal List<MedicineForm> GetMedicineForms()
		{
			return General.MedicineForms;
		}

		internal List<MedicineWayEnter> GetWayEnters()
		{
			return General.MedicineWayEnters;
		}

		internal List<MedicinePackagingForm> GetPackagingForms()
		{
			return General.MedicinePackagingForms;
		}

		internal List<MedicineProducer> GetProducers()
		{
			return General.MedicineProducers;
		}

		internal void Decommission(Guid idMedicineProduct, string reason)
		{
			General.AptekaContext.Database
				.ExecuteSqlRaw(@"CALL decommission_medicine_product({0}, {1})",
				idMedicineProduct, reason);
		}

		internal void UpdateMedicineCost(int idMedicine, string oldPackagingForm, string newPackagingForm, float cost)
		{
			General.AptekaContext.Database
				.ExecuteSqlRaw("UPDATE medicine_cost " +
				"SET packaging_form = {2}, cost = {3} " +
				"WHERE id_medicine = {0} AND packaging_form = {1}",
				idMedicine, oldPackagingForm, newPackagingForm, cost);
		}

		internal void InsertMedicineCost(int idMedicine, string packagingForm, float cost)
		{
			General.AptekaContext.Database
				.ExecuteSqlRaw("INSERT INTO medicine_cost (id_medicine, packaging_form, cost) " +
				"VALUES ({0}, {1}, {2})",
				idMedicine, packagingForm, cost);
		}
	}
}
