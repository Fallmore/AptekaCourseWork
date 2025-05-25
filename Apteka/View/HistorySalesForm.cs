using Apteka.BaseClasses;
using Apteka.Model;
using Apteka.View.EmployeeV;
using Apteka.ViewModel;
using System.Data;

namespace Apteka.View
{
	public partial class HistorySalesForm : FormWithNotification
	{
		private HistorySalesViewModel _viewModel;
		private int _indexRow = -1,
			_indexCell = -1;

		public HistorySalesForm()
		{
			InitializeComponent();
			_viewModel = new();
			_viewModel.ConfigureSettingsDGV(dgvHistorySales);
			_viewModel.SetDefaultDataSource(dgvHistorySales);
			HideTechnicalColumns();
			SetDataSourceToComboBoxes();
			SetContextMenuStripItems();
			SetDefaultDates();
			SubscribeTable();
			SubscribeDictionaries();
		}

		private void SubscribeTable()
		{
			_viewModel.General.DatabaseNotificationService.Subscribe("history_sale",
				data =>
				{
					RefreshData<HistorySale>(_viewModel.General.HistorySales,
					value => _viewModel.General.HistorySales = value, data);

				});
		}

		private void Form_OnTableUpdated(object? sender, EventArgs e)
		{
			SetDataSourceToComboBoxes();
		}

		private void SubscribeDictionaries()
		{
			OnTableUpdated += Form_OnTableUpdated;

			_viewModel.General.DatabaseNotificationService.Subscribe("storage_place",
				data =>
				{
					RefreshDataSimple<StoragePlace>(
					value => _viewModel.General.StoragePlaces = value, _viewModel.General);

				});

			_viewModel.General.DatabaseNotificationService.Subscribe("storage_pharmacy",
				data =>
				{
					RefreshDataSimple<StoragePharmacy>(
					value => _viewModel.General.StoragePharmacies = value, _viewModel.General);

				});

			_viewModel.General.DatabaseNotificationService.Subscribe("department",
				data =>
				{
					RefreshDataSimple<Department>(
					value => _viewModel.General.Departments = value, _viewModel.General);

				});
		}

		private void HideTechnicalColumns()
		{
			dgvHistorySales.Columns["IdMedicineProduct"].Visible =
			dgvHistorySales.Columns["IdDepartment"].Visible =
			dgvHistorySales.Columns["IdEmployee"].Visible =
			dgvHistorySales.Columns["IdStorage"].Visible =
			dgvHistorySales.Columns["IdPlace"].Visible =
			dgvHistorySales.Columns["IdSale"].Visible = false;
		}

		private void SetContextMenuStripItems()
		{
			contextMenuStrip1.Items.Add("Показать препарат", null,
				(s, e) => ShowMedicineProduct());

			contextMenuStrip1.Items.Add("Показать сотрудника", null,
				(s, e) => ShowEmployee());

			contextMenuStrip1.Items.Add("-");

			contextMenuStrip1.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvHistorySales.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
		}

		private void SetDataSourceToComboBoxes()
		{
			cbMedicineProductName.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetMedicineProduct(), new())
				.Select(mp => new { mp.Name, Id = mp.IdMedicineProduct }).OrderBy(cbi => cbi.Name).ToList();

			cbPlace.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetStoragePlace(), new())
				.Select(sp => new ComboBoxItem { Name = sp.Name, Id = sp.IdPlace }).OrderBy(cbi => cbi.Name).ToList();

			cbStorage.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetStoragePharmacy(), new())
				.Select(sp => new ComboBoxItem { Name = sp.Name, Id = sp.IdStorage }).OrderBy(cbi => cbi.Name).ToList();

			cbDepartment.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetDepartment(), new())
				.Select(d => new ComboBoxItem { Name = d.Name, Id = d.IdDepartment }).OrderBy(cbi => cbi.Name).ToList();

			cbEmployee.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetEmployee(), new())
				.Select(e => new { Name = $"{e.Surname} {e.Name} {e.Patronymic}", Id = e.IdEmployee }).OrderBy(cbi => cbi.Name).ToList();

			cbPlace.DisplayMember =
			cbStorage.DisplayMember =
			cbDepartment.DisplayMember =
			cbEmployee.DisplayMember =
			cbMedicineProductName.DisplayMember = "Name";

			cbPlace.ValueMember =
			cbStorage.ValueMember =
			cbDepartment.ValueMember =
			cbEmployee.ValueMember =
			cbMedicineProductName.ValueMember = "Id";
		}

		/// <summary>
		/// Вызов поиска продаж с других форм
		/// </summary>
		/// <param name="strParams">Обязательны следующие параметры: DepartmentName, StorageName, 
		/// PlaceName, MedicineProductName, EmployeeName
		/// <para>При отсутствии какого-либо параметра необходимо проставить string.Empty</para>
		/// </param>
		internal void SearchSaleFromOtherForm(string[] strParams)
		{
			cbDepartment.SelectedIndex = cbDepartment.FindStringExact(strParams[0]);
			cbStorage.SelectedIndex = cbStorage.FindStringExact(strParams[1]);
			cbPlace.SelectedIndex = cbPlace.FindStringExact(strParams[2]);
			cbMedicineProductName.SelectedIndex = cbMedicineProductName.FindStringExact(strParams[3]);
			cbEmployee.SelectedIndex = cbEmployee.FindStringExact(strParams[4]);
			SearchSale();
		}

		private async void SearchSale()
		{
			bool isAnythingFind = await _viewModel.SearchSalesAsync(
				dgvHistorySales,
				[
							((ComboBoxItem)(cbDepartment.SelectedItem ?? new ComboBoxItem())).Id,
							((ComboBoxItem)(cbStorage.SelectedItem ?? new ComboBoxItem())).Id,
							((ComboBoxItem)(cbPlace.SelectedItem ?? new ComboBoxItem())).Id],
			[dtpDateSaleMin.Value.Date, dtpDateSaleMax.Value.Date],
				[
							(Guid)(cbMedicineProductName.SelectedValue ?? new Guid()),
							(Guid)(cbEmployee.SelectedValue ?? new Guid())]);

			if (isAnythingFind)
				btnResetSearch.Enabled = true;
		}

		private void SetDefaultDates()
		{
			DateTime[] dates = _viewModel.GetMinMaxDatesDecommission();
			if (dates.Length == 0) return;

			dtpDateSaleMin.Value = dates[0];
			dtpDateSaleMax.Value = dates[1];
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchSale();
		}

		private void btnResetSearch_Click(object sender, EventArgs e)
		{
			_viewModel.SetDefaultDataSource(dgvHistorySales);
			btnResetSearch.Enabled = false;
		}

		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (sender is DataGridView && e.RowIndex != -1)
			{
				_indexRow = e.RowIndex;
				_indexCell = e.ColumnIndex;
				dgvHistorySales.Rows[e.RowIndex].Selected = true;
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

			Guid idMedicineProduct = new(dgvHistorySales.SelectedRows[0].Cells["IdMedicineProduct"].Value.ToString() ?? "");

			MedicineProduct mp = _viewModel.General.AptekaContext.MedicineProducts
				.Where(mp => mp.IdMedicineProduct == idMedicineProduct)
				.First() ?? new();

			mpf.SearchMedicineProductFromStorageMedicineProductsForm(mp.SerialNumber);
		}

		private void ShowEmployee()
		{
			EmployeesForm? ef = _viewModel.General.GetActivatedForm<EmployeesForm>();

			if (ef == null)
			{
				ef = new();
				ef.Show();
			}

			Guid idEmployee = new(dgvHistorySales.SelectedRows[0].Cells["IdEmployee"].Value.ToString() ?? "");
			string departmentName = dgvHistorySales.SelectedRows[0].Cells["Department"].Value.ToString() ?? "";
			string employeeName = dgvHistorySales.SelectedRows[0].Cells["EmployeeName"].Value.ToString() ?? "";

			ef.SearchEmployeeFromOtherForm([departmentName, employeeName], idEmployee);
		}

		private void cbStorage_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbPlace.Enabled = cbStorage.SelectedIndex != 0;
		}
	}
}
