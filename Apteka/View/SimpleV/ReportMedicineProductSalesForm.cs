using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka.View.SimpleV
{
	public partial class ReportMedicineProductSalesForm : Form
	{
		public ReportMedicineProductSalesForm()
		{
			InitializeComponent();
			dtpDateMax.MaxDate = dtpDateMin.MaxDate = DateTime.Now;
			dtpDateMin.MinDate = dtpDateMax.MinDate = DateTime.Now.AddYears(-1);
			dtpDateMin.Value = DateTime.Now.AddMonths(-1);
		}

		private void dtpDateMin_ValueChanged(object sender, EventArgs e)
		{
			dtpDateMax.MinDate = dtpDateMin.Value;
		}

		private void dtpDateMax_ValueChanged(object sender, EventArgs e)
		{
			dtpDateMin.MaxDate = dtpDateMax.Value;
		}
	}
}
