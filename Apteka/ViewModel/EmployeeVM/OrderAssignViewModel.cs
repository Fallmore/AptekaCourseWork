using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Apteka.ViewModel.EmployeeVM
{
	internal class OrderAssignViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public OrderAssignViewModel()
		{
			_general = GeneralViewModel.Instance;
		}

		/// <summary>
		/// Привязка данных склада к источникам данных таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDefaultDataSource(DataGridView dgv)
		{
			dgv.DataSource = new SortableBindingList<OrderAssignWrapper>(
				OrderAssignWrapper.ToOrderAssignWrapper(_general.OrderAssigns, this));

			if (dgv.Columns.Contains("IdDepartment"))
				dgv.Columns["IdDepartment"].Visible =
				dgv.Columns["IdEmployee"].Visible =
				dgv.Columns["IdOldPost"].Visible =
				dgv.Columns["IdNewPost"].Visible = false;
		}

		/// <summary>
		/// Обновляет данные склада таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void RefreshEmployees(DataGridView dgv)
		{
			_general.LoadTableForWrite<OrderAssign>();
			SetDefaultDataSource(dgv);
		}

		/// <summary>
		/// Настраивает таблицу под вывод данных склада
		/// </summary>
		/// <param name="dgv"></param>
		internal void ConfigureSettingsDGV(DataGridView dgv)
		{
			_general.SetDefaultSettingsToDGV(dgv);
			_general.ConfigureGrid<OrderAssignWrapper>(dgv);
		}

		/// <summary>
		/// Поиск продаж
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="name"></param>
		/// <param name="address"></param>
		/// <param name="intParams">Обязательны следующие параметры: IdPost, IdDepartment</param>
		/// <param name="doParams">Обязательны следующие параметры: DateAssignMin, DateAssignMax</param>
		/// <param name="idEmployee"></param>
		/// <returns></returns>
		internal async Task<List<OrderAssign>?> SearchOrderAssignAsync(string name, string address, int[] intParams,
			DateOnly[] doParams, Guid? idEmployee)
		{
			try
			{
				List<Guid> subresults = await _general.AptekaContext.Database
					.SqlQueryRaw<Guid>("SELECT id_employee FROM search_employees_trgm({0}, {1}, {2}, {3}, {4});",
					idEmployee, name, address,
					intParams[0], intParams[1])
					.ToListAsync();

				List<OrderAssign> results = _general.OrderAssigns
					.Where(ef => subresults.Any(e => e == ef.IdEmployee)
						&& ef.DateAssign >= doParams[0]
						&& ef.DateAssign <= doParams[1])
					.ToList();

				return results;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска: {ex.Message}", "Поиск назначения",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		internal DateOnly[] GetMinMaxDatesAssign()
		{
			List<OrderAssign> orderAssign = _general.OrderAssigns;
			DateOnly[] results = [];

			if (orderAssign.Count != 0)
				results = [
					orderAssign.Min(e => e.DateAssign),
					orderAssign.Max(e => e.DateAssign)];

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
