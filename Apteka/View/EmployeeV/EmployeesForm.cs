using Apteka.BaseClasses;
using Apteka.Model;
using Apteka.View.SimpleV;
using Apteka.ViewModel;
using Apteka.ViewModel.EmployeeVM;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Data;

namespace Apteka.View.EmployeeV
{
	public partial class EmployeesForm : FormWithNotification
	{
		private EmployeeViewModel _viewModel;
		private int _indexRow = -1,
			_indexCell = -1;

		public EmployeesForm()
		{
			InitializeComponent();
			_viewModel = new();
			_viewModel.ConfigureSettingsDGV(dgvEmployees);
			_viewModel.SetDefaultDataSource(dgvEmployees);
			SetDataSourceToComboBoxes();
			SetContextMenuStripItems();
			SetDefaultDates();
			SubscribeTable();
			SubscribeDictionaries();
		}

		private void SubscribeTable()
		{
			OnTableUpdated += Form_OnTableUpdated;
			_viewModel.General.DatabaseNotificationService.Subscribe<EmployeesForm>("employee",
				data =>
				{
					RefreshData<Employee>(_viewModel.General.Employees,
					value => _viewModel.General.Employees = value,
					 data, () => _viewModel.SetDefaultDataSource(dgvEmployees));
				});
		}

		private void Form_OnTableUpdated(object? sender, EventArgs e)
		{
			SetDataSourceToComboBoxes();
		}

		private void SubscribeDictionaries()
		{
			//OnTableUpdated += Form_OnTableUpdated;

			_viewModel.General.DatabaseNotificationService.Subscribe<EmployeesForm>("post",
				data =>
				{
					RefreshDataSimple<Post>(
					value =>
					{
						_viewModel.General.Posts = value;
						cbDepartment.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetDepartment(), new())
							.Select(d => new ComboBoxItem { Name = d.Name, Id = d.IdDepartment }).OrderBy(cbi => cbi.Name).ToList();
					}, _viewModel.General);

				});

			_viewModel.General.DatabaseNotificationService.Subscribe<EmployeesForm>("department",
				data =>
				{
					RefreshDataSimple<Department>(
					value =>
					{
						_viewModel.General.Departments = value;
						cbPost.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetPost(), new())
							.Select(d => new ComboBoxItem { Name = d.Name, Id = d.IdPost }).OrderBy(cbi => cbi.Name).ToList();
					}, _viewModel.General);

				});

			_viewModel.General.DatabaseNotificationService.Subscribe<EmployeesForm>("employee_account",
				data =>
				{
					RefreshDataSimple<EmployeeAccount>(
					value => _viewModel.General.EmployeeAccounts = value,
					_viewModel.General);

				});
		}

		private void SetContextMenuStripItems()
		{
			contextMenuStrip1.Items.Add("Изменить данные", null,
				(s, e) => ChangeData());

			contextMenuStrip1.Items.Add("-");

			contextMenuStrip1.Items.Add("Показать назначения", null,
				(s, e) => ShowOrderAssign());

			contextMenuStrip1.Items.Add("Показать роли", null,
				(s, e) => ShowRoles());

			contextMenuStrip1.Items.Add("Назначить должность", null,
				(s, e) => AssignOrder());

			contextMenuStrip1.Items.Add("Подтвердить увольнение", null,
				(s, e) => Fire());

			contextMenuStrip1.Items.Add("-");

			contextMenuStrip1.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvEmployees.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
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
		/// Вызов поиска сотрудников
		/// </summary>
		/// <param name="strParams">Обязательны следующие параметры: DepartmentName, EmployeeName
		/// <para>При отсутствии какого-либо параметра необходимо проставить string.Empty</para>
		/// </param>
		internal void SearchEmployeeFromOtherForm(string[] strParams, Guid idEmployee)
		{
			if (cbDepartment.Visible)
				cbDepartment.SelectedIndex = cbDepartment.FindStringExact(strParams[0]);
			tbName.Text = strParams[1];
			SearchEmployee(idEmployee);
		}

		private async void SearchEmployee(Guid? idEmployee = null)
		{
			Employee employee = new()
			{
				IdEmployee = idEmployee ?? new Guid(),
				Name = tbName.Text,
				Address = tbAddress.Text,
				IdPost = ((ComboBoxItem)(cbPost.SelectedItem ?? new ComboBoxItem())).Id,
				IdDepartment = ((ComboBoxItem)(cbDepartment.SelectedItem ?? new ComboBoxItem())).Id
			};

			List<Employee>? results = await _viewModel.SearchEmployeeAsync(
				 employee, [
								DateOnly.FromDateTime(dtpDateBirthMin.Value.Date),
								DateOnly.FromDateTime(dtpDateBirthMax.Value.Date)]);

			if (results == null) return;

			if (results.Count == 0)
			{
				MessageBox.Show("Сотрудник не найден", "Поиск сотрудника",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			dgvEmployees.DataSource = new SortableBindingList<EmployeeWrapper>(
				EmployeeWrapper.ToEmployeeWrapper(results, _viewModel));
			btnResetSearch.Enabled = true;
		}

		private void SetDefaultDates()
		{
			DateOnly[] dates = _viewModel.GetMinMaxDatesBirth();
			if (dates.Length == 0) return;

			dtpDateBirthMin.Value = new(dates[0], new TimeOnly());
			dtpDateBirthMax.Value = new(dates[1], new TimeOnly());
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchEmployee();
		}

		private void btnResetSearch_Click(object sender, EventArgs e)
		{
			_viewModel.SetDefaultDataSource(dgvEmployees);
			btnResetSearch.Enabled = false;
		}

		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (sender is DataGridView && e.RowIndex != -1)
			{
				_indexRow = e.RowIndex;
				_indexCell = e.ColumnIndex;
				dgvEmployees.Rows[e.RowIndex].Selected = true;
			}
		}

		private void ChangeData()
		{

			DataGridViewCellCollection cells = dgvEmployees.SelectedRows[0].Cells;
			Guid idEmployee = new(cells["IdEmployee"].Value.ToString() ?? "");
			Employee e = _viewModel.General.Employees.Where(e => e.IdEmployee == idEmployee).First();

			EmployeesDataForm? edf = new(e);
			edf.ShowDialog();
		}

		private void ShowOrderAssign()
		{
			OrderAssignsForm? oaf = _viewModel.General.GetActivatedForm<OrderAssignsForm>();

			if (oaf == null)
			{
				oaf = new();
				oaf.Show();
			}

			DataGridViewCellCollection cells = dgvEmployees.SelectedRows[0].Cells;

			Guid idEmployee = new(cells["IdEmployee"].Value.ToString() ?? "");
			string departmentName = cells["Department"].Value.ToString() ?? "";
			string employeeName = string.Concat(
				cells["Surname"].Value.ToString() ?? "", " ",
				cells["Name"].Value.ToString() ?? "", " ",
				cells["Patronymic"].Value.ToString() ?? "");

			oaf.SearchOrderAssignFromOtherForm([departmentName, employeeName], idEmployee);
		}

		private void ShowRoles()
		{
			EmployeeRolesForm erf = new();
			DataGridViewCellCollection cells = dgvEmployees.SelectedRows[0].Cells;
			Guid idEmployee = Guid.Parse(cells["IdEmployee"].Value.ToString() ?? "");

			List<int>? employeeRoles = _viewModel.General.EmployeeAccounts
				.Where(ea => ea.IdEmployee == idEmployee)
				.FirstOrDefault()?.Roles;

			if (employeeRoles == null) return;

			foreach (int role in employeeRoles)
				erf.clbRoles.SetItemChecked(role - 1, true);

			// Отключаем взаимодействие с 1м элементом
			erf.clbRoles.ItemCheck += (sender, e) =>
			{
				if (e.Index == 0)
					e.NewValue = e.CurrentValue;
			};

			erf.StartPosition = FormStartPosition.Manual;
			erf.Location = new Point(Cursor.Position.X - erf.Width / 4, Cursor.Position.Y - erf.Height / 2);

			if (erf.ShowDialog() == DialogResult.OK)
			{
				int[] idRoles = erf.clbRoles.CheckedIndices.Cast<int>().ToList()
					.Select(index => ++index).ToArray();
				_viewModel.ControlPrivileges(idRoles, idEmployee);
			}
		}

		internal void ShowDepartmentManagers()
		{
			dgvEmployees.DataSource = _viewModel.GetDepartmentManagers();
			btnResetSearch.Enabled = true;
		}

		private void AssignOrder(string post = "", string numberOrder = "", string reason = "")
		{
			AssignForm af = new();

			DataGridViewCellCollection cells = dgvEmployees.SelectedRows[0].Cells;
			string? postName = cells["Post"].Value.ToString();
			Guid idEmployee = Guid.Parse(cells["IdEmployee"].Value.ToString() ?? "");

			setValues();

			if (af.ShowDialog(Owner) == DialogResult.OK)
			{
				if (af.tbNumberOrder.Text == "" || af.rtbReason.Text == "")
				{
					MessageBox.Show("Пожалуйста, заполните все поля!", "Пустые поля",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					af.Close();
					AssignOrder(af.cbNewPost.Text, af.tbNumberOrder.Text, af.rtbReason.Text);
					return;
				}


				bool isSuccess = _viewModel.InsertOrderAssign(int.Parse(af.tbNumberOrder.Text),
					idEmployee,
					int.Parse(af.cbNewPost.SelectedValue.ToString() ?? ""),
					af.rtbReason.Text);

				if (!isSuccess)
					AssignOrder(af.cbNewPost.Text, af.tbNumberOrder.Text, af.rtbReason.Text);
			}

			void setValues()
			{
				af.cbNewPost.DataSource = _viewModel.General.Posts
				.Where(p => p.Name != postName)
				.Select(d => new ComboBoxItem { Name = d.Name, Id = d.IdPost })
				.OrderBy(cbi => cbi.Name).ToList();
				af.cbNewPost.ValueMember = "Id";
				af.cbNewPost.DisplayMember = "Name";

				if (numberOrder != "" || reason != "" || post != "")
				{
					af.tbNumberOrder.Text = numberOrder;
					af.rtbReason.Text = reason;
					af.cbNewPost.SelectedIndex = af.cbNewPost.FindStringExact(post);
				}
			}
		}

		private void Fire()
		{
			DataGridViewCellCollection cells = dgvEmployees.SelectedRows[0].Cells;
			ReasonForm rf = new();

			Guid idEmployee = new(cells["IdEmployee"].Value.ToString() ?? string.Empty);
			string employeeName = string.Concat(
				cells["Surname"].Value.ToString() ?? "", " ",
				cells["Name"].Value.ToString() ?? "", " ",
				cells["Patronymic"].Value.ToString() ?? "");
			rf.Text = "Причина увольнения " + employeeName;

			if (rf.ShowDialog() == DialogResult.OK)
			{
				if (!_viewModel.InsertEmployeeFired(idEmployee, rf.rtbReason.Text))
					Fire();
			}
		}
	}
}
