using Apteka.Registration.Model;

namespace Apteka.Registration.ViewModel
{
	internal class RegViewModel
	{
		private readonly RegModel _model;

		internal RegViewModel()
		{
			_model = new();
		}

		/// <summary>
		/// Проверяет логин и пароль на наличие и соответсствие в БД
		/// </summary>
		/// <param name="login">Логин пользователя</param>
		/// <param name="password">Пароль пользователя</param>
		/// <exception cref="ArgumentException"></exception>
		public void CheckEntry(string login, string password)
		{
			login = login.Trim();
			password = password.Trim();

			if (login == "" || password == "")
				throw new ArgumentException("Пустые поля");

			if (!_model.Users.ContainsKey(login))
				throw new ArgumentException("Неверный пароль или логин");

			_model.Users.TryGetValue(login, out string? value);
			if (value != password)
				throw new ArgumentException("Неверный пароль или логин");
		}
	}
}
