using Apteka.BaseClasses;
using Apteka.Model;
using Apteka.View.EmployeeV;
using Apteka.ViewModel;
using Apteka.ViewModel.EmployeeVM;
using Apteka.ViewModel.ProductsLogisticVM;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Data;

namespace Apteka.View
{
	public partial class WaybillsForm : FormWithNotification
	{
		private WaybillViewModel _viewModel;
		private int _indexRow = -1,
			_indexCell = -1;

		public WaybillsForm()
		{
			InitializeComponent();
			_viewModel = new();
			_viewModel.ConfigureSettingsDGV<WaybillWrapper>(dgvWaybill);
			_viewModel.SetDefaultDataSource<WaybillWrapper>(dgvWaybill);
			_viewModel.ConfigureSettingsDGV<WaybillMedicineProductWrapper>(dgvMedicineProduct);
			_viewModel.SetDefaultDataSource<WaybillMedicineProductWrapper>(dgvMedicineProduct);
			SetDefaultDates();
			SetDataSourceToComboBoxes();
			SetCmsWaybillItems();
			SetCmsWaybillMedicineProductItems();
			SubscribeTable();
			_viewModel.General
				.SetFormByRole(lblDepartment, cbDepartment, dgvWaybill);
		}

		private void SubscribeTable()
		{
			_viewModel.General.DatabaseNotificationService.Subscribe<WaybillsForm>("waybill",
				data =>
				{
					RefreshData<Waybill>(_viewModel.General.Waybills,
					value => _viewModel.General.Waybills = value, data,
					() => _viewModel.SetDefaultDataSource<WaybillWrapper>(dgvWaybill));

				});

			_viewModel.General.DatabaseNotificationService.Subscribe<WaybillsForm>("waybill_medicine_product",
				data =>
				{
					RefreshData<WaybillMedicineProduct>(_viewModel.General.WaybillsMedicineProduct,
					value => _viewModel.General.WaybillsMedicineProduct = value, data,
					() => _viewModel.SetDefaultDataSource<WaybillMedicineProduct>(dgvMedicineProduct));

				});
		}

		private void SetCmsWaybillItems()
		{
			cmsWaybill.Items.Add("Показать сотрудника", null,
				(s, e) => ShowEmployee());

			cmsWaybill.Items.Add("-");

			cmsWaybill.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvWaybill.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
		}

		private void SetCmsWaybillMedicineProductItems()
		{
			cmsMedicineProduct.Items.Add("Показать препарат", null,
				(s, e) => ShowProducts());

			cmsMedicineProduct.Items.Add("-");

			cmsMedicineProduct.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvMedicineProduct.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
		}

		private void SetDataSourceToComboBoxes()
		{
			cbSupplier.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetSupplier(), new())
				.Select(s => new ComboBoxItem { Name = s.Name, Id = s.IdSupplier })
				.OrderBy(cbi => cbi.Name).ToList();

			cbEmployee.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetEmployee(), new())
				.Select(e => new { Name = $"{e.Surname} {e.Name} {e.Patronymic}", Id = e.IdEmployee })
				.OrderBy(cbi => cbi.Name).ToList();

			cbDepartment.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetDepartment(), new())
				.Select(d => new ComboBoxItem { Name = d.Name, Id = d.IdDepartment })
				.OrderBy(cbi => cbi.Name).ToList();

			cbMedicineProduct.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetMedicineProduct(), new())
				.Select(mp => new { mp.Name, Id = mp.IdMedicineProduct })
				.OrderBy(cbi => cbi.Name).ToList();

			cbEmployee.DisplayMember =
			cbSupplier.DisplayMember =
			cbDepartment.DisplayMember =
			cbMedicineProduct.DisplayMember = "Name";

			cbEmployee.ValueMember =
			cbSupplier.ValueMember =
			cbDepartment.ValueMember =
			cbMedicineProduct.ValueMember = "Id";
		}

		#region Всё, что связано с поиском

		private async void SearchWaybill()
		{
			Waybill w = new()
			{
				IdWaybill = int.Parse(tbIdWaybill.Text == "" ? "-1" : tbIdWaybill.Text),
				IdEmployee = Guid.Parse(cbEmployee.SelectedValue.ToString() ?? ""),
				IdDepartment = int.Parse(cbDepartment.SelectedValue.ToString() ?? "-1"),
				IdSupplier = int.Parse(cbSupplier.SelectedValue.ToString() ?? "-1"),
			};

			Guid idMedicineProduct = Guid.Parse(cbMedicineProduct.SelectedValue.ToString() ?? "");

			List<Waybill>? results = await _viewModel.SearchWaybillAsync(w, idMedicineProduct,
				[
					DateOnly.FromDateTime(dtpDateWaybillMin.Value),
					DateOnly.FromDateTime(dtpDateWaybillMax.Value)]);

			if (results == null) return;

			if (results.Count == 0)
			{
				MessageBox.Show("Накладная не найдена", "Поиск накладной",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			dgvWaybill.DataSource = new SortableBindingList<WaybillWrapper>(
			WaybillWrapper.ToList(results, _viewModel));
			btnResetSearch.Enabled = true;
		}

		internal void SearchWaybillFromMedicineProductsForm(string serialNumber)
		{
			SearchWaybill();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchWaybill();
		}

		private void btnResetSearch_Click(object sender, EventArgs e)
		{
			_viewModel.SetDefaultDataSource<WaybillWrapper>(dgvWaybill);
			btnResetSearch.Enabled = false;
		}

		private void SetDefaultDates()
		{
			DateOnly[] dates = _viewModel.GetMinMaxDatesWaybill();
			if (dates.Length == 0) return;

			dtpDateWaybillMin.Value = new(dates[0], new TimeOnly());
			dtpDateWaybillMax.Value = new(dates[1], new TimeOnly());
		}
		#endregion

		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (sender is DataGridView dgv && e.RowIndex != -1)
			{
				_indexRow = e.RowIndex;
				_indexCell = e.ColumnIndex;
				DataGridViewRow row = dgv.Rows[e.RowIndex];
				row.Selected = true;
				if (dgv.Name == "dgvWaybill")
				{
					if (MouseButtons.Right == e.Button)
						cmsWaybill.Show(Cursor.Position);
				}
				else
				{
					if (MouseButtons.Right == e.Button)
						cmsMedicineProduct.Show(Cursor.Position);
				}
			}
		}

		private void dgvWaybill_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvWaybill.SelectedRows.Count != 0 && !dgvWaybill.CurrentRow.IsNewRow)
			{
				DataGridViewRow selectedRow = dgvWaybill.SelectedRows[0];

				ShowWaybillMedicineProducts(selectedRow);
			}
		}

		private void tbIdWaybill_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Разрешаем:
			// - цифры (0-9)
			// - Backspace (удаление)
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true; // Блокируем ввод
			}
		}

		private void ShowWaybillMedicineProducts(DataGridViewRow row)
		{
			int idWaybill = int.Parse(row.Cells["IdWaybill"].Value.ToString() ?? "");
			List<WaybillMedicineProductWrapper> medicineProducts = WaybillMedicineProductWrapper
				.ToList(_viewModel.General.WaybillsMedicineProduct, _viewModel)
				.Where(mc => mc.IdWaybill == idWaybill).ToList();
			dgvMedicineProduct.DataSource = new SortableBindingList<WaybillMedicineProductWrapper>(medicineProducts);
		}

		#region Всё, что связано с вызовом форм

		private void ShowProducts()
		{
			MedicineProductsForm? mpf = _viewModel.General.GetActivatedForm<MedicineProductsForm>();

			if (mpf == null)
			{
				mpf = new();
				mpf.Show();
			}

			string serialNumber = dgvMedicineProduct.SelectedRows[0]
				.Cells["SerialNumber"].Value.ToString() ?? "";

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

			DataGridViewCellCollection row = dgvWaybill.SelectedRows[0].Cells;

			Guid idEmployee = new(row["IdEmployee"].Value.ToString() ?? "");
			string departmentName = row["Department"].Value.ToString() ?? "";
			string employeeName = row["Employee"].Value.ToString() ?? "";

			ef.SearchEmployeeFromOtherForm([departmentName, employeeName], idEmployee);
		}

		#endregion
	}
}
