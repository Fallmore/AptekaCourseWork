using Apteka.BaseClasses;
using Apteka.Model;
using Apteka.ViewModel;
using System.Data;

namespace Apteka.View.EmployeeV
{
	public partial class EmployeeFiredsForm : FormWithNotification
	{
		private EmployeeFiredViewModel _viewModel;
		private int _indexRow = -1,
			_indexCell = -1;

		public EmployeeFiredsForm()
		{
			InitializeComponent();
			_viewModel = new();
			_viewModel.ConfigureSettingsDGV(dgvEmployeeFireds);
			_viewModel.SetDefaultDataSource(dgvEmployeeFireds);
			HideTechnicalColumns();
			SetDataSourceToComboBoxes();
			SetContextMenuStripItems();
			SetDefaultDates();
			SubscribeTable();
			SubscribeDictionaries();
		}

		private void SubscribeTable()
		{
			OnTableUpdated += Form_OnTableUpdated;
			_viewModel.General.DatabaseNotificationService.Subscribe("employee_fired",
				data =>
				{
					RefreshData<EmployeeFired>(_viewModel.General.EmployeeFireds,
					value => _viewModel.General.EmployeeFireds = value, data);

				});
		}

		private void Form_OnTableUpdated(object? sender, EventArgs e)
		{
			SetDataSourceToComboBoxes();
		}

		private void SubscribeDictionaries()
		{
			OnTableUpdated += Form_OnTableUpdated;

			_viewModel.General.DatabaseNotificationService.Subscribe("post",
				data =>
				{
					RefreshDataSimple<Post>(
					value => _viewModel.General.Posts = value, _viewModel.General);

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
			dgvEmployeeFireds.Columns["IdDepartment"].Visible =
			dgvEmployeeFireds.Columns["IdEmployee"].Visible =
			dgvEmployeeFireds.Columns["IdPost"].Visible = false;
		}

		private void SetContextMenuStripItems()
		{
			contextMenuStrip1.Items.Add("Показать назначения", null,
				(s, e) => ShowOrderAssign());

			contextMenuStrip1.Items.Add("-");

			contextMenuStrip1.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvEmployeeFireds.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
		}

		private void SetDataSourceToComboBoxes()
		{
			cbDepartment.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetDepartment(), new())
				.Select(d => new ComboBoxItem { Name = d.Name, Id = d.IdDepartment }).OrderBy(cbi => cbi.Name).ToList();

			cbPost.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetPost(), new())
				.Select(d => new ComboBoxItem { Name = d.Name, Id = d.IdPost }).OrderBy(cbi => cbi.Name).ToList();

			cbDepartment.DisplayMember =
			cbPost.DisplayMember = "Name";

			cbDepartment.ValueMember =
			cbPost.ValueMember = "Id";
		}

		private async void SearchEmployeeFired(Guid? idEmployee = null)
		{
			bool isAnythingFind = await _viewModel.SearchEmployeeAsync(
				dgvEmployeeFireds, tbName.Text, tbAddress.Text,
				[
								((ComboBoxItem)(cbDepartment.SelectedItem ?? new ComboBoxItem())).Id,
								((ComboBoxItem)(cbPost.SelectedItem ?? new ComboBoxItem())).Id],
			[
								DateOnly.FromDateTime(dtpDateBirthMin.Value.Date),
								DateOnly.FromDateTime(dtpDateBirthMax.Value.Date),
								DateOnly.FromDateTime(dtpDateFireMin.Value.Date),
								DateOnly.FromDateTime(dtpDateFireMax.Value.Date)],
					idEmployee);

			if (isAnythingFind)
				btnResetSearch.Enabled = true;
		}

		private void SetDefaultDates()
		{
			DateOnly[] dates = _viewModel.GetMinMaxDatesBirth();
			if (dates.Length == 0) return;

			dtpDateBirthMin.Value = new(dates[0], new TimeOnly());
			dtpDateBirthMax.Value = new(dates[1], new TimeOnly());

			dates = _viewModel.GetMinMaxDatesFire();
			dtpDateFireMin.Value = new(dates[0], new TimeOnly());
			dtpDateFireMax.Value = new(dates[1], new TimeOnly());
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchEmployeeFired();
		}

		private void btnResetSearch_Click(object sender, EventArgs e)
		{
			_viewModel.SetDefaultDataSource(dgvEmployeeFireds);
			btnResetSearch.Enabled = false;
		}

		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (sender is DataGridView && e.RowIndex != -1)
			{
				_indexRow = e.RowIndex;
				_indexCell = e.ColumnIndex;
				dgvEmployeeFireds.Rows[e.RowIndex].Selected = true;
			}
		}

		private void ShowOrderAssign()
		{
			OrderAssignsForm? oaf = _viewModel.General.GetActivatedForm<OrderAssignsForm>();

			if (oaf == null)
			{
				oaf = new();
				oaf.Show();
			}

			DataGridViewCellCollection row = dgvEmployeeFireds.SelectedRows[0].Cells;

			Guid idEmployee = new(row["IdEmployee"].Value.ToString() ?? "");
			string departmentName = row["Department"].Value.ToString() ?? "";
			string employeeName = string.Concat(
				row["Surname"].Value.ToString() ?? "", " ",
				row["Name"].Value.ToString() ?? "", " ",
				row["Patronymic"].Value.ToString() ?? "");

			oaf.SearchOrderAssignFromOtherForm([departmentName, employeeName], idEmployee);
		}
	}
}
