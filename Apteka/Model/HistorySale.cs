using Apteka.BaseClasses;
using Apteka.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Model;

public partial class HistorySale : UnionId
{
	public override object GetId() => IdSale;

	public Guid IdSale { get; set; }

	public Guid IdMedicineProduct { get; set; }

	public float Amount { get; set; }

	public string Measure { get; set; } = null!;

	public float Cost { get; set; }

	public DateTime DateSale { get; set; }

	public Guid IdEmployee { get; set; }

	public int IdDepartment { get; set; }

	public int IdStorage { get; set; }

	public int IdPlace { get; set; }

	public virtual Department IdDepartmentNavigation { get; set; } = null!;

	public virtual Employee IdEmployeeNavigation { get; set; } = null!;

	public virtual MedicineProduct IdMedicineProductNavigation { get; set; } = null!;

	public virtual StoragePlace IdPlaceNavigation { get; set; } = null!;

	public virtual StoragePharmacy IdStorageNavigation { get; set; } = null!;

	public virtual MeasureMeasurability MeasureNavigation { get; set; } = null!;
}

internal class HistorySaleWrapper
{
	public Guid IdSale { get; set; }

	public Guid IdMedicineProduct { get; set; }

	public Guid IdEmployee { get; set; }

	public int IdDepartment { get; set; }

	public int IdStorage { get; set; }

	public int IdPlace { get; set; }

	[Display(Name = "Название")]
	public string MedicineProductName { get; set; }

	[Display(Name = "Количество")]
	public float Amount { get; set; }

	[Display(Name = "Мера")]
	public string Measure { get; set; }

	[Display(Name = "Стоимость")]
	public float Cost { get; set; }

	[Display(Name = "Дата продажи")]
	public DateTime DateSale { get; set; }

	[Display(Name = "Название")]
	public string EmployeeName { get; set; }

	[Display(Name = "Отдел")]
	public string Department { get; set; }

	[Display(Name = "Склад")]
	public string Storage { get; set; }

	[Display(Name = "Место")]
	public string Place { get; set; }

	public HistorySaleWrapper(HistorySale hs, HistorySalesViewModel hsvm)
	{
		IdSale = hs.IdSale;
		IdMedicineProduct = hs.IdMedicineProduct;
		IdEmployee = hs.IdEmployee;
		IdDepartment = hs.IdDepartment;
		IdStorage = hs.IdStorage;
		IdPlace = hs.IdPlace;
		MedicineProductName = hsvm.GetMedicineProduct(hs.IdMedicineProduct).First().Name;
		Amount = hs.Amount;
		Measure = hs.Measure;
		Cost = hs.Cost;
		DateSale = hs.DateSale;
		Employee? e = hsvm.GetEmployee(hs.IdEmployee).FirstOrDefault();
		EmployeeName = e != null ? $"{e.Surname} {e.Name} {e.Patronymic}" : "";
		Department = hsvm.GetDepartment(hs.IdDepartment).First().Name;
		Storage = hsvm.GetStoragePharmacy(hs.IdStorage).First().Name;
		Place = hsvm.GetStoragePlace(hs.IdPlace).First().Name;
	}

	internal static List<HistorySaleWrapper> ToHistorySaleWrapper(List<HistorySale> smp, HistorySalesViewModel smpvm)
	{
		List<HistorySaleWrapper> smpw = [];

		foreach (HistorySale mp in smp)
		{
			smpw.Add(new HistorySaleWrapper(mp, smpvm));
		}

		return smpw;
	}
}
