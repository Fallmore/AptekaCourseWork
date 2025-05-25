using Apteka.BaseClasses;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class Medicine : UnionId
{
	public override object GetId() => IdMedicine;

	[Browsable(false)]
	public int IdMedicine { get; set; }

	[Display(Name = "Название")]
	public string Name { get; set; } = null!;

	[Display(Name = "МНН")]
	public string Mnn { get; set; } = null!;

	[Display(Name = "Фарм. группа")]
	public string PharmGroup { get; set; } = null!;

	[Display(Name = "Условие отпуска")]
	public string ConditionRelease { get; set; } = null!;

	[Browsable(false)]
	public virtual ICollection<MedicineProduct> MedicineProducts { get; set; } = new List<MedicineProduct>();
}
