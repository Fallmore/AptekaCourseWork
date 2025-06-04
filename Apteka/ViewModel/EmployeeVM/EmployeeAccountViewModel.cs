using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Apteka.ViewModel.EmployeeVM
{
	internal class EmployeeAccountViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public EmployeeAccountViewModel()
		{
			_general = GeneralViewModel.Instance;
		}

		internal bool InsertAccount(EmployeeAccount e)
		{
			try
			{
				General.AptekaContext.Database
						.ExecuteSqlRaw("INSERT INTO employee_account (id_employee, login, password, roles) " +
						"VALUES ({0}, {1}, {2}, {3})",
						e.IdEmployee, e.Login, e.Password, e.Roles);
				return true;
			}
			catch (PostgresException ex)
			{
				string message = ex.Message;

				if ((ex.ConstraintName ?? "").Contains("empty"))
					message = "Ошибка! Пустые поля, пожалуйста, заполните все поля!";

				MessageBox.Show(message, "Ошибка данных",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
	}
}
