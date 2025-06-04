using Apteka.BaseClasses;
using Apteka.ViewModel.ProductsLogisticVM;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class HistorySale : UnionId
{
	public override object GetId() => IdSale;

	public Guid IdSale { get; set; }

	public int IdDepartment { get; set; }

	public DateTime DateSale { get; set; }

	public Guid IdEmployee { get; set; }

	public virtual Department IdDepartmentNavigation { get; set; } = null!;

	public virtual Employee IdEmployeeNavigation { get; set; } = null!;
}

internal class HistorySaleWrapper
{
	public Guid IdSale { get; set; }

	public Guid IdEmployee { get; set; }

	public int IdDepartment { get; set; }

	[Display(Name = "Дата продажи")]
	public DateTime DateSale { get; set; }

	[Display(Name = "Сотрудник")]
	public string EmployeeName { get; set; }

	[Display(Name = "Отдел")]
	public string Department { get; set; }

	public HistorySaleWrapper(HistorySale hs, HistorySalesViewModel hsvm)
	{
		IdSale = hs.IdSale;
		IdEmployee = hs.IdEmployee;
		IdDepartment = hs.IdDepartment;
		DateSale = hs.DateSale;
		Employee? e = hsvm.GetEmployee(IdEmployee).FirstOrDefault();
		EmployeeName = e != null ? $"{e.Surname} {e.Name} {e.Patronymic}" : "";
		Department = hsvm.GetDepartment(IdDepartment).First().Name;
	}

	internal static List<HistorySaleWrapper> ToList(List<HistorySale> lhs, HistorySalesViewModel hsvm)
	{
		List<HistorySaleWrapper> lhsw = [];

		foreach (HistorySale hs in lhs)
		{
			lhsw.Add(new HistorySaleWrapper(hs, hsvm));
		}

		return lhsw;
	}
}
