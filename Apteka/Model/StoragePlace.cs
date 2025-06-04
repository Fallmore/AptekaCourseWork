using Apteka.BaseClasses;

namespace Apteka.Model;

public partial class StoragePlace : UnionId
{
	public override object GetId() => IdPlace;

	public int IdPlace { get; set; } = -1;

	public string Name { get; set; } = null!;

	public virtual ICollection<StorageMedicineProduct> StorageMedicineProducts { get; set; } = new List<StorageMedicineProduct>();
}
