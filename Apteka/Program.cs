using Apteka.Properties;
using Apteka.View.LoginV;
using Apteka.View.RegistrationV;
using Apteka.ViewModel;

namespace Apteka
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			if (!Init()) return;
			Application.Run(new LoginForm());
			GeneralViewModel.Instance.DatabaseNotificationService.Dispose();
		}

		private static bool Init()
		{
			GeneralViewModel.Instance.Initialize();
			while (!AptekaContextFactory.CanConnect)
			{
				MessageBox.Show("Ошибка подключения к базе данных! " +
					"Обратитесь к администратору базы данных за помощью настройки подключения",
					"Подключение к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error);

				ConnectionParametersForm form = new();

				{
					form.tbHost.Text = Settings.Default.Host;
					form.tbDataBase.Text = Settings.Default.Database;
					form.tbUsername.Text = Settings.Default.Username;
					form.tbPassword.Text = Settings.Default.Password;
				}


				if (form.ShowDialog() == DialogResult.OK)
				{
					Settings.Default.Host = form.tbHost.Text;
					Settings.Default.Database = form.tbDataBase.Text;
					Settings.Default.Username = form.tbUsername.Text;
					Settings.Default.Password = form.tbPassword.Text;
					Settings.Default.Save();
				}
				else return false;
				GeneralViewModel.Instance.Initialize();
			}
			return true;
		}
	}
}