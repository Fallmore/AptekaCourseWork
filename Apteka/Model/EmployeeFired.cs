using Apteka.BaseClasses;
using Apteka.ViewModel.EmployeeVM;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class EmployeeFired : UnionId
{
	public override object GetId() => IdEmployee;

	public Guid IdEmployee { get; set; }

	public DateOnly DateFired { get; set; }

	public string Reason { get; set; } = null!;

	public virtual Employee IdEmployeeNavigation { get; set; } = null!;
}

internal class EmployeeFiredWrapper
{
	public Guid IdEmployee { get; set; }

	public int IdPost { get; set; }

	public int IdDepartment { get; set; }

	[Display(Name = "Дата увольнения")]
	public DateOnly DateFired { get; set; }

	[Display(Name = "Причина")]
	public string Reason { get; set; } = null!;

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

	public EmployeeFiredWrapper(EmployeeFired ef, EmployeeFiredViewModel evm)
	{
		Employee e = evm.GetEmployee(ef.IdEmployee).First();
		IdEmployee = e.IdEmployee;
		IdPost = e.IdPost;
		IdDepartment = e.IdDepartment;
		DateFired = ef.DateFired;
		Reason = ef.Reason;
		Surname = e.Surname;
		Name = e.Name;
		Patronymic = e.Patronymic;
		Address = e.Address;
		Birthday = e.Birthday;
		Department = evm.GetDepartment(e.IdDepartment).First().Name;
		Post p = evm.GetPost(e.IdPost).First();
		Post = p.Name;
	}

	internal static List<EmployeeFiredWrapper> ToList(List<EmployeeFired> e, EmployeeFiredViewModel evm)
	{
		List<EmployeeFiredWrapper> ew = [];

		foreach (EmployeeFired ef in e)
		{
			ew.Add(new EmployeeFiredWrapper(ef, evm));
		}

		return ew;
	}
}
