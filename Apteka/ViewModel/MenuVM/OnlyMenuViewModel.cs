using Apteka.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

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

		internal List<MedicineProductSales> GetReportMedicineProductSales(Guid idMP, int idDepartment, DateTime[] dtParams)
		{
			List<MedicineProductSales> salesMP = General.AptekaContext.Database
				.SqlQueryRaw<MedicineProductSales>("SELECT * FROM get_medicine_product_sales({0}, {1}, " +
				"{2}, {3})",
				idMP, idDepartment,
						new NpgsqlParameter("p2", NpgsqlDbType.Timestamp) { Value = dtParams[0] },
						new NpgsqlParameter("p3", NpgsqlDbType.Timestamp) { Value = dtParams[1] })
				.ToList();
			return salesMP;
		}
	}
}
