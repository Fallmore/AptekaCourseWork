namespace Apteka.Model;

public partial class MeasureMeasurability
{
	public string Measure { get; set; } = null!;

	public virtual ICollection<HistorySale> HistorySales { get; set; } = new List<HistorySale>();

	public virtual ICollection<StorageMedicineProduct> StorageMedicineProducts { get; set; } = new List<StorageMedicineProduct>();

	public virtual ICollection<Waybill> Waybills { get; set; } = new List<Waybill>();
}
