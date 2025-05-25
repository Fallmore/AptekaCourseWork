using Apteka.BaseClasses;

namespace Apteka.Model;

public partial class Waybill : UnionId
{
	public override object GetId() => IdWaybill;

	public int IdWaybill { get; set; }

	public DateOnly DateWaybill { get; set; }

	public int IdSupplier { get; set; }

	public Guid IdEmployee { get; set; }

	public int IdDepartment { get; set; }

	public Guid IdMedicineProduct { get; set; }

	public float Amount { get; set; }

	public string Measure { get; set; } = null!;

	public float Cost { get; set; }

	public virtual Department IdDepartmentNavigation { get; set; } = null!;

	public virtual Employee IdEmployeeNavigation { get; set; } = null!;

	public virtual MedicineProduct IdMedicineProductNavigation { get; set; } = null!;

	public virtual Supplier IdSupplierNavigation { get; set; } = null!;

	public virtual MeasureMeasurability MeasureNavigation { get; set; } = null!;
}
