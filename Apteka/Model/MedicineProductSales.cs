using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apteka.Model
{
	internal class MedicineProductSales
	{
		[DisplayName("Количество")]
		[Column("Количество")]
		public float? Quantity { get; set; }

		[DisplayName("Месяц")]
		[Column("Месяц")]
		public string? Month { get; set; }
	}
}
