using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Apteka.ViewModel

{
	internal class EmployeeFiredViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public EmployeeFiredViewModel()
		{
			_general = GeneralViewModel.Instance;
		}

		/// <summary>
		/// Привязка данных склада к источникам данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDefaultDataSource(DataGridView dgv)
		{
			dgv.DataSource = new SortableBindingList<EmployeeFiredWrapper>(
				EmployeeFiredWrapper.ToEmployeeFiredWrapper(_general.EmployeeFireds, this));
		}

		/// <summary>
		/// Обновляет данные склада таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void RefreshEmployees(DataGridView dgv)
		{
			_general.LoadTableForWrite<EmployeeFired>();
			SetDefaultDataSource(dgv);
		}

		/// <summary>
		/// Настраивает таблицу под вывод данных склада
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGV(DataGridView dgv)
		{
			_general.SetDefaultSettingsToDGV(dgv);
			_general.ConfigureGrid<EmployeeFiredWrapper>(dgv);
		}

		/// <summary>
		/// Поиск продаж
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="name"></param>
		/// <param name="address"></param>
		/// <param name="intParams">Обязательны следующие параметры: IdDepartment, IdPost</param>
		/// <param name="doParams">Обязательны следующие параметры: DateBirthMin, DateBirthMax,
		/// DateFireMin, DateFireMax</param>
		/// <param name="idEmployee"></param>
		/// <returns></returns>
		internal async Task<bool> SearchEmployeeAsync(DataGridView dgv, string name, string address, int[] intParams,
			DateOnly[] doParams, Guid? idEmployee)
		{
			try
			{
				List<Guid> subresults = await _general.AptekaContext.Database
					.SqlQueryRaw<Guid>("SELECT id_employee FROM search_employees_trgm({0}, {1}, {2}, {3}, {4}," +
					"{5}::timestamp, {6}::timestamp);", idEmployee, name, address,
					intParams[0], intParams[1], doParams[0], doParams[1])
					.ToListAsync();

				List<EmployeeFired> results = _general.EmployeeFireds
					.Where(ef => subresults.Any(e => e == ef.IdEmployee)
						&& ef.DateFired >= doParams[2]
						&& ef.DateFired <= doParams[3])
					.ToList();

				if (results.Count != 0)
				{
					dgv.DataSource = new SortableBindingList<EmployeeFiredWrapper>(
						EmployeeFiredWrapper.ToEmployeeFiredWrapper(results, this));
					return true;
				}
				else
				{
					MessageBox.Show("Уволенный сотрудник не найден", "Поиск уволенного сотрудника",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск уволенного сотрудника",
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

		internal DateOnly[] GetMinMaxDatesFire()
		{
			List<EmployeeFired> employeeFireds = _general.EmployeeFireds;
			DateOnly[] results = [];

			if (employeeFireds.Count != 0)
				results =
				[
					employeeFireds.Min(e => e.DateFired),
					employeeFireds.Max(e => e.DateFired),
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
				.Where(p => p.IdPost == idPost)
				.ToList();
		}

		internal List<Employee> GetEmployee(Guid? idEmployee = null)
		{
			if (idEmployee == null)
				return _general.Employees;
			else
				return _general.Employees
				.Where(e => e.IdEmployee == idEmployee)
				.ToList();
		}
	}
}
