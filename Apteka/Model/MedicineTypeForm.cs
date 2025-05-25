namespace Apteka.Model;

public partial class MedicineTypeForm
{
	public string TypeForm { get; set; } = null!;

	public virtual ICollection<MedicineForm> MedicineForms { get; set; } = new List<MedicineForm>();
}
