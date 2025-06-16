using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Npgsql;

namespace Apteka.ViewModel.MedicineVM
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
				MedicineProductWrapper.ToList(_general.MedicineProducts));

			if (dgv.Columns.Contains("IdMedicineProduct"))
				dgv.Columns["IdMedicineProduct"].Visible =
				dgv.Columns["IdMedicine"].Visible = false;
		}

		/// <summary>
		/// Привязка данных к источнику данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDataSourceMedicineProduct(DataGridView dgv, List<MedicineProduct> mp)
		{
			dgv.DataSource = new SortableBindingList<MedicineProductWrapper>(
				MedicineProductWrapper.ToList(mp));
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
		/// Настраивает таблицу под вывод данных
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGV<T>(DataGridView dgv)
		{
			_general.SetDefaultSettingsToDGV(dgv);
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			_general.ConfigureGrid<T>(dgv);
		}

		/// <summary>
		/// Поиск ЛП
		/// </summary>
		/// <param name="mp"></param>
		/// <param name="strParams">Обязательны следующие параметры: TextSearch, PharmGroup, ConditionRelease,
		/// Component, ComponentMeasure</param>
		/// <param name="doParams">Обязательны следующие параметры: DateReleaseMin, 
		/// DateReleaseMax, DateExpirationMin, DateExpirationMax</param>
		/// <param name="decommissioned"></param>
		/// <param name="expired"></param>
		/// <returns></returns>
		internal async Task<List<MedicineProduct>?> SearchMedicineProductAsync(MedicineProduct mp, string[] strParams,
			DateOnly?[] doParams, string decommissioned, string expired, bool isExtendedSearch)
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
						strParams[0], mp.IdMedicine, mp.SerialNumber, mp.Form, -1.0, -1.0,
					mp.WayEnter, mp.PackagingForm, mp.Producer,
					doParams[0], doParams[1], doParams[2], doParams[3],
					decommissioned == "" ? null : decommissioned == "Да",
					expired == "" ? null : expired == "Да",
					strParams[1], mp.StorageCondition, strParams[2], strParams[3], strParams[4])
					.AsNoTracking()
					.ToListAsync();
				}
				else
				{
					results = await _general.AptekaContext.MedicineProducts
					.FromSqlRaw("SELECT * FROM search_medicine_products_trgm({0}, {1});",
						strParams[0], mp.IdMedicine)
					.AsNoTracking()
					.ToListAsync();
				}

				return results;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск ЛП",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		internal bool UpsertMedicineProduct(MedicineProduct mp)
		{
			try
			{
				MedicineProduct? oldMp = General.AptekaContext.MedicineProducts
					.Where(oMp => oMp.IdMedicineProduct == mp.IdMedicineProduct)
					.FirstOrDefault();

				if (oldMp == null) General.AptekaContext.MedicineProducts.Add(mp);
				else General.AptekaContext.MedicineProducts.Entry(oldMp).CurrentValues.SetValues(mp);

				General.AptekaContext.SaveChanges();

				mp.Name = General.AptekaContext.MedicineProducts
					.Where(nmp => nmp.SerialNumber == mp.SerialNumber)
					.Select(nmp => nmp.Name).First();

				return true;
			}
			catch (DbUpdateException ex)
			{
				string message = ex.InnerException?.Message ?? "";

				if (message.Contains("empty"))
					message = "Ошибка! Пустые поля, пожалуйста, заполните все поля!";
				else if (message.Contains("wrong_date_expiration"))
					message = "Ошибка! Срок годности не может быть раньше срока изготовления!";
				else if (message.Contains("serial_number"))
					message = "Ошибка! Серийный номер уже существует!";

				MessageBox.Show(message, "Ошибка данных",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			catch (NpgsqlException ex)
			{
				MessageBox.Show(ex.Message, "Ошибка данных",
			MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		internal bool DeleteMedicineProduct(Guid id)
		{
			try
			{
				_general.AptekaContext.Database
							.ExecuteSqlRaw("CALL delete_medicine_product({0}::uuid)", id);
				return true;
			}
			catch (PostgresException ex)
			{
				string message = ex.Message;

				MessageBox.Show(message, "Ошибка удаления",
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
			List<MedicineProduct>? analogues = _general.MedicineProducts
				.Where(mp => mp.Analogues?.Contains(idMedicineProduct) ?? false)
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
