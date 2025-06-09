using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Npgsql;

namespace Apteka.ViewModel.EmployeeVM

{
	internal class EmployeeViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public EmployeeViewModel()
		{
			_general = GeneralViewModel.Instance;
		}

		/// <summary>
		/// Привязка данных сотрудников к источникам данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDefaultDataSource(DataGridView dgv)
		{
			List<Employee> currentEmployees = GetCurrentEmployees(_general.Employees);

			if (_general.ChoosedRole != (int)Roles.Директор)
				currentEmployees = currentEmployees
					.Where(l => l.IdDepartment == EmployeeAccountViewModel.GetCurrentDepartment())
					.ToList();

			dgv.DataSource = new SortableBindingList<EmployeeWrapper>(
				EmployeeWrapper.ToList(currentEmployees, this));

			if (dgv.Columns.Contains("IdDepartment"))
				dgv.Columns["IdDepartment"].Visible =
				dgv.Columns["IdEmployee"].Visible =
				dgv.Columns["IdPost"].Visible = false;
		}

		/// <summary>
		/// Настраивает таблицу под вывод данных сотрудников
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGV(DataGridView dgv)
		{
			_general.SetDefaultSettingsToDGV(dgv);
			_general.ConfigureGrid<EmployeeWrapper>(dgv);
		}

		/// <summary>
		/// Поиск сотрудников
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="employee"></param>
		/// <param name="doParams">Обязательны следующие параметры: DateBirthMin, DateBirthMax</param>
		/// <param name="idEmployee"></param>
		/// <returns></returns>
		internal async Task<List<Employee>?> SearchEmployeeAsync(Employee employee, DateOnly[] doParams)
		{
			try
			{
				List<Employee> results = await _general.AptekaContext.Employees
					.FromSqlRaw("SELECT * FROM search_employees_trgm({0}, {1}, {2}, {3}, {4}," +
					"{5}, {6});",
					(employee.IdEmployee == new Guid() ? null : employee.IdEmployee),
					employee.Name, employee.Address,
					employee.IdPost, employee.IdDepartment, doParams[0], doParams[1])
					.AsNoTracking()
					.ToListAsync();

				return results;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск сотрудника",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		internal List<Employee> GetCurrentEmployees(List<Employee> employees)
		{
			return employees
				.Where(e => _general.EmployeeFireds.Any(f => f.IdEmployee != e.IdEmployee)
					&& _general.EmployeeAccounts.Any(ea => !ea.Roles.Contains((int)Roles.Директор)
							&& ea.IdEmployee == e.IdEmployee))
				.ToList();
		}

		internal SortableBindingList<EmployeeWrapper> GetDepartmentManagers()
		{
			List<Employee> currentManagers = GetCurrentEmployees(_general.Employees)
				.Where(e => _general.EmployeeAccounts
					.Any(ea => ea.Roles.Contains((int)Roles.УправляющийОтдела)
						&& ea.IdEmployee == e.IdEmployee))
				.ToList();
			return new SortableBindingList<EmployeeWrapper>(
				EmployeeWrapper.ToList(currentManagers, this));
		}

		internal DateOnly[] GetMinMaxDatesBirth()
		{
			List<Employee> employees = _general.Employees;
			DateOnly[] results = [];

			if (employees.Count != 0)
				results =
			   [
				   employees.Min(e => e.Birthday),
					employees.Max(e => e.Birthday),
				];

			return results;
		}

		internal List<Department> GetDepartment(int? idDepartment = null)
		{
			if (idDepartment == null)
				return _general.Departments;
			else
				return _general.Departments
				.Where(d => d.IdDepartment == idDepartment)
				.ToList();
		}

		internal List<Post> GetPost(int? idPost = null)
		{
			if (idPost == null)
				return _general.Posts;
			else
				return _general.Posts
				.Where(d => d.IdPost == idPost)
				.ToList();
		}

		internal bool InsertOrderAssign(int idOrder, Guid idEmployee, int idNewPost, string reason)
		{
			try
			{
				General.AptekaContext.Database
					.ExecuteSqlRaw("CALL employee_assign_order({0}, {1}, {2}, {3})",
				idOrder, idEmployee, idNewPost, reason);
				return true;
			}
			catch (PostgresException ex)
			{
				string message = ex.Message;

				if (ex.ConstraintName == "order_assign_pkey")
					message = "Ошибка! Такой номер приказа уже существует! Пожалуйста, введите новый";

				MessageBox.Show(message, "Ошибка данных",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		internal bool InsertEmployeeFired(Guid idEmployee, string reason)
		{
			try
			{
				General.AptekaContext.Database
					.ExecuteSqlRaw("INSERT INTO employee_fired (id_employee, reason) " +
					"VALUES ({0}, {1})", idEmployee, reason);
				return true;
			}
			catch (PostgresException ex)
			{
				string message = ex.Message;

				if (ex.ConstraintName == "empty_reason")
					message = "Ошибка! Причина обязательно должна быть написана!";

				MessageBox.Show(message, "Ошибка данных",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		internal bool ControlPrivileges(int[] roles, Guid idEmployee)
		{
			try
			{
				General.AptekaContext.Database
					.ExecuteSqlRaw("CALL control_privileges({0}, {1});",
					roles, idEmployee);
				return true;
			}
			catch (PostgresException ex)
			{
				string message = ex.Message;

				MessageBox.Show(message, "Ошибка данных",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
	}
}
