using Apteka.BaseClasses;
using Apteka.Model;
using Apteka.View.EmployeeV;
using Apteka.ViewModel;
using Apteka.ViewModel.ProductsLogisticVM;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
			_viewModel.ConfigureSettingsDGV<HistorySaleWrapper>(dgvHistorySales);
			_viewModel.SetDefaultDataSource<HistorySaleWrapper>(dgvHistorySales);
			_viewModel.ConfigureSettingsDGV<HistorySaleMedicineProductWrapper>(dgvHistorySaleMedicineProduct);
			_viewModel.SetDefaultDataSource<HistorySaleMedicineProductWrapper>(dgvHistorySaleMedicineProduct);
			SetDataSourceToComboBoxes();
			SetCmsHistorySalesItems();
			SetCmsHistorySaleslMedicineProductItems();
			SetDefaultDates();
			SubscribeTable();
			SubscribeDictionaries();
		}

		private void SubscribeTable()
		{
			_viewModel.General.DatabaseNotificationService.Subscribe<HistorySalesForm>("history_sale",
				data =>
				{
					RefreshData<HistorySale>(_viewModel.General.HistorySales,
					value => _viewModel.General.HistorySales = value, data,
					() => _viewModel.SetDefaultDataSource<HistorySaleWrapper>(dgvHistorySales));

				});

			_viewModel.General.DatabaseNotificationService.Subscribe<HistorySalesForm>("history_sale_medicine_product",
				data =>
				{
					RefreshData<HistorySaleMedicineProduct>(_viewModel.General.HistorySalesMedicineProduct,
					value => _viewModel.General.HistorySalesMedicineProduct = value, data,
					() => _viewModel.SetDefaultDataSource<HistorySaleMedicineProductWrapper>(dgvHistorySaleMedicineProduct));

				});
		}

		private void Form_OnTableUpdated(object? sender, EventArgs e)
		{
			SetDataSourceToComboBoxes();
		}

		private void SubscribeDictionaries()
		{
			OnTableUpdated += Form_OnTableUpdated;

			_viewModel.General.DatabaseNotificationService.Subscribe<HistorySalesForm>("storage_place",
				data =>
				{
					RefreshDataSimple<StoragePlace>(
					value => _viewModel.General.StoragePlaces = value, _viewModel.General);

				});

			_viewModel.General.DatabaseNotificationService.Subscribe<HistorySalesForm>("storage_pharmacy",
				data =>
				{
					RefreshDataSimple<StoragePharmacy>(
					value => _viewModel.General.StoragePharmacies = value, _viewModel.General);

				});

			_viewModel.General.DatabaseNotificationService.Subscribe<HistorySalesForm>("department",
				data =>
				{
					RefreshDataSimple<Department>(
					value => _viewModel.General.Departments = value, _viewModel.General);

				});
		}

		private void SetCmsHistorySalesItems()
		{
			cmsHistorySales.Items.Add("Показать сотрудника", null,
				(s, e) => ShowEmployee());

			cmsHistorySales.Items.Add("-");

			cmsHistorySales.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvHistorySales.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
		}

		private void SetCmsHistorySaleslMedicineProductItems()
		{
			cmsHistorySalesMedicineProduct.Items.Add("Показать препарат", null,
				(s, e) => ShowMedicineProduct());

			cmsHistorySalesMedicineProduct.Items.Add("-");

			cmsHistorySalesMedicineProduct.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvHistorySaleMedicineProduct.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
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
			List<HistorySale>? results = await _viewModel.SearchSalesAsync(
				[
							((ComboBoxItem)(cbDepartment.SelectedItem ?? new ComboBoxItem())).Id,
							((ComboBoxItem)(cbStorage.SelectedItem ?? new ComboBoxItem())).Id,
							((ComboBoxItem)(cbPlace.SelectedItem ?? new ComboBoxItem())).Id],
			[dtpDateSaleMin.Value, dtpDateSaleMax.Value],
				[
							(Guid)(cbMedicineProductName.SelectedValue ?? new Guid()),
							(Guid)(cbEmployee.SelectedValue ?? new Guid())]);

			if (results == null) return;

			if (results.Count == 0)
			{
				MessageBox.Show("Ничего не найдено", "Поиск продаж",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			dgvHistorySales.DataSource = new SortableBindingList<HistorySaleWrapper>(
				HistorySaleWrapper.ToList(results, _viewModel));
			btnResetSearch.Enabled = true;
		}

		private void SetDefaultDates()
		{
			DateTime[] dates = _viewModel.GetMinMaxDatesSales();
			if (dates.Length == 0) return;

			dtpDateSaleMin.Value = dates[0].AddSeconds(-10);
			dtpDateSaleMax.Value = dates[1].AddSeconds(10);
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchSale();
		}

		private void btnResetSearch_Click(object sender, EventArgs e)
		{
			_viewModel.SetDefaultDataSource<HistorySaleWrapper>(dgvHistorySales);
			btnResetSearch.Enabled = false;
		}

		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (sender is DataGridView dgv && e.RowIndex != -1)
			{
				_indexRow = e.RowIndex;
				_indexCell = e.ColumnIndex;
				dgv.Rows[e.RowIndex].Selected = true;
				if (dgv.Name == "dgvHistorySales")
				{
					if (MouseButtons.Right == e.Button)
						cmsHistorySales.Show(Cursor.Position);
				}
				else
				{
					if (MouseButtons.Right == e.Button)
						cmsHistorySalesMedicineProduct.Show(Cursor.Position);
				}
			}
		}

		private void dgv_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvHistorySales.SelectedRows.Count != 0 && !dgvHistorySales.CurrentRow.IsNewRow)
			{
				DataGridViewRow selectedRow = dgvHistorySales.SelectedRows[0];

				ShowHistorySalesMedicineProducts(selectedRow);
			}
		}

		private void ShowHistorySalesMedicineProducts(DataGridViewRow row)
		{
			Guid idSale = Guid.Parse(row.Cells["IdSale"].Value.ToString() ?? "");
			List<HistorySaleMedicineProductWrapper> medicineProducts = HistorySaleMedicineProductWrapper
				.ToList(_viewModel.General.HistorySalesMedicineProduct, _viewModel)
				.Where(mc => mc.IdSale == idSale).ToList();
			dgvHistorySaleMedicineProduct.DataSource =
				new SortableBindingList<HistorySaleMedicineProductWrapper>(medicineProducts);
		}

		private void ShowMedicineProduct()
		{
			MedicineProductsForm? mpf = _viewModel.General.GetActivatedForm<MedicineProductsForm>();

			if (mpf == null)
			{
				mpf = new();
				mpf.Show();
			}

			string serialNumber = new(dgvHistorySaleMedicineProduct.SelectedRows[0]
				.Cells["SerialNumber"].Value.ToString() ?? "");

			mpf.SearchMedicineProductFromOtherForm(serialNumber);
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
