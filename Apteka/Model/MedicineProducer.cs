using Apteka.BaseClasses;

namespace Apteka.Model;

public partial class MedicineProducer : UnionId
{
	public override object GetId() => Producer;

	public string Producer { get; set; } = null!;

	public virtual ICollection<MedicineProduct> MedicineProducts { get; set; } = new List<MedicineProduct>();
}
