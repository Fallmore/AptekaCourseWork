namespace Apteka.Model;

public partial class MeasureMeasurability
{
	public string Measure { get; set; } = null!;

	public virtual ICollection<StorageMedicineProduct> StorageMedicineProducts { get; set; } = new List<StorageMedicineProduct>();
}
