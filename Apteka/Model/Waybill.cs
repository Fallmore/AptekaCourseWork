using Apteka.BaseClasses;
using Apteka.ViewModel.ProductsLogisticVM;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class Waybill : UnionId
{
	public override object GetId() => IdWaybill;

	public int IdWaybill { get; set; }

	public DateOnly DateWaybill { get; set; }

	public int IdSupplier { get; set; }

	public Guid IdEmployee { get; set; }

	public int IdDepartment { get; set; }

	public virtual Department IdDepartmentNavigation { get; set; } = null!;

	public virtual Employee IdEmployeeNavigation { get; set; } = null!;

	public virtual Supplier IdSupplierNavigation { get; set; } = null!;

}

internal class WaybillWrapper
{
	[Display(Name = "№ накладной")]
	public int IdWaybill { get; set; }

	public int IdSupplier { get; set; }

	public Guid IdEmployee { get; set; }

	public int IdDepartment { get; set; }

	public Guid IdMedicineProduct { get; set; }

	[Display(Name = "Поставщик")]
	public string Supplier { get; set; }

	[Display(Name = "Сотрудник")]
	public string Employee { get; set; }

	[Display(Name = "Отдел")]
	public string Department { get; set; }

	[Display(Name = "Дата")]
	public DateOnly DateWaybill { get; set; }

	public WaybillWrapper(Waybill w, WaybillViewModel wvm)
	{
		IdWaybill = w.IdWaybill;
		IdSupplier = w.IdSupplier;
		IdEmployee = w.IdEmployee;
		IdDepartment = w.IdDepartment;
		Supplier = wvm.GetSupplier(IdSupplier).First().Name;
		Employee? e = wvm.GetEmployee(IdEmployee).FirstOrDefault();
		Employee = e != null ? $"{e.Surname} {e.Name} {e.Patronymic}" : "";
		Department = wvm.GetDepartment(IdDepartment).First().Name;
		DateWaybill = w.DateWaybill;
	}

	internal static List<WaybillWrapper> ToList(List<Waybill> lw, WaybillViewModel wvm)
	{
		List<WaybillWrapper> lww = [];

		foreach (Waybill w in lw)
		{
			lww.Add(new WaybillWrapper(w, wvm));
		}

		return lww;
	}
}