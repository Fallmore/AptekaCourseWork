using Apteka.BaseClasses;
using Apteka.Model;
using Apteka.View.ProductsLogisticV;
using Apteka.ViewModel.MedicineVM;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Data;

namespace Apteka.View.MedicineV
{
	public partial class MedicineProductDecommissionedForm : FormWithNotification
	{
		private MedicineProductDecommissionedViewModel _viewModel;
		private int _indexRow = -1,
			_indexCell = -1;

		public MedicineProductDecommissionedForm()
		{
			InitializeComponent();
			TopMost = true;
			_viewModel = new();
			_viewModel.ConfigureSettingsDGV(dgvMedicineProductDecommissioned);
			_viewModel.SetDefaultDataSource(dgvMedicineProductDecommissioned);
			SetDataSourceToComboBoxes();
			SetContextMenuStripItems();
			SetDefaultDates();
			SubscribeTable();
		}

		private void SubscribeTable()
		{
			_viewModel.General.DatabaseNotificationService.Subscribe<MedicineProductDecommissionedForm>("medicine_product_decommissioned",
				data =>
				{
					RefreshData<MedicineProductDecommissioned>([],
					value => { }, data,
					() => _viewModel.SetDefaultDataSource(dgvMedicineProductDecommissioned));

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

			contextMenuStrip1.Items.Add("Показать на складе", null,
				(s, e) => ShowMedicineProductInStorage());

			contextMenuStrip1.Items.Add("-");

			contextMenuStrip1.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvMedicineProductDecommissioned.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
		}

		private void SetDataSourceToComboBoxes()
		{
			cbMedicineProductName.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetMedicineProduct(), new())
				.Select(mp => new { mp.Name, Id = mp.IdMedicineProduct }).OrderBy(cbi => cbi.Name).ToList();

			cbMedicineProductName.DisplayMember = "Name";
			cbMedicineProductName.ValueMember = "Id";
		}

		/// <summary>
		/// Вызов поиска списанных ЛП с других форм
		/// </summary>
		/// <param name="medicineProductName"></param>
		internal void SearchMedicineProductDecommissionedFromOtherForm(string medicineProductName)
		{
			cbMedicineProductName.SelectedIndex = cbMedicineProductName.FindStringExact(medicineProductName);
			SearchMedicineProductDecommissioned();
		}

		private async void SearchMedicineProductDecommissioned()
		{
			List<MedicineProductDecommissioned>? results = await _viewModel.SearchMedicineProductDecommissionedAsync(
				(Guid)(cbMedicineProductName.SelectedValue ?? new Guid()),
						tbReason.Text,
			[dtpDateDecommissionMin.Value, dtpDateDecommissionMax.Value]);

			if (results == null) return;

			if (results.Count == 0)
			{
				MessageBox.Show("Списанные ЛП найдены", "Поиск списанных ЛП",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			dgvMedicineProductDecommissioned.DataSource = new SortableBindingList<MedicineProductDecommissionedWrapper>(
				MedicineProductDecommissionedWrapper.ToMedicineProductDecommissionedWrapper(results, _viewModel));
			btnResetSearch.Enabled = true;
		}

		private void SetDefaultDates()
		{
			DateTime[] dates = _viewModel.GetMinMaxDatesDecommission();
			if (dates.Length == 0) return;

			dtpDateDecommissionMin.Value = dates[0];
			dtpDateDecommissionMax.Value = dates[1];
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchMedicineProductDecommissioned();
		}

		private void btnResetSearch_Click(object sender, EventArgs e)
		{
			_viewModel.SetDefaultDataSource(dgvMedicineProductDecommissioned);
			btnResetSearch.Enabled = false;
		}

		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (sender is DataGridView && e.RowIndex != -1)
			{
				_indexRow = e.RowIndex;
				_indexCell = e.ColumnIndex;
				dgvMedicineProductDecommissioned.Rows[e.RowIndex].Selected = true;
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

			Guid idMedicineProduct = new(dgvMedicineProductDecommissioned.SelectedRows[0].Cells["IdMedicineProduct"].Value.ToString() ?? "");

			MedicineProduct mp = _viewModel.General.AptekaContext.MedicineProducts
				.Where(mp => mp.IdMedicineProduct == idMedicineProduct)
				.First() ?? new();

			mpf.SearchMedicineProductFromOtherForm(mp.SerialNumber);
		}

		private void ShowMedicineProductInStorage()
		{
			StorageMedicineProductsForm? msf = _viewModel.General.GetActivatedForm<StorageMedicineProductsForm>();

			if (msf == null)
			{
				msf = new();
				msf.Show();
			}

			string medicineProductName = dgvMedicineProductDecommissioned.SelectedRows[0].Cells["MedicineProductName"].Value.ToString() ?? "";

			msf.SearchStorageMedicineProductFromMedicineProductsForm(medicineProductName);
		}
	}
}
