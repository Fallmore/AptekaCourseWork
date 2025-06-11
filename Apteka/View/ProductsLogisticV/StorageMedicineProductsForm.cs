using Apteka.BaseClasses;
using Apteka.Model;
using Apteka.View.MedicineV;
using Apteka.ViewModel;
using Apteka.ViewModel.ProductsLogisticVM;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Data;

namespace Apteka.View.ProductsLogisticV
{
	public partial class StorageMedicineProductsForm : FormWithNotification
	{
		private StorageMedicineProductsViewModel _viewModel;
		private int _indexRow = -1,
			_indexCell = -1;

		public StorageMedicineProductsForm()
		{
			InitializeComponent();
			_viewModel = new();
			_viewModel.ConfigureSettingsDGV(dgvStorageMedicineProducts);
			_viewModel.SetDefaultDataSource(dgvStorageMedicineProducts);
			SetDataSourceToComboBoxes();
			SetContextMenuStripItems();
			SubscribeTable();
			SubscribeDictionaries();
			_viewModel.General
				.SetFormByRole(lblDepartment, cbDepartment, dgvStorageMedicineProducts);
		}

		private void SubscribeTable()
		{
			_viewModel.General.DatabaseNotificationService.Subscribe<StorageMedicineProductsForm>("storage_medicine_product",
				data =>
				{
					RefreshData<StorageMedicineProduct>(_viewModel.General.StorageMedicineProducts,
					value => _viewModel.General.StorageMedicineProducts = value, data,
					() => _viewModel.SetDefaultDataSource(dgvStorageMedicineProducts));

				});
		}

		private void SubscribeDictionaries()
		{
			OnTableUpdated += Form_OnTableUpdated;

			_viewModel.General.DatabaseNotificationService.Subscribe<StorageMedicineProductsForm>("storage_place",
				data =>
				{
					RefreshDataSimple<StoragePlace>(
					value => _viewModel.General.StoragePlaces = value, _viewModel.General);

				});

			_viewModel.General.DatabaseNotificationService.Subscribe<StorageMedicineProductsForm>("storage_pharmacy",
				data =>
				{
					RefreshDataSimple<StoragePharmacy>(
					value => _viewModel.General.StoragePharmacies = value, _viewModel.General);

				});

			_viewModel.General.DatabaseNotificationService.Subscribe<StorageMedicineProductsForm>("department",
				data =>
				{
					RefreshDataSimple<Department>(
					value => _viewModel.General.Departments = value, _viewModel.General);

				});
		}

		private void Form_OnTableUpdated(object? sender, EventArgs e)
		{
			SetDataSourceToComboBoxes();
		}

		private void SetContextMenuStripItems()
		{
			contextMenuStrip1.Items.Add("Показать препарат", null,
				(s, e) => ShowMedicineProduct());

			if (_viewModel.General.ChoosedRole != (int)Roles.Сотрудник &&
				_viewModel.General.ChoosedRole != (int)Roles.Кассир)
			{
				contextMenuStrip1.Items.Add("Показать продажи препарата с этого места", null,
				(s, e) => ShowHistorySale(false));

				contextMenuStrip1.Items.Add("Показать продажи с этого места", null,
					(s, e) => ShowHistorySale(true));
			}

			contextMenuStrip1.Items.Add("-");

			contextMenuStrip1.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvStorageMedicineProducts.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
		}

		private List<T> GetListWithEmptyItem<T>(List<T> ls, T emptyItem)
		{
			List<T> tempList = [emptyItem];
			tempList.AddRange(ls);
			return tempList;
		}

		private void SetDataSourceToComboBoxes()
		{
			cbMedicineProductName.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetMedicineProduct(), new())
				.Select(i => new { i.Name, Id = i.IdMedicineProduct }).OrderBy(cbi => cbi.Name).ToList();

			cbPlace.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetStoragePlace(), new())
				.Select(i => new ComboBoxItem { Name = i.Name, Id = i.IdPlace }).OrderBy(cbi => cbi.Name).ToList();

			cbStorage.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetStoragePharmacy(), new())
				.Select(i => new ComboBoxItem { Name = i.Name, Id = i.IdStorage }).OrderBy(cbi => cbi.Name).ToList();

			cbDepartment.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetDepartment(), new())
				.Select(i => new ComboBoxItem { Name = i.Name, Id = i.IdDepartment }).OrderBy(cbi => cbi.Name).ToList();

			cbPlace.DisplayMember =
			cbStorage.DisplayMember =
			cbDepartment.DisplayMember =
			cbMedicineProductName.DisplayMember = "Name";

			cbPlace.ValueMember =
			cbStorage.ValueMember =
			cbDepartment.ValueMember =
			cbMedicineProductName.ValueMember = "Id";
		}

		internal void SearchStorageMedicineProductFromMedicineProductsForm(string medicineProductName)
		{
			cbMedicineProductName.SelectedIndex = cbMedicineProductName.FindStringExact(medicineProductName);
			SearchStorageMedicineProduct();
		}

		private async void SearchStorageMedicineProduct()
		{

			List<StorageMedicineProduct>? results = await _viewModel.SearchStorageMedicineProductAsync(
				[
					((ComboBoxItem)(cbDepartment.SelectedItem ?? new ComboBoxItem())).Id,
					((ComboBoxItem)(cbStorage.SelectedItem ?? new ComboBoxItem())).Id,
					((ComboBoxItem)(cbPlace.SelectedItem ?? new ComboBoxItem())).Id], (Guid)cbMedicineProductName.SelectedValue);

			if (results == null) return;

			if (results.Count == 0)
			{
				MessageBox.Show("Ничего не найдено", "Поиск ЛП на складе",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			dgvStorageMedicineProducts.DataSource = new SortableBindingList<StorageMedicineProductWrapper>(
				StorageMedicineProductWrapper.ToList(results, _viewModel));
			btnResetSearch.Enabled = true;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchStorageMedicineProduct();
		}

		private void btnResetSearch_Click(object sender, EventArgs e)
		{
			_viewModel.SetDefaultDataSource(dgvStorageMedicineProducts);
			btnResetSearch.Enabled = false;
		}

		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (sender is DataGridView && e.RowIndex != -1)
			{
				_indexRow = e.RowIndex;
				_indexCell = e.ColumnIndex;
				dgvStorageMedicineProducts.Rows[e.RowIndex].Selected = true;
			}
		}

		private void ShowMedicineProduct()
		{
			MedicineProductsForm? mpf = _viewModel.General.GetActivatedForm<MedicineProductsForm>();

			if (mpf == null)
			{
				mpf = new();
				mpf.Show();
			}

			Guid idMedicineProduct = new(dgvStorageMedicineProducts.SelectedRows[0].Cells["IdMedicineProduct"].Value.ToString() ?? "");

			MedicineProduct mp = _viewModel.General.AptekaContext.MedicineProducts
				.Where(mp => mp.IdMedicineProduct == idMedicineProduct)
				.First() ?? new();

			mpf.SearchMedicineProductFromOtherForm(mp.SerialNumber);
		}

		private void ShowHistorySale(bool isOnlyPlace)
		{
			HistorySalesForm? hsf = _viewModel.General.GetActivatedForm<HistorySalesForm>();

			if (hsf == null)
			{
				hsf = new();
				hsf.Show();
			}

			var columns = dgvStorageMedicineProducts.SelectedRows[0].Cells;
			string medicineProductName = columns["MedicineProductName"].Value.ToString() ?? string.Empty;
			string departmentName = columns["Department"].Value.ToString() ?? string.Empty;
			string storageName = columns["Storage"].Value.ToString() ?? string.Empty;
			string placeName = columns["Place"].Value.ToString() ?? string.Empty;

			hsf.SearchSaleFromOtherForm([departmentName,
					storageName, placeName,
					(isOnlyPlace ? string.Empty : medicineProductName), string.Empty]);
		}

		private void cbStorage_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbPlace.Enabled = cbStorage.SelectedIndex != 0;
		}

		private void dgvStorageMedicineProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

			DataGridViewRow row = dgvStorageMedicineProducts.Rows[e.RowIndex];

			if (bool.Parse(row.Cells["IsCriticalAmount"].Value.ToString() ?? "false"))
			{
				e.CellStyle.BackColor = Color.LightPink;
				e.CellStyle.ForeColor = Color.DarkRed;
				e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
				e.CellStyle.SelectionForeColor = Color.Black;
			}
		}
	}
}
