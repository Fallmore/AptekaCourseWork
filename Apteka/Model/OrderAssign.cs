using Apteka.BaseClasses;
using Apteka.ViewModel.EmployeeVM;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class OrderAssign : UnionId
{
	public override object GetId() => IdOrder;

	public int IdOrder { get; set; }

	public Guid IdEmployee { get; set; }

	public int IdOldPost { get; set; }

	public int IdNewPost { get; set; }

	public string Reason { get; set; } = null!;

	public DateOnly DateAssign { get; set; }

	public virtual Employee IdEmployeeNavigation { get; set; } = null!;

	public virtual Post IdNewPostNavigation { get; set; } = null!;

	public virtual Post IdOldPostNavigation { get; set; } = null!;
}

internal class OrderAssignWrapper
{
	[Display(Name = "№ приказа")]
	public int IdOrder { get; set; }

	public Guid IdEmployee { get; set; }

	public int IdOldPost { get; set; }

	public int IdNewPost { get; set; }

	public int IdDepartment { get; set; }

	[Display(Name = "Дата назначения")]
	public DateOnly DateAssign { get; set; }

	[Display(Name = "Причина")]
	public string Reason { get; set; }

	[Display(Name = "Старая должность")]
	public string OldPost { get; set; }

	[Display(Name = "Новая должность")]
	public string NewPost { get; set; }

	[Display(Name = "Фамилия")]
	public string Surname { get; set; }

	[Display(Name = "Имя")]
	public string Name { get; set; }

	[Display(Name = "Отчество")]
	public string Patronymic { get; set; }

	[Display(Name = "Отдел")]
	public string Department { get; set; }

	public OrderAssignWrapper(OrderAssign oa, OrderAssignViewModel oavm)
	{
		IdOrder = oa.IdOrder;
		IdEmployee = oa.IdEmployee;
		IdOldPost = oa.IdOldPost;
		IdNewPost = oa.IdNewPost;
		DateAssign = oa.DateAssign;
		Reason = oa.Reason;
		OldPost = oavm.GetPost(oa.IdOldPost).First().Name;
		NewPost = oavm.GetPost(oa.IdNewPost).First().Name;
		Employee e = oavm.GetEmployee(IdEmployee).First();
		IdDepartment = e.IdDepartment;
		Surname = e.Surname;
		Name = e.Name;
		Patronymic = e.Patronymic;
		Department = oavm.GetDepartment(IdDepartment).First().Name;
	}

	internal static List<OrderAssignWrapper> ToOrderAssignWrapper(List<OrderAssign> e, OrderAssignViewModel oavm)
	{
		List<OrderAssignWrapper> oaw = [];

		foreach (OrderAssign oa in e)
		{
			oaw.Add(new OrderAssignWrapper(oa, oavm));
		}

		return oaw;
	}
}