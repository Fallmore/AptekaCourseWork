using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Npgsql;

namespace Apteka.ViewModel.EmployeeVM
{
	internal class EmployeeDataViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public EmployeeDataViewModel()
		{
			_general = GeneralViewModel.Instance;
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

		internal bool UpSertEmployee(Employee e)
		{
			try
			{
				if (e.IdEmployee == new Guid())
				{
					e.IdEmployee = General.AptekaContext.Database
						.SqlQueryRaw<Guid>("INSERT INTO employee (surname, name, patronymic, address, " +
						"birthday, id_post, id_department) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}) " +
						"RETURNING id_employee",
						e.Surname, e.Name, e.Patronymic, e.Address,
						e.Birthday, e.IdPost, e.IdDepartment).AsEnumerable().First();
				}
				else
				{
					General.AptekaContext.Database
						.ExecuteSqlRaw("UPDATE employee " +
						"SET (surname, name, patronymic, address, " +
						"birthday, id_post, id_department) = ({0}, {1}, {2}, {3}, {4}, {5}, {6}) " +
						"WHERE id_employee = {7}",
						e.Surname, e.Name, e.Patronymic, e.Address,
					e.Birthday, e.IdPost, e.IdDepartment, e.IdEmployee);
				}
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
