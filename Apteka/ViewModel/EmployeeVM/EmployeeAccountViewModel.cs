using Apteka.Model;
using Apteka.Properties;
using Apteka.Properties.DataSources;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Apteka.ViewModel.EmployeeVM
{
	internal class EmployeeAccountViewModel
	{
		private static readonly GeneralViewModel _general = GeneralViewModel.Instance;

		internal static GeneralViewModel General => _general;

		public EmployeeAccountViewModel() { }

		internal static List<EmployeeRole> GetRoles(Guid idEmployee)
		{
			List<int> idRoles = _general.EmployeeAccounts
				.Where(ea => ea.IdEmployee == idEmployee)
				.Select(ea => ea.Roles)
				.First().ToList();
			return _general.EmployeeRoles
				.Where(er => idRoles.Contains(er.IdRole))
				.ToList();
		}

		internal static Guid GetCurrentEmployee()
		{
			return _general.AptekaContext.Database
				.SqlQueryRaw<Guid>("SELECT * FROM get_current_employee() as Value", 0)
				.AsEnumerable()
				.First();
		}

		internal static int GetCurrentDepartment()
		{
			return _general.AptekaContext.Database
				.SqlQueryRaw<int>("SELECT * FROM get_current_department() as Value", 0)
				.AsEnumerable()
				.First();
		}

		internal static bool InsertAccount(EmployeeAccount e)
		{
			try
			{
				AptekaContext _localContext = AptekaContextFactory
					.Create(_general.MainUsername, _general.MainPassword);
				_localContext.Database
						.ExecuteSqlRaw("INSERT INTO employee_account (id_employee, login, password, roles) " +
						"VALUES ({0}, {1}, {2}, {3})",
						e.IdEmployee, e.Login, e.Password, e.Roles);
				return true;
			}
			catch (PostgresException ex)
			{
				string? message = ex.Message.Split(':').Skip(1).FirstOrDefault()?.Trim();

				if ((ex.ConstraintName ?? "").Contains("empty"))
					message = "Ошибка! Пустые поля, пожалуйста, заполните все поля!";

				MessageBox.Show(message, "Ошибка данных",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
	}
}
