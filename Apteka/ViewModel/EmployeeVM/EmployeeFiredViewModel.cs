using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Apteka.ViewModel.EmployeeVM

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

			if (dgv.Columns.Contains("IdDepartment"))
				dgv.Columns["IdDepartment"].Visible =
				dgv.Columns["IdEmployee"].Visible =
				dgv.Columns["IdPost"].Visible = false;
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
		/// <param name="intParams">Обязательны следующие параметры: IdPost, IdDepartment</param>
		/// <param name="doParams">Обязательны следующие параметры: DateBirthMin, DateBirthMax,
		/// DateFireMin, DateFireMax</param>
		/// <param name="idEmployee"></param>
		/// <returns></returns>
		internal async Task<List<EmployeeFired>?> SearchEmployeeFiredAsync(string name, string address, int[] intParams,
			DateOnly[] doParams, Guid? idEmployee)
		{
			try
			{
				List<Guid> subresults = await _general.AptekaContext.Database
					.SqlQueryRaw<Guid>("SELECT id_employee FROM search_employees_trgm({0}, {1}, {2}, {3}, {4}," +
					"{5}, {6});", idEmployee, name, address,
					intParams[0], intParams[1], doParams[0], doParams[1])
					.ToListAsync();

				List<EmployeeFired> results = _general.EmployeeFireds
					.Where(ef => subresults.Any(e => e == ef.IdEmployee)
						&& ef.DateFired >= doParams[2]
						&& ef.DateFired <= doParams[3])
					.ToList();

				return results;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск уволенного сотрудника",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
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
