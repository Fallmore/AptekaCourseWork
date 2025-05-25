using Apteka.BaseClasses;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class MedicineCost : UnionId
{
	public override object GetId() => string.Concat(IdMedicine, PackagingForm);

	public int IdMedicine { get; set; }

	[Display(Name = "Форма упаковки")]
	public string PackagingForm { get; set; } = null!;

	[Display(Name = "Цена")]
	public float Cost { get; set; }

	[Browsable(false)]
	public virtual Medicine IdMedicineNavigation { get; set; } = null!;

	[Browsable(false)]
	public virtual MedicinePackagingForm PackagingFormNavigation { get; set; } = null!;
}
