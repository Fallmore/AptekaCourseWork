using Apteka.Model;
using Microsoft.EntityFrameworkCore;

namespace Apteka.ViewModel.MenuVM
{
	internal class OnlyMenuViewModel
	{
		private readonly GeneralViewModel _general;

		internal GeneralViewModel General => _general;

		public OnlyMenuViewModel()
		{
			_general = GeneralViewModel.Instance;
		}

		internal List<Department> GetDepartments(int? id = null)
		{
			if (id == null)
				return _general.Departments;
			else
				return _general.Departments
				.Where(d => d.IdDepartment == id)
				.ToList();
		}

		internal List<MedicineProduct> GetMedicineProducts(Guid? id = null)
		{
			if (id == null)
				return _general.MedicineProducts;
			else
				return _general.MedicineProducts
				.Where(d => d.IdMedicineProduct == id)
				.ToList();
		}

		internal List<MedicineProductAmount> GetReportMedicineProductAmount(int idDepartment)
		{
			List<MedicineProductAmount> amountsMP = General.AptekaContext.Database
				.SqlQueryRaw<MedicineProductAmount>("SELECT * FROM get_medicine_product_amount_today({0})", idDepartment)
				.ToList();
			return amountsMP;
		}

		internal List<MedicineProductSales> GetReportMedicineProductSales(Guid idMP, int idDepartment, DateTime[] dt)
		{
			// Преобразуем даты в UTC
			dt[0] = DateTime.SpecifyKind(dt[0], DateTimeKind.Utc);
			dt[1] = DateTime.SpecifyKind(dt[1], DateTimeKind.Utc);

			List<MedicineProductSales> salesMP = General.AptekaContext.Database
				.SqlQueryRaw<MedicineProductSales>("SELECT * FROM get_medicine_product_sales({0}, {1}, " +
				"{2}::timestamp, {3}::timestamp)",
				idMP, idDepartment, dt[0], dt[1])
				.ToList();
			return salesMP;
		}
	}
}
