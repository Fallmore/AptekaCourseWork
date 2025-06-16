using Apteka.Model;
using Apteka.ViewModel.MedicineVM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Npgsql;

namespace Apteka.ViewModel.MenuVM
{
	internal class КассаViewModel
	{
		private readonly GeneralViewModel _general;
		private readonly MedicineProductsViewModel _viewModelMP;

		internal GeneralViewModel General => _general;

		public КассаViewModel()
		{
			_general = GeneralViewModel.Instance;
			_viewModelMP = new();
		}

		/// <summary>
		/// Настраивает таблицу под вывод данных
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGV<T>(DataGridView dgv)
		{
			_general.SetDefaultSettingsToDGV(dgv);
			_general.ConfigureGrid<T>(dgv);
		}

		internal List<StorageMedicineProduct> FilterCurrentDepartment(List<StorageMedicineProduct> list)
		{
			return list.Where(l => l.IdDepartment == _general.ChoosedRole)
				.ToList();
		}

		internal List<Guid> FilterForSale(List<MedicineProduct> list)
		{
			return list.Where(mp => mp.Decommissioned == false
						&& !_general.MedicineProductsExpired.Contains(mp.IdMedicineProduct))
					.Select(mp => mp.IdMedicineProduct)
					.ToList();
		}

		internal List<StorageMedicineProduct> GetStorageMedicineProductsForSale(Guid? id = null)
		{
			List<Guid> lg = FilterForSale(_general.MedicineProducts);

			List<StorageMedicineProduct> lsmp = _general.StorageMedicineProducts
				.Where(smp => lg.Contains(smp.IdMedicineProduct))
				.ToList();

			if (id != null)
				lsmp = lsmp.Where(mp => mp.IdMedicineProduct == id).ToList();

			return FilterCurrentDepartment(lsmp);
		}

		internal async Task<List<StorageMedicineProduct>?> SearchStorageMedicineProductsForSale(string textSearch)
		{
			MedicineProduct mp = new()
			{
				Form = "",
				PackagingForm = "",
				Producer = "",
				SerialNumber = "",
				StorageCondition = "",
				WayEnter = ""
			};

			List<MedicineProduct>? results = await _viewModelMP.SearchMedicineProductAsync(mp, [
				textSearch,"","","",""], [null, null, null, null], "Нет", "Нет", true);

			if (results == null) return null;

			List<Guid> lg = FilterForSale(results);

			List<StorageMedicineProduct> lsmp = _general.StorageMedicineProducts
				.Where(smp => lg.Contains(smp.IdMedicineProduct))
				.ToList();

			return FilterCurrentDepartment(lsmp);
		}

		internal List<StorageMedicineProduct> GetStorageMedicineProductsAnaloguesForSale(Guid id)
		{
			List<Guid> lg = FilterForSale(_general.AptekaContext.MedicineProducts
				.FromSqlRaw("SELECT * FROM get_medicine_products_analogues({0})", id)
				.AsEnumerable().ToList());
			List<StorageMedicineProduct> lsmp = _general.StorageMedicineProducts
				.Where(smp => lg.Contains(smp.IdMedicineProduct))
				.ToList();
			return FilterCurrentDepartment(lsmp);
		}

		internal async Task<List<StorageMedicineProduct>?> SearchAnaloguesMedicineProductsForSale(Guid id, string textSearch)
		{
			MedicineProduct mp = new()
			{
				Form = "",
				PackagingForm = "",
				Producer = "",
				SerialNumber = "",
				StorageCondition = "",
				WayEnter = ""
			};

			List<MedicineProduct>? results = await _viewModelMP.SearchMedicineProductAsync(mp, [
				textSearch,"","","",""], [null, null, null, null], "Нет", "Нет", true);

			if (results == null) return null;

			List<Guid> lgAllAnalogues = FilterForSale(_general.AptekaContext.MedicineProducts
				.FromSqlRaw("SELECT * FROM get_medicine_products_analogues({0})", id)
				.AsEnumerable().ToList());

			List<Guid> lgNeedAnalogues = results
					.Select(mp => mp.IdMedicineProduct)
					.Where(mp => lgAllAnalogues.Contains(mp))
					.ToList();

			List<StorageMedicineProduct> lsmp = _general.StorageMedicineProducts
				.Where(smp => lgNeedAnalogues.Contains(smp.IdMedicineProduct))
				.ToList();

			return FilterCurrentDepartment(lsmp);
		}

		internal float CountCost(Guid id, float amount)
		{
			float am = _general.AptekaContext.Database
				.SqlQueryRaw<float>("SELECT * FROM count_cost({0}, {1})", id, amount)
				.AsEnumerable().First();
			return am;
		}

		internal bool InsertSale(HistorySale hs)
		{
			try
			{
				General.AptekaContext.HistorySales.Add(hs);
				General.AptekaContext.SaveChanges();
				return true;
			}
			catch (DbUpdateException ex)
			{
				string message = ex.InnerException?.Message ?? "";

				MessageBox.Show(message, "Ошибка данных",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		internal void RemoveSale(HistorySale hs)
		{
			try
			{
				HistorySale? sale = General.AptekaContext.HistorySales.Find(hs.IdSale);

				if (sale != null)
					General.AptekaContext.HistorySales.Remove(sale);
				General.AptekaContext.SaveChanges();
			}
			catch (DbUpdateException ex)
			{
				string message = ex.InnerException?.Message ?? "";

				MessageBox.Show(message, "Ошибка данных",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		internal bool InsertSaleMedicineProduct(List<HistorySaleMedicineProduct> lhsmp)
		{
			try
			{
				General.AptekaContext.HistorySaleMedicineProducts.AddRange(lhsmp);
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
	}
}
