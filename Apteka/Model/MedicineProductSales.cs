using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
