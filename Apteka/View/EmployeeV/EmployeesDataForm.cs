using Apteka.Model;
using Apteka.ViewModel;
using Apteka.ViewModel.EmployeeVM;

namespace Apteka.View.EmployeeV
{
	public partial class EmployeesDataForm : Form
	{
		private EmployeeDataViewModel _viewModel;


		public EmployeesDataForm()
		{
			Init();
		}

		public EmployeesDataForm(Employee e)
		{
			Init();
			SetEmployeeData(e);
		}

		private void Init()
		{
			InitializeComponent();
			_viewModel = new();
			SetDataSourceToComboBoxes();
			dtpBirthday.Value =
				dtpBirthday.MaxDate = DateTime.Now.AddYears(-18);
			if (_viewModel.General.ChoosedRole != (int)Roles.Директор)
			{
				cbDepartment.Enabled = false;
				cbDepartment.SelectedValue = EmployeeAccountViewModel.GetCurrentDepartment();
			}
		}

		private void SetEmployeeData(Employee e)
		{
			tbSurname.Text = e.Surname;
			tbName.Text = e.Name;
			tbPatronymic.Text = e.Patronymic;
			tbAddress.Text = e.Address;
			dtpBirthday.Value = new(e.Birthday, new());
			cbPost.SelectedIndex = e.IdPost - 1;

			if (_viewModel.General.ChoosedRole != (int)Roles.Директор)
				cbDepartment.SelectedValue = e.IdDepartment;

			string employeeName = string.Concat(e.Surname, " ",
				e.Name, " ", e.Patronymic);

			Text = "Изменение данных";
			lblData.Dock = DockStyle.Top;
			lblData.Text = employeeName;
			lblIdEmployee.Text = e.IdEmployee.ToString();
		}

		private void SetDataSourceToComboBoxes()
		{
			cbDepartment.DataSource = _viewModel.GetDepartment()
				.Select(d => new ComboBoxItem { Name = d.Name, Id = d.IdDepartment })
				.OrderBy(cbi => cbi.Id).ToList();

			cbPost.DataSource = _viewModel.GetPost()
				.Select(d => new ComboBoxItem { Name = d.Name, Id = d.IdPost })
				.OrderBy(cbi => cbi.Id).ToList();

			cbDepartment.DisplayMember =
			cbPost.DisplayMember = "Name";

			cbDepartment.ValueMember =
			cbPost.ValueMember = "Id";
		}

		private void TextBoxKeyPress(object sender, KeyPressEventArgs e)
		{
			// Разрешаем только буквы
			if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
			{
				e.Handled = true; // Блокируем ввод
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Employee employee = SetEmployeeData();

			if (!_viewModel.UpSertEmployee(employee))
			{
				DialogResult = DialogResult.None;
				return;
			}

			if (lblIdEmployee.Text == "")
			{
				if (ShowCreateAccount(employee))
				{
					MessageBox.Show("Пользователь успешно добавлен", "Добавление пользователя",
									MessageBoxButtons.OK, MessageBoxIcon.Error);
					Close();
				}
			}
		}

		private Employee SetEmployeeData()
		{
			Employee employee = new()
			{
				Surname = tbSurname.Text,
				Name = tbName.Text,
				Patronymic = tbPatronymic.Text,
				Address = tbAddress.Text,
				Birthday = DateOnly.FromDateTime(dtpBirthday.Value),
				IdPost = int.Parse(cbPost.SelectedValue.ToString()),
				IdDepartment = int.Parse(cbDepartment.SelectedValue.ToString())
			};

			if (lblIdEmployee.Text != "")
				employee.IdEmployee = Guid.Parse(lblIdEmployee.Text);

			return employee;
		}

		private bool ShowCreateAccount(Employee employee)
		{
			EmployeeAccountForm ea = new();
			ea.Text = "Создание аккаунта";
			ea.FormBorderStyle = FormBorderStyle.None;
			ea.lblIdEmployee.Text = employee.IdEmployee.ToString();
			return (ea.ShowDialog() == DialogResult.OK);
		}
	}
}
