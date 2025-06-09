using Apteka.View.MenuV;
using Apteka.ViewModel.LoginVM;
using Npgsql;

namespace Apteka.View.LoginV
{
	internal partial class LoginForm : Form
	{
		private readonly LoginViewModel _viewModel;

		public LoginForm()
		{
			_viewModel = new();
			InitializeComponent();
		}

		/// <summary>
		/// Входит в систему
		/// </summary>
		private void btnEntry_Click(object sender, EventArgs e)
		{
			try
			{
				// Проверяем логин и пароль
				string hashPassword = _viewModel.CheckEnter(tbLogin.Text, tbPassword.Text);
				string login = "apteka_u_" + tbLogin.Text;
				_viewModel.General.SetUserConnection(login, hashPassword);

				ChooseRoleForm crm = new();
				Form launchForm = new();
				if (crm.ShowDialog() == DialogResult.OK)
				{
					_viewModel.General.ChoosedRole = crm.ChoosedRole;
					switch (crm.ChoosedRole)
					{
						case 1:
						case 3:
						case 4:
							launchForm = new OnlyMenuForm();
							break;
						case 2:
							launchForm = new Касса();
							break;
					}
				}
				else
				{
					_viewModel.ExitAccount();
					return;
				}
				// Создаём экзмпляр главного окна, скрываем окно регистрации
				// и запускаем диалог с главным окном.
				Hide();
				launchForm.ShowDialog();

				// После закрытия главного окна закрываем окно регистрации
				// для завершения работы программы
				_viewModel.ExitAccount();
				Close();
			}
			catch (NpgsqlException ex)
			{
				MessageBox.Show(ex.Message.Split(':').Skip(1).FirstOrDefault()?.Trim(),
					"Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// При нажатии enter - производит событие входа в систему
		/// </summary>
		private void RegistrationForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnEntry.PerformClick();
			}
		}
	}
}
