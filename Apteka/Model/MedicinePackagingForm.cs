namespace Apteka.Model;

public partial class MedicinePackagingForm
{
	public string PackagingForm { get; set; } = null!;

	public virtual ICollection<MedicineProduct> MedicineProducts { get; set; } = new List<MedicineProduct>();
}
