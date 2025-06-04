using Apteka.BaseClasses;
using Apteka.ViewModel.MedicineVM;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class MedicineProductDecommissioned : UnionId
{
	public override object GetId() => IdMedicineProduct;

	public Guid IdMedicineProduct { get; set; }

	public string Reason { get; set; } = null!;

	public float Amount { get; set; }

	public string Measure { get; set; } = null!;

	public DateTime DateDecommission { get; set; }

	public virtual MedicineProduct IdMedicineProductNavigation { get; set; } = null!;

	public virtual MeasureMeasurability MeasureNavigation { get; set; } = null!;
}

internal class MedicineProductDecommissionedWrapper(MedicineProductDecommissioned mpd, MedicineProductDecommissionedViewModel mpdvm)
{
	public Guid IdMedicineProduct { get; set; } = mpd.IdMedicineProduct;

	[Display(Name = "Название")]
	public string MedicineProductName { get; set; } = mpdvm.GetMedicineProduct(mpd.IdMedicineProduct).First().Name;

	[Display(Name = "Причина")]
	public string Reason { get; set; } = mpd.Reason;

	[Display(Name = "Количество")]
	public float Amount { get; set; } = mpd.Amount;

	[Display(Name = "Мера")]
	public string Measure { get; set; } = mpd.Measure;

	[Display(Name = "Дата списания")]
	public DateTime DateDecommission { get; set; } = mpd.DateDecommission;

	internal static List<MedicineProductDecommissionedWrapper> ToMedicineProductDecommissionedWrapper(List<MedicineProductDecommissioned> mpd, MedicineProductDecommissionedViewModel mpdvm)
	{
		List<MedicineProductDecommissionedWrapper> mpdw = [];

		foreach (MedicineProductDecommissioned mp in mpd)
		{
			mpdw.Add(new MedicineProductDecommissionedWrapper(mp, mpdvm));
		}

		return mpdw;
	}
}