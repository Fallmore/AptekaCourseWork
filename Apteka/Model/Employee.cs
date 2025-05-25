using Apteka.BaseClasses;
using Apteka.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class Employee : UnionId
{
	public override object GetId() => IdEmployee;

	public Guid IdEmployee { get; set; }

	public string Surname { get; set; } = null!;

	public string Name { get; set; } = null!;

	public string Patronymic { get; set; } = null!;

	public string Address { get; set; } = null!;

	public DateOnly Birthday { get; set; }

	public int IdPost { get; set; }

	public int IdDepartment { get; set; }

	public virtual ICollection<HistorySale> HistorySales { get; set; } = new List<HistorySale>();

	public virtual Department IdDepartmentNavigation { get; set; } = null!;

	public virtual Post IdPostNavigation { get; set; } = null!;

	public virtual ICollection<OrderAssign> OrderAssigns { get; set; } = new List<OrderAssign>();

	public virtual ICollection<Waybill> Waybills { get; set; } = new List<Waybill>();
}

internal class EmployeeWrapper
{
	public Guid IdEmployee { get; set; }

	public int IdPost { get; set; }

	public int IdDepartment { get; set; }

	[Display(Name = "Фамилия")]
	public string Surname { get; set; }

	[Display(Name = "Имя")]
	public string Name { get; set; }

	[Display(Name = "Отчество")]
	public string Patronymic { get; set; }

	[Display(Name = "Адрес")]
	public string Address { get; set; }

	[Display(Name = "День Рождения")]
	public DateOnly Birthday { get; set; }

	[Display(Name = "Отдел")]
	public string Department { get; set; }

	[Display(Name = "Должность")]
	public string Post { get; set; }

	[Display(Name = "Оклад")]
	public float Salary { get; set; }

	public EmployeeWrapper(Employee e, EmployeeViewModel evm)
	{
		IdEmployee = e.IdEmployee;
		IdPost = e.IdPost;
		IdDepartment = e.IdDepartment;
		Surname = e.Surname;
		Name = e.Name;
		Patronymic = e.Patronymic;
		Address = e.Address;
		Birthday = e.Birthday;
		Department = evm.GetDepartment(e.IdDepartment).First().Name;
		Post p = evm.GetPost(e.IdPost).First();
		Post = p.Name;
		Salary = p.Salary;
	}

	internal static List<EmployeeWrapper> ToEmployeeWrapper(List<Employee> e, EmployeeViewModel evm)
	{
		List<EmployeeWrapper> ew = [];

		foreach (Employee mp in e)
		{
			ew.Add(new EmployeeWrapper(mp, evm));
		}

		return ew;
	}
}
