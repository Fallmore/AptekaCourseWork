using Apteka.BaseClasses;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class MedicineProduct : UnionId
{
	public override object GetId() => IdMedicineProduct;

	[Browsable(false)]
	public Guid IdMedicineProduct { get; set; }

	public int IdMedicine { get; set; }

	[Display(Name = "Название")]
	public string Name { get; set; } = null!;

	[Display(Name = "Серийный номер")]
	public string SerialNumber { get; set; } = null!;

	[Display(Name = "Лек. форма")]
	public string Form { get; set; } = null!;

	[Display(Name = "Количество")]
	public float Amount { get; set; }

	[Display(Name = "Состав")]
	public string Components { get; set; } = null!;

	[Display(Name = "Способ введения")]
	public string WayEnter { get; set; } = null!;

	[Display(Name = "Режим дозировки")]
	public string DosageMode { get; set; } = null!;

	[Display(Name = "Форма упаковки")]
	public string PackagingForm { get; set; } = null!;

	[Display(Name = "Изготовитель")]
	public string Producer { get; set; } = null!;

	[Display(Name = "Дата выпуска")]
	public DateOnly DateRelease { get; set; }

	[Display(Name = "Условия хранения")]
	public string StorageCondition { get; set; } = null!;

	[Display(Name = "Срок годности")]
	public DateOnly DateExpiration { get; set; }

	[Browsable(false)]
	public List<int>? Analogues { get; set; }

	[Display(Name = "Списан")]
	public bool Decommissioned { get; set; }

	[Browsable(false)]
	public virtual MedicineForm FormNavigation { get; set; } = null!;

	[Browsable(false)]
	public virtual ICollection<HistorySale> HistorySales { get; set; } = new List<HistorySale>();

	[Browsable(false)]
	public virtual Medicine IdMedicineNavigation { get; set; } = null!;

	[Browsable(false)]
	public virtual MedicinePackagingForm PackagingFormNavigation { get; set; } = null!;

	[Browsable(false)]
	public virtual MedicineProducer ProducerNavigation { get; set; } = null!;

	[Browsable(false)]
	public virtual ICollection<StorageMedicineProduct> StorageMedicineProducts { get; set; } = new List<StorageMedicineProduct>();

	[Browsable(false)]
	public virtual MedicineWayEnter WayEnterNavigation { get; set; } = null!;

	[Browsable(false)]
	public virtual ICollection<Waybill> Waybills { get; set; } = new List<Waybill>();
}

public class MedicineProductWrapper(MedicineProduct mp)
{
	public Guid IdMedicineProduct { get; set; } = mp.IdMedicineProduct;

	public int IdMedicine { get; set; } = mp.IdMedicine;

	[Display(Name = "Название")]
	public string Name { get; set; } = mp.Name;

	[Display(Name = "Серийный номер")]
	public string SerialNumber { get; set; } = mp.SerialNumber;

	[Display(Name = "Лек. форма")]
	public string Form { get; set; } = mp.Form;

	[Display(Name = "Количество")]
	public float Amount { get; set; } = mp.Amount;

	[Display(Name = "Состав")]
	public string Components { get; set; } =
		mp.Components
		.Replace("\"Мера\":", "")
		.Replace(", \"Вещество\":", " ")
		.Replace("\"", "")
		.Replace(",", ";")
		.Replace("}", "")
		.Replace("{", "")
		.Replace("]", "")
		.Replace("[", "")
		.Trim();

	[Display(Name = "Способ введения")]
	public string WayEnter { get; set; } = mp.WayEnter;

	[Display(Name = "Режим дозировки")]
	public string DosageMode { get; set; } = mp.DosageMode;

	[Display(Name = "Форма упаковки")]
	public string PackagingForm { get; set; } = mp.PackagingForm;

	[Display(Name = "Изготовитель")]
	public string Producer { get; set; } = mp.Producer;

	[Display(Name = "Дата выпуска")]
	public DateOnly DateRelease { get; set; } = mp.DateRelease;

	[Display(Name = "Условия хранения")]
	public string StorageCondition { get; set; } = mp.StorageCondition;

	[Display(Name = "Срок годности")]
	public DateOnly DateExpiration { get; set; } = mp.DateExpiration;

	[Display(Name = "Списан")]
	public string Decommissioned { get; set; } = mp.Decommissioned ? "Да" : "Нет";

	internal static List<MedicineProductWrapper> ToMedicineProductWrapper(List<MedicineProduct> lmp)
	{
		List<MedicineProductWrapper> lmpw = [];

		foreach (MedicineProduct mp in lmp)
		{
			lmpw.Add(new MedicineProductWrapper(mp));
		}

		return lmpw;
	}
}