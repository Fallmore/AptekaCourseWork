using Apteka.BaseClasses;

namespace Apteka.Model;

public partial class Supplier : UnionId
{
	public override object GetId() => IdSupplier;

	public int IdSupplier { get; set; } = -1;

	public string Name { get; set; } = null!;

	public virtual ICollection<Waybill> Waybills { get; set; } = new List<Waybill>();
}
