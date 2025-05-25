namespace Apteka.Model;

public partial class MedicineWayEnter
{
	public string WayEnter { get; set; } = null!;

	public virtual ICollection<MedicineProduct> MedicineProducts { get; set; } = new List<MedicineProduct>();
}
