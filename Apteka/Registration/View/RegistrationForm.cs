using Apteka.Registration.ViewModel;

namespace Apteka.Registration.View
{
	public partial class RegistrationForm : Form
	{
		private readonly RegViewModel _viewModel;
		private bool _isGuest;

		public RegistrationForm()
		{
			InitializeComponent();
			_viewModel = new();
			_isGuest = false;
		}

		/// <summary>
		/// Входит в систему
		/// </summary>
		private void btnEntry_Click(object sender, EventArgs e)
		{
			try
			{
				if (!_isGuest)
				{
					// Проверяем логин и пароль с текстБоксов
					_viewModel.CheckEntry(tbLogin.Text, tbPassword.Text);

					MessageBox.Show("Авторизация прошла успешна", "Авторизация",
								  MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				// Создаём экзмпляр главного окна, скрываем окно регистрации
				// и запускаем диалог с главным окном.
				//MainMenu.View.MainForm mainForm = new();
				//if (_isGuest) mainForm.GuestForm();
				//Hide();
				//mainForm.ShowDialog();

				// После закрытия главного окна закрываем окно регистрации
				// для завершения работы программы
				Close();
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// В соответствии со значением checkbox
		/// изменяет параметры для входа
		/// </summary>
		private void chbQuest_CheckedChanged(object sender, EventArgs e)
		{
			tbLogin.Enabled = tbPassword.Enabled = !chbGuest.Checked;
			_isGuest = chbGuest.Checked;
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
