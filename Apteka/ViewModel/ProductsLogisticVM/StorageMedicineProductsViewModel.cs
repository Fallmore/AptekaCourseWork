﻿using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Npgsql;

namespace Apteka.ViewModel.ProductsLogisticVM
{
	internal class StorageMedicineProductsViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public StorageMedicineProductsViewModel()
		{
			_general = GeneralViewModel.Instance;
		}

		/// <summary>
		/// Привязка данных склада к источникам данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDefaultDataSource(DataGridView dgv)
		{
			dgv.DataSource = new SortableBindingList<StorageMedicineProductWrapper>(
				StorageMedicineProductWrapper.ToList(_general.AptekaContext.StorageMedicineProducts.AsNoTracking().ToList(), this));

			if (dgv.Columns.Contains("IdMedicineProduct"))
				dgv.Columns["IdMedicineProduct"].Visible =
				dgv.Columns["IsCriticalAmount"].Visible =
				dgv.Columns["IdDepartment"].Visible =
				dgv.Columns["IdStorage"].Visible =
				dgv.Columns["IdPlace"].Visible = false;
		}

		/// <summary>
		/// Настраивает таблицу под вывод данных склада
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGV(DataGridView dgv)
		{
			_general.SetDefaultSettingsToDGV(dgv);
			_general.ConfigureGrid<StorageMedicineProductWrapper>(dgv);
		}

		/// <summary>
		/// Поиск ЛП на складе
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="intParams">Обязательны следующие параметры: IdDepartment, IdStorage, IdPlace</param>
		/// <param name="idMedicineProduct"></param>
		/// <returns></returns>
		internal async Task<List<StorageMedicineProduct>?> SearchStorageMedicineProductAsync(int[] intParams, Guid idMedicineProduct)
		{
			try
			{
				List<StorageMedicineProduct> results = await _general.AptekaContext.StorageMedicineProducts
					.FromSqlRaw("SELECT * FROM search_storage_medicine_product({0}, {1}, {2}, {3});",
						intParams[0], intParams[1], intParams[2],
						idMedicineProduct == new Guid() ? null : idMedicineProduct)
					.AsNoTracking()
					.ToListAsync();

				return results;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск ЛП на складе",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		internal bool InsertStorageMedicineProduct(List<StorageMedicineProduct> lsmp)
		{
			try
			{
				General.AptekaContext.StorageMedicineProducts.AddRange(lsmp);
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
	}
}
