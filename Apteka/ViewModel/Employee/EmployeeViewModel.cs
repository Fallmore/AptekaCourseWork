using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Npgsql;

namespace Apteka.ViewModel

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
			var f = new SortableBindingList<EmployeeWrapper>(
				EmployeeWrapper.ToEmployeeWrapper(_general.Employees
				.Where(e => _general.EmployeeFireds.Any(f => f.IdEmployee != e.IdEmployee))
				.ToList(), this));
			dgv.DataSource = f;
		}


		/// <summary>
		/// Обновляет данные сотрудников таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void RefreshEmployees(DataGridView dgv)
		{
			try
			{
				SetDefaultDataSource(dgv);
			}
			catch (Exception ex)
			{
				var f = ex;
			}
			
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
		/// <param name="name"></param>
		/// <param name="intParams">Обязательны следующие параметры: IdDepartment, IdPost</param>
		/// <param name="doParams">Обязательны следующие параметры: DateBirthMin, DateBirthMax</param>
		/// <param name="idEmployee"></param>
		/// <returns></returns>
		internal async Task<bool> SearchEmployeeAsync(DataGridView dgv, string name, string address, int[] intParams,
			DateOnly[] doParams, Guid? idEmployee)
		{
			try
			{
				List<Employee> results = await _general.AptekaContext.Employees
					.FromSqlRaw("SELECT * FROM search_employees_trgm({0}, {1}, {2}, {3}, {4}," +
					"{5}::timestamp, {6}::timestamp);", idEmployee, name, address,
					intParams[0], intParams[1], doParams[0], doParams[1])
					.AsNoTracking()
					.ToListAsync();

				if (results.Count != 0)
				{
					dgv.DataSource = new SortableBindingList<EmployeeWrapper>(
						EmployeeWrapper.ToEmployeeWrapper(results, this));
					return true;
				}
				else
				{
					MessageBox.Show("Сотрудник не найден", "Поиск сотрудника",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск сотрудника",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
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
	}
}
