using Apteka.BaseClasses;

namespace Apteka.Model;

public partial class Department : UnionId
{
	public override object GetId() => IdDepartment;

	public int IdDepartment { get; set; } = -1;

	public string Name { get; set; } = null!;

	public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

	public virtual ICollection<HistorySale> HistorySales { get; set; } = new List<HistorySale>();

	public virtual ICollection<StorageMedicineProduct> StorageMedicineProducts { get; set; } = new List<StorageMedicineProduct>();

	public virtual ICollection<Waybill> Waybills { get; set; } = new List<Waybill>();
}
