using Apteka.BaseClasses;
using Apteka.Model;
using Apteka.ViewModel;
using Apteka.ViewModel.EmployeeVM;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Data;

namespace Apteka.View.EmployeeV
{
	public partial class OrderAssignsForm : FormWithNotification
	{
		private OrderAssignViewModel _viewModel;
		private int _indexRow = -1,
			_indexCell = -1;

		public OrderAssignsForm()
		{
			InitializeComponent();
			_viewModel = new();
			_viewModel.ConfigureSettingsDGV(dgvOrderAssigns);
			_viewModel.SetDefaultDataSource(dgvOrderAssigns);
			SetDataSourceToComboBoxes();
			SetContextMenuStripItems();
			SetDefaultDates();
			SubscribeTable();
			SubscribeDictionaries();
			_viewModel.General.SetFormByRole(lblDepartment, cbDepartment, dgvOrderAssigns);
		}

		private void SubscribeTable()
		{
			OnTableUpdated += Form_OnTableUpdated;
			_viewModel.General.DatabaseNotificationService.Subscribe<OrderAssignsForm>("order_assign",
				data =>
				{
					RefreshData<OrderAssign>(_viewModel.General.OrderAssigns,
					value => _viewModel.General.OrderAssigns = value, data,
					() => _viewModel.SetDefaultDataSource(dgvOrderAssigns));

				});
		}

		private void Form_OnTableUpdated(object? sender, EventArgs e)
		{
			SetDataSourceToComboBoxes();
		}

		private void SubscribeDictionaries()
		{
			OnTableUpdated += Form_OnTableUpdated;

			_viewModel.General.DatabaseNotificationService.Subscribe<OrderAssignsForm>("post",
				data =>
				{
					RefreshDataSimple<Post>(
					value => _viewModel.General.Posts = value, _viewModel.General);

				});

			_viewModel.General.DatabaseNotificationService.Subscribe<OrderAssignsForm>("department",
				data =>
				{
					RefreshDataSimple<Department>(
					value => _viewModel.General.Departments = value, _viewModel.General);

				});
		}

		private void SetContextMenuStripItems()
		{
			contextMenuStrip1.Items.Add("Показать сотрудника", null,
				(s, e) => ShowEmployee());

			contextMenuStrip1.Items.Add("-");

			contextMenuStrip1.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvOrderAssigns.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
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

		/// <summary>
		/// Вызов поиска приказов назначения
		/// </summary>
		/// <param name="strParams">Обязательны следующие параметры: DepartmentName, EmployeeName
		/// <para>При отсутствии какого-либо параметра необходимо проставить string.Empty</para>
		/// </param>
		internal void SearchOrderAssignFromOtherForm(string[] strParams, Guid idEmployee)
		{
			if (cbDepartment.Visible)
				cbDepartment.SelectedIndex = cbDepartment.FindStringExact(strParams[0]);
			tbName.Text = strParams[1];
			SearchOrderAssigns(idEmployee);
		}

		private async void SearchOrderAssigns(Guid? idEmployee = null)
		{
			List<OrderAssign>? results = await _viewModel.SearchOrderAssignAsync(
				tbName.Text, tbAddress.Text,
				[
								((ComboBoxItem)(cbPost.SelectedItem ?? new ComboBoxItem())).Id,
								((ComboBoxItem)(cbDepartment.SelectedItem ?? new ComboBoxItem())).Id],
			[
								DateOnly.FromDateTime(dtpDateAssignMin.Value.Date),
								DateOnly.FromDateTime(dtpDateAssignMax.Value.Date)],
					idEmployee);

			if (results == null) return;

			if (results.Count == 0)
			{
				MessageBox.Show("Назначение не найдено", "Поиск назначения",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			dgvOrderAssigns.DataSource = new SortableBindingList<OrderAssignWrapper>(
		OrderAssignWrapper.ToList(results, _viewModel));
			btnResetSearch.Enabled = true;
		}

		private void SetDefaultDates()
		{
			DateOnly[] dates = _viewModel.GetMinMaxDatesAssign();
			if (dates.Length == 0) return;

			dtpDateAssignMin.Value = new(dates[0], new TimeOnly());
			dtpDateAssignMax.Value = new(dates[1], new TimeOnly());
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchOrderAssigns();
		}

		private void btnResetSearch_Click(object sender, EventArgs e)
		{
			_viewModel.SetDefaultDataSource(dgvOrderAssigns);
			btnResetSearch.Enabled = false;
		}

		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (sender is DataGridView && e.RowIndex != -1)
			{
				_indexRow = e.RowIndex;
				_indexCell = e.ColumnIndex;
				dgvOrderAssigns.Rows[e.RowIndex].Selected = true;
			}
		}

		private void ShowEmployee()
		{
			EmployeesForm? ef = _viewModel.General.GetActivatedForm<EmployeesForm>();

			if (ef == null)
			{
				ef = new();
				ef.Show();
			}

			DataGridViewCellCollection row = dgvOrderAssigns.SelectedRows[0].Cells;

			Guid idEmployee = new(row["IdEmployee"].Value.ToString() ?? "");
			string departmentName = row["Department"].Value.ToString() ?? "";
			string employeeName = string.Concat(
				row["Surname"].Value.ToString() ?? "", " ",
				row["Name"].Value.ToString() ?? "", " ",
				row["Patronymic"].Value.ToString() ?? "");

			ef.SearchEmployeeFromOtherForm([departmentName, employeeName], idEmployee);
		}
	}
}
