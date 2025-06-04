using Apteka.View.EmployeeV;
using Apteka.View.SimpleV;
using Apteka.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka.View.MenuV
{
	public partial class OnlyMenuForm : Form
	{
		private GeneralViewModel _viewModel;

		public OnlyMenuForm()
		{
			InitializeComponent();
			_viewModel = GeneralViewModel.Instance;
		}

		private void лекарстваToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MedicinesForm? mf = _viewModel.GetActivatedForm<MedicinesForm>();

			mf ??= new();

			mf.Show();
		}

		private void препаратыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MedicineProductsForm? mpf = _viewModel.GetActivatedForm<MedicineProductsForm>();

			mpf ??= new();

			mpf.Show();
		}

		private void списанныеПрепаратыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MedicineProductDecommissionedForm? mpdf = _viewModel.GetActivatedForm<MedicineProductDecommissionedForm>();

			mpdf ??= new();

			mpdf.Show();
		}

		private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm? af = _viewModel.GetActivatedForm<AboutForm>();

			af ??= new();

			af.Show();
		}

		private void историяПродажToolStripMenuItem_Click(object sender, EventArgs e)
		{
			HistorySalesForm? hsf = _viewModel.GetActivatedForm<HistorySalesForm>();

			hsf ??= new();

			hsf.Show();
		}

		private void накладныеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			WaybillsForm? wf = _viewModel.GetActivatedForm<WaybillsForm>();

			wf ??= new();

			wf.Show();
		}

		private void действующиеСотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EmployeesForm? ef = _viewModel.GetActivatedForm<EmployeesForm>();

			ef ??= new();

			ef.Show();
		}

		private void уволенныеСотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EmployeeFiredsForm? ef = _viewModel.GetActivatedForm<EmployeeFiredsForm>();

			ef ??= new();

			ef.Show();
		}

		private void назначенияСотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OrderAssignsForm? ef = _viewModel.GetActivatedForm<OrderAssignsForm>();

			ef ??= new();

			ef.Show();
		}

		private void добавитьСотрудникаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EmployeesDataForm? ef = _viewModel.GetActivatedForm<EmployeesDataForm>();

			ef ??= new();

			ef.Show();
		}
	}
}
