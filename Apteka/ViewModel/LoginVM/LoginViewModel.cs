using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Apteka.ViewModel.LoginVM
{
	internal class LoginViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public LoginViewModel()
		{
			_general = GeneralViewModel.Instance;
		}

		/// <summary>
		/// Проверяет логин и пароль на наличие и соответсствие в БД
		/// </summary>
		/// <param name="login">Логин пользователя</param>
		/// <param name="password">Пароль пользователя</param>
		/// <exception cref="NpgsqlException"></exception>
		internal string CheckEnter(string login, string password)
		{
			login = login.Trim();
			password = password.Trim();
			return _general.AptekaContext.Database
				.SqlQueryRaw<string>("SELECT * FROM check_enter_in_employee_account({0}, {1}) as Value",
				login, password)
				.AsEnumerable()
				.First();
		}

		internal void ExitAccount()
		{
			_general.AptekaContext.Database
				.ExecuteSql($"CALL log_out_employee_account()");
		}
	}
}
