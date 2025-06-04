using Apteka.Model;
using Npgsql;

namespace Apteka.ViewModel.ProductsLogisticVM
{
	internal class WaybillDataViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public WaybillDataViewModel()
		{
			_general = GeneralViewModel.Instance;
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

		internal bool InsertWaybill(Waybill w)
		{
			try
			{
				General.AptekaContext.Waybills.Add(w);
				General.AptekaContext.SaveChanges();
				return true;
			}
			catch (PostgresException ex)
			{
				string message = ex.Message;

				string constraintName = ex.ConstraintName ?? "";
				if (constraintName.Contains("wrong_date_waybill"))
					message = "Ошибка! Дата накладной не должна быть позже сегодняшней даты!";

				MessageBox.Show(message, "Ошибка данных",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		internal bool InsertWaybillMedicineProduct(List<WaybillMedicineProduct> lwmp)
		{
			try
			{
				General.AptekaContext.WaybillMedicineProducts.AddRange(lwmp);
				General.AptekaContext.SaveChanges();
				return true;
			}
			catch (PostgresException ex)
			{
				string message = ex.Message;

				MessageBox.Show(message, "Ошибка данных",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		internal List<WaybillMedicineProduct> GetMeasure(Guid? idMedicineProduct = null)
		{
			if (idMedicineProduct == null)
				return _general.WaybillsMedicineProduct;
			else
				return _general.WaybillsMedicineProduct
				.Where(wmp => wmp.IdMedicineProduct == idMedicineProduct)
				.ToList();
		}

		internal List<Supplier> GetSupplier(int? idSupplier = null)
		{
			if (idSupplier == null)
				return _general.Suppliers;
			else
				return _general.Suppliers
				.Where(s => s.IdSupplier == idSupplier)
				.ToList();
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
	}
}
