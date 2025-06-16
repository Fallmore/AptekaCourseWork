using Apteka.BaseClasses;
using Apteka.Model;
using Apteka.ViewModel.MedicineVM;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;


namespace Apteka.View.MedicineV
{
	public partial class MedicinesForm : FormWithNotification
	{
		private MedicinesViewModel _viewModel;
		private int _indexRow = -1,
			_indexCell = -1;
		public MedicinesForm()
		{
			InitializeComponent();
			TopMost = true;
			_viewModel = new();
			_viewModel.ConfigureSettingsDGV(dgvMedicine);
			_viewModel.SetDefaultDataSource(dgvMedicine);
			SetContextMenuStripItems();
			SubscribeTable();
		}

		private void SubscribeTable()
		{
			OnTableUpdated += Form_OnTableUpdated;
			_viewModel.General.DatabaseNotificationService.Subscribe<MedicinesForm>("medicine",
				data =>
				{
					RefreshData<Medicine>([],
					value => { }, data);
				});
		}

		private void Form_OnTableUpdated(object? sender, EventArgs e)
		{
			_viewModel.SetDefaultDataSource(dgvMedicine);
		}

		private void SetContextMenuStripItems()
		{
			contextMenuStrip1.Items.Add("Показать препарат", null,
				(s, e) => ShowProducts());

			contextMenuStrip1.Items.Add("-");

			contextMenuStrip1.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvMedicine.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
		}

		internal async void SearchMedicineFromMedicineProductsForm(int idMedicine)
		{
			List<Medicine>? results = await _viewModel.SearchMedicineAsync(
				tbName.Text.Trim(), tbMNN.Text.Trim(),
				tbPharmGroup.Text.Trim(), tbConditionRelease.Text.Trim(), idMedicine);

			if (results == null) return;

			if (results.Count == 0)
			{
				MessageBox.Show("Лекарство не найдено", "Поиск лекарства",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			dgvMedicine.DataSource = new SortableBindingList<Medicine>(results);
			tbName.Text = dgvMedicine.Rows[0].Cells[0].Value.ToString();
			btnResetSearch.Enabled = true;
		}

		private async void btnSearch_Click(object sender, EventArgs e)
		{
			List<Medicine>? results = await _viewModel.SearchMedicineAsync(
				tbName.Text.Trim(), tbMNN.Text.Trim(),
				tbPharmGroup.Text.Trim(), tbConditionRelease.Text.Trim(), -1);

			if (results == null) return;

			if (results.Count == 0)
			{
				MessageBox.Show("Лекарство не найдено", "Поиск лекарства",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			dgvMedicine.DataSource = new SortableBindingList<Medicine>(results);
			btnResetSearch.Enabled = true;
		}

		private void btnResetSearch_Click(object sender, EventArgs e)
		{
			_viewModel.SetDefaultDataSource(dgvMedicine);
			btnResetSearch.Enabled = false;
		}

		private void ShowProducts()
		{
			MedicineProductsForm? mpf = _viewModel.General.GetActivatedForm<MedicineProductsForm>();

			if (mpf == null)
			{
				mpf = new();
				mpf.Show();
			}

			Medicine m = _viewModel.General.Medicines
				.Find(m =>
					m.Name == dgvMedicine.SelectedRows[0].Cells["Name"].Value.ToString()) ?? new();

			mpf.SearchMedicineProductFromMedicinesForm(m.IdMedicine, m.Mnn);
		}

		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (sender is DataGridView && e.RowIndex != -1)
			{
				_indexRow = e.RowIndex;
				_indexCell = e.ColumnIndex;
				dgvMedicine.Rows[e.RowIndex].Selected = true;
			}
		}
	}
}
