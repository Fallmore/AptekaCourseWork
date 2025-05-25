using Apteka.BaseClasses;

namespace Apteka.Model;

public partial class MedicineForm : UnionId
{
	public override object GetId() => Form;

	public string Form { get; set; } = null!;

	public string TypeForm { get; set; } = null!;

	public virtual ICollection<MedicineProduct> MedicineProducts { get; set; } = new List<MedicineProduct>();

	public virtual MedicineTypeForm TypeFormNavigation { get; set; } = null!;
}
