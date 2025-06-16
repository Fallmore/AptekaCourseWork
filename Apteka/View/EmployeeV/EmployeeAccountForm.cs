using Apteka.Model;
using Apteka.ViewModel.EmployeeVM;
using System.Data;

namespace Apteka.View.EmployeeV
{
	public partial class EmployeeAccountForm : Form
	{
		public EmployeeAccountForm()
		{
			InitializeComponent();
			TopMost = true;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (tbMatchPassword.Text != tbPassword.Text)
			{
				MessageBox.Show("Пароли не совпадают", "Ошибка данных",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				DialogResult = DialogResult.None;
				return;
			}

			EmployeeAccount ea = new()
			{
				IdEmployee = Guid.Parse(lblIdEmployee.Text),
				Login = tbLogin.Text,
				Password = tbPassword.Text,
			};

			ea.Roles = SetRoles();

			if (!EmployeeAccountViewModel.InsertAccount(ea))
				DialogResult = DialogResult.None;
		}

		private List<int> SetRoles()
		{
			EmployeeRolesForm erf = new();
			int[] idRoles;

			erf.clbRoles.SetItemChecked(0, true);

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
				idRoles = erf.clbRoles.CheckedIndices.Cast<int>().ToList()
					.Select(index => ++index).ToArray();
			}
			else idRoles = [1];

			return [.. idRoles];
		}
	}
}
