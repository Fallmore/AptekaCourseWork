using Apteka.BaseClasses;

namespace Apteka.Model;

public partial class StoragePharmacy : UnionId
{
	public override object GetId() => IdStorage;

	public int IdStorage { get; set; } = -1;

	public string Name { get; set; } = null!;

	public virtual ICollection<HistorySale> HistorySales { get; set; } = new List<HistorySale>();

	public virtual ICollection<StorageMedicineProduct> StorageMedicineProducts { get; set; } = new List<StorageMedicineProduct>();
}
