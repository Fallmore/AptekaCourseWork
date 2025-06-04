using Apteka.BaseClasses;
using Apteka.ViewModel.ProductsLogisticVM;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class StorageMedicineProduct : UnionId
{
	public override object GetId() => string.Concat(IdDepartment, IdStorage, IdPlace, IdMedicineProduct);

	public int IdDepartment { get; set; }

	public int IdStorage { get; set; }

	public int IdPlace { get; set; }

	public Guid IdMedicineProduct { get; set; }

	public float Amount { get; set; }

	public string Measure { get; set; } = null!;

	[Browsable(false)]
	public virtual Department IdDepartmentNavigation { get; set; } = null!;

	[Browsable(false)]
	public virtual MedicineProduct IdMedicineProductNavigation { get; set; } = null!;

	[Browsable(false)]
	public virtual StoragePlace IdPlaceNavigation { get; set; } = null!;

	[Browsable(false)]
	public virtual StoragePharmacy IdStorageNavigation { get; set; } = null!;

	[Browsable(false)]
	public virtual MeasureMeasurability MeasureNavigation { get; set; } = null!;

	public StorageMedicineProduct()
	{

	}

	internal StorageMedicineProduct(StorageMedicineProductWrapper smpw)
	{
		IdDepartment = smpw.IdDepartment;
		IdStorage = smpw.IdStorage;
		IdPlace = smpw.IdPlace;
		IdMedicineProduct = smpw.IdMedicineProduct;
		Amount = smpw.Amount;
		Measure = smpw.Measure;
	}
}

internal class StorageMedicineProductWrapper
{
	public int IdDepartment { get; set; }

	public int IdStorage { get; set; }

	public int IdPlace { get; set; }

	public Guid IdMedicineProduct { get; set; }

	[Display(Name = "Серийный номер")]
	public string SerialNumber { get; set; }

	[Display(Name = "Название")]
	public string MedicineProductName { get; set; }

	[Display(Name = "Отдел")]
	public string Department { get; set; }

	[Display(Name = "Склад")]
	public string Storage { get; set; }

	[Display(Name = "Место")]
	public string Place { get; set; }

	[Display(Name = "Количество")]
	public float Amount { get; set; }

	[Display(Name = "Мера")]
	public string Measure { get; set; }

	public bool IsCriticalAmount { get; set; }

	public StorageMedicineProductWrapper()
	{

	}

	public StorageMedicineProductWrapper(StorageMedicineProduct smp, StorageMedicineProductsViewModel smpvm)
	{
		IdDepartment = smp.IdDepartment;
		IdStorage = smp.IdStorage;
		IdPlace = smp.IdPlace;
		IdMedicineProduct = smp.IdMedicineProduct;
		Department = smpvm.GetDepartment(smp.IdDepartment).First().Name;
		Storage = smpvm.GetStoragePharmacy(smp.IdStorage).First().Name;
		Place = smpvm.GetStoragePlace(smp.IdPlace).First().Name;
		MedicineProduct mp = smpvm.GetMedicineProduct(IdMedicineProduct).First();
		MedicineProductName = mp.Name;
		SerialNumber = mp.SerialNumber;
		Amount = smp.Amount;
		Measure = smp.Measure;
		IsCriticalAmount = smpvm.General.MedicineProductsCriticalAmount
		.Find(mpca =>
			mpca.IdPlace == smp.IdPlace &&
			mpca.IdMedicineProduct == smp.IdMedicineProduct &&
			mpca.IdStorage == smp.IdStorage) != null;
	}

	internal static List<StorageMedicineProductWrapper> ToList(List<StorageMedicineProduct> smp, StorageMedicineProductsViewModel smpvm)
	{
		List<StorageMedicineProductWrapper> smpw = [];

		foreach (StorageMedicineProduct mp in smp)
		{
			smpw.Add(new StorageMedicineProductWrapper(mp, smpvm));
		}

		return smpw;
	}
}
