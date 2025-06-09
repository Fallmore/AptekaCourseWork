using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka.Model
{
	internal class MedicineProductAmount
	{
		[DisplayName("Серийный номер")]
		[Column("Серийный номер")]
		public string? SerialNumber { get; set; }

		[DisplayName("Наименование")]
		[Column("Наименование")]
		public string? Name { get; set; }

		[DisplayName("Кол-во в начале раб. дня")]
		[Column("Кол-во утром")]
		public float? MorningQuantity { get; set; }

		[DisplayName("Продано")]
		[Column("Продано")]
		public float? Sold { get; set; }

		[DisplayName("Принято")]
		[Column("Принято")]
		public float? Received { get; set; }

		[DisplayName("Списано")]
		[Column("Списано")]
		public float? Decommissioned { get; set; }

		[DisplayName("Кол-во в конце раб. дня")]
		[Column("Кол-во в конце дня")]
		public float? EndOfDayQuantity { get; set; }
	}
}
