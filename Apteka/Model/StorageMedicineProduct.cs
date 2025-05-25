using Apteka.BaseClasses;
using Apteka.ViewModel;
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
}

internal class StorageMedicineProductWrapper(StorageMedicineProduct smp, StorageMedicineProductsViewModel smpvm)
{
	public int IdDepartment { get; set; } = smp.IdDepartment;

	public int IdStorage { get; set; } = smp.IdStorage;

	public int IdPlace { get; set; } = smp.IdPlace;

	public Guid IdMedicineProduct { get; set; } = smp.IdMedicineProduct;

	[Display(Name = "Отдел")]
	public string Department { get; set; } = smpvm.GetDepartment(smp.IdDepartment).First().Name;

	[Display(Name = "Склад")]
	public string Storage { get; set; } = smpvm.GetStoragePharmacy(smp.IdStorage).First().Name;

	[Display(Name = "Место")]
	public string Place { get; set; } = smpvm.GetStoragePlace(smp.IdPlace).First().Name;

	[Display(Name = "Название")]
	public string MedicineProductName { get; set; } = smpvm.GetMedicineProduct(smp.IdMedicineProduct).First().Name;

	[Display(Name = "Количество")]
	public float Amount { get; set; } = smp.Amount;

	[Display(Name = "Мера")]
	public string Measure { get; set; } = smp.Measure;

	public bool IsCriticalAmount { get; set; } = smpvm.General.MedicineProductsCriticalAmount
		.Find(mpca =>
			mpca.IdPlace == smp.IdPlace &&
			mpca.IdMedicineProduct == smp.IdMedicineProduct &&
			mpca.IdStorage == smp.IdStorage) != null;

	internal static List<StorageMedicineProductWrapper> ToStorageMedicineProductWrapper(List<StorageMedicineProduct> smp, StorageMedicineProductsViewModel smpvm)
	{
		List<StorageMedicineProductWrapper> smpw = [];

		foreach (StorageMedicineProduct mp in smp)
		{
			smpw.Add(new StorageMedicineProductWrapper(mp, smpvm));
		}

		return smpw;
	}
}
