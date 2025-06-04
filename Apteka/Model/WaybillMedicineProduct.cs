using Apteka.BaseClasses;
using Apteka.ViewModel.ProductsLogisticVM;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class WaybillMedicineProduct : UnionId
{
	public override object GetId() => string.Concat(IdWaybill, IdMedicineProduct);

	public int IdWaybill { get; set; }

	public Guid IdMedicineProduct { get; set; }

	public float Amount { get; set; }

	public string Measure { get; set; } = null!;

	public float Cost { get; set; }

	public virtual MedicineProduct IdMedicineProductNavigation { get; set; } = null!;

	public virtual Waybill IdWaybillNavigation { get; set; } = null!;

	public virtual MeasureMeasurability MeasureNavigation { get; set; } = null!;
}

internal class WaybillMedicineProductWrapper
{
	public int IdWaybill { get; set; }

	public Guid IdMedicineProduct { get; set; }

	[Display(Name = "Лек. препарат")]
	public string MedicineProduct { get; set; }

	[Display(Name = "Серийный номер")]
	public string SerialNumber { get; set; }

	[Display(Name = "Количество")]
	public float Amount { get; set; }

	[Display(Name = "Мера")]
	public string Measure { get; set; }

	[Display(Name = "Стоимость")]
	public float Cost { get; set; }

	public WaybillMedicineProductWrapper()
	{
	}

	public WaybillMedicineProductWrapper(WaybillMedicineProduct w, MedicineProduct mp)
	{
		IdMedicineProduct = mp.IdMedicineProduct;
		MedicineProduct = mp.Name;
		SerialNumber = mp.SerialNumber;
		Amount = w.Amount;
		Measure = w.Measure;
		Cost = w.Cost;
	}

	public WaybillMedicineProductWrapper(WaybillMedicineProduct w, WaybillViewModel wvm)
	{
		IdWaybill = w.IdWaybill;
		IdMedicineProduct = w.IdMedicineProduct;
		MedicineProduct mp = wvm.GetMedicineProduct(IdMedicineProduct).First();
		MedicineProduct = mp.Name;
		SerialNumber = mp.SerialNumber;
		Amount = w.Amount;
		Measure = w.Measure;
		Cost = w.Cost;
	}

	internal static List<WaybillMedicineProductWrapper> ToList(List<WaybillMedicineProduct> lwmp, WaybillViewModel wvm)
	{
		List<WaybillMedicineProductWrapper> lwmpw = [];

		foreach (WaybillMedicineProduct wmp in lwmp)
		{
			lwmpw.Add(new WaybillMedicineProductWrapper(wmp, wvm));
		}

		return lwmpw;
	}
}