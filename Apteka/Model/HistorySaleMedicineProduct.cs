using Apteka.BaseClasses;
using Apteka.ViewModel.ProductsLogisticVM;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class HistorySaleMedicineProduct : UnionId
{
	public override object GetId() => string.Concat(IdSale, IdStorage, IdPlace, IdMedicineProduct);

	public Guid IdSale { get; set; }

	public int IdStorage { get; set; }

	public int IdPlace { get; set; }

	public Guid IdMedicineProduct { get; set; }

	public float Amount { get; set; }

	public string Measure { get; set; } = null!;

	public float Cost { get; set; }

	public virtual MedicineProduct IdMedicineProductNavigation { get; set; } = null!;

	public virtual StoragePlace IdPlaceNavigation { get; set; } = null!;

	public virtual HistorySale IdSaleNavigation { get; set; } = null!;

	public virtual StoragePharmacy IdStorageNavigation { get; set; } = null!;

	public virtual MeasureMeasurability MeasureNavigation { get; set; } = null!;

	internal HistorySaleMedicineProduct Parse(StorageMedicineProduct smp)
	{
		IdStorage = smp.IdStorage;
		IdPlace = smp.IdPlace;
		IdMedicineProduct = smp.IdMedicineProduct;
		Measure = smp.Measure;
		return this;
	}

	internal HistorySaleMedicineProduct Parse(HistorySaleMedicineProductWrapper hsmpw)
	{
		IdSale = hsmpw.IdSale;
		IdStorage = hsmpw.IdStorage;
		IdPlace = hsmpw.IdPlace;
		IdMedicineProduct = hsmpw.IdMedicineProduct;
		Amount = hsmpw.Amount;
		Cost = hsmpw.Cost;
		Measure = hsmpw.Measure;
		return this;
	}

	internal static List<HistorySaleMedicineProduct> ToList(List<HistorySaleMedicineProductWrapper> lhsmpw)
	{
		List<HistorySaleMedicineProduct> lhsmp = [];

		foreach (HistorySaleMedicineProductWrapper hsmpw in lhsmpw)
		{
			lhsmp.Add(new HistorySaleMedicineProduct().Parse(hsmpw));
		}

		return lhsmp;
	}
}

internal class HistorySaleMedicineProductWrapper
{
	public Guid IdSale { get; set; }

	public Guid IdMedicineProduct { get; set; }

	public int IdStorage { get; set; }

	public int IdPlace { get; set; }

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

	[Display(Name = "Склад")]
	public string Storage { get; set; }

	[Display(Name = "Место")]
	public string Place { get; set; }

	public HistorySaleMedicineProductWrapper()
	{

	}

	public HistorySaleMedicineProductWrapper(HistorySaleMedicineProduct hs, HistorySalesViewModel hsvm)
	{
		IdSale = hs.IdSale;
		IdMedicineProduct = hs.IdMedicineProduct;
		IdStorage = hs.IdStorage;
		IdPlace = hs.IdPlace;
		MedicineProduct mp = hsvm.GetMedicineProduct(IdMedicineProduct).First();
		MedicineProduct = mp.Name;
		SerialNumber = mp.SerialNumber;
		Amount = hs.Amount;
		Measure = hs.Measure;
		Cost = hs.Cost;
		Storage = hsvm.GetStoragePharmacy(IdStorage).First().Name;
		Place = hsvm.GetStoragePlace(IdPlace).First().Name;
	}

	internal static List<HistorySaleMedicineProductWrapper> ToList(List<HistorySaleMedicineProduct> lhsmp,
		HistorySalesViewModel hsvm)
	{
		List<HistorySaleMedicineProductWrapper> lhsmpw = [];

		foreach (HistorySaleMedicineProduct hsmp in lhsmp)
		{
			lhsmpw.Add(new HistorySaleMedicineProductWrapper(hsmp, hsvm));
		}

		return lhsmpw;
	}
}
