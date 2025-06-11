using Apteka.Model;
using Apteka.View.EmployeeV;
using Apteka.View.MedicineV;
using Apteka.View.ProductsLogisticV;
using Apteka.View.SimpleV;
using Apteka.ViewModel;
using Apteka.ViewModel.MenuVM;
using System.Data;

namespace Apteka.View.MenuV
{
	public partial class OnlyMenuForm : Form
	{
		private OnlyMenuViewModel _viewModel;

		public OnlyMenuForm()
		{
			InitializeComponent();
			_viewModel = new();
			SetFormByRole();
		}

		private void SetFormByRole()
		{
			int userRole = _viewModel.General.ChoosedRole;

			switch (userRole)
			{
				case (int)Roles.Сотрудник:
					сотрудникиToolStripMenuItem.Visible =
					историяПродажToolStripMenuItem.Visible =
					накладныеToolStripMenuItem.Visible =
					управляющиеОтделамиToolStripMenuItem.Visible =
					добавитьНакладныеToolStripMenuItem.Visible =
					отчетыToolStripMenuItem.Visible = false;
					break;
				case (int)Roles.УправляющийОтдела:
					управляющиеОтделамиToolStripMenuItem.Visible = false;
					break;
				default:
					break;
			}
		}

		private T ShowForm<T>() where T : Form, new()
		{
			T? form = _viewModel.General.GetActivatedForm<T>();

			form ??= new();

			form.Show();

			return form;
		}

		private void лекарстваToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ShowForm<MedicinesForm>();
		}

		private void препаратыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowForm<MedicineProductsForm>();
		}

		private void списанныеПрепаратыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowForm<MedicineProductDecommissionedForm>();
		}

		private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowForm<AboutForm>();
		}

		private void историяПродажToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowForm<HistorySalesForm>();
		}

		private void накладныеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowForm<WaybillsForm>();
		}

		private void действующиеСотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowForm<EmployeesForm>();
		}

		private void уволенныеСотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowForm<EmployeeFiredsForm>();
		}

		private void назначенияСотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowForm<OrderAssignsForm>();
		}

		private void добавитьСотрудникаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowForm<EmployeesDataForm>();
		}

		private void ReportMedicineProductAmount()
		{
			if (DateTime.Now.Hour < _viewModel.General.HourOfEndWork)
			{
				MessageBox.Show(text: "Извините, сейчас не конец рабочего дня", "Отчет о наличии ЛП в конце дня",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			int id = GetIdDepartment();
			if (id == -2) return;

			List<MedicineProductAmount> amount = _viewModel.GetReportMedicineProductAmount(id);

			string? departmentName = _viewModel.GetDepartments()
				.FirstOrDefault(d => d.IdDepartment == id)?.Name;
			string fileName = _viewModel.General.PathReport + "/Количество препаратов " +
				 (departmentName != null ? "отдела " + departmentName : "всех отделов") +
				DateOnly.FromDateTime(DateTime.Now) + ".xlsx";

			ExcelManager.ExportToExcel(amount, fileName);
			ExcelManager.OpenExcelFile(fileName);
		}

		private int GetIdDepartment()
		{
			ReportMedicineProductAmountForm form = new();

			form.cbDepartment.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetDepartments(), new() { Name = "Все" })
					.Select(d => new ComboBoxItem { Name = d.Name, Id = d.IdDepartment })
					.ToList();
			form.cbDepartment.DisplayMember = "Name";
			form.cbDepartment.ValueMember = "Id";

			form.StartPosition = FormStartPosition.Manual;
			form.Location = new Point(Cursor.Position.X - form.Width / 4, Cursor.Position.Y - form.Height / 2);

			if (form.ShowDialog() == DialogResult.OK)
				return int.Parse(form.cbDepartment.SelectedValue?.ToString() ?? "");

			return -2;
		}

		private void наличиеЛекарственныхПрепаратовВКонцеДняToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ReportMedicineProductAmount();
		}

		private void ReportMedicineProductSales()
		{
			string[] parameters = GetDataFromForm();
			if (parameters.Length == 0) return;

			Guid idMP = Guid.Parse(parameters[0]);
			int idD = int.Parse(parameters[1]);
			DateTime[] dateTimes = [DateTime.Parse(parameters[2]), DateTime.Parse(parameters[3])];

			List<MedicineProductSales> sales = _viewModel.GetReportMedicineProductSales(idMP, idD, dateTimes);

			string? departmentName = _viewModel.GetDepartments()
				.FirstOrDefault(d => d.IdDepartment == idD)?.Name;
			string? MPName = _viewModel.GetMedicineProducts()
				.FirstOrDefault(mp => mp.IdMedicineProduct == idMP)?.Name;
			string fileName = _viewModel.General.PathReport + "/Количество запросов на препарат " +
				 MPName + " у " +
				 (departmentName != null ? "отдела " + departmentName : "всех отделов") +
				".xlsx";

			ExcelManager.ExportWithChart(sales, fileName);
			ExcelManager.OpenExcelFile(fileName);
		}

		private string[] GetDataFromForm()
		{
			ReportMedicineProductSalesForm form = new();

			form.cbDepartment.DataSource = _viewModel.General.GetListWithEmptyItem(_viewModel.GetDepartments(), new() { Name = "Все" })
					.Select(d => new ComboBoxItem { Name = d.Name, Id = d.IdDepartment })
					.ToList();

			form.cbMedicineProduct.DataSource = _viewModel.GetMedicineProducts()
					.Select(mp => new { Name = mp.SerialNumber + " " + mp.Name, Id = mp.IdMedicineProduct })
					.ToList();

			form.cbDepartment.DisplayMember =
			form.cbMedicineProduct.DisplayMember = "Name";

			form.cbMedicineProduct.ValueMember =
			form.cbDepartment.ValueMember = "Id";

			form.StartPosition = FormStartPosition.Manual;
			form.Location = new Point(Cursor.Position.X - form.Width / 4, Cursor.Position.Y - form.Height / 2);

			if (form.ShowDialog() == DialogResult.OK)
				return [form.cbMedicineProduct.SelectedValue?.ToString() ?? "",
					form.cbDepartment.SelectedValue?.ToString() ?? "-1",
					form.dtpDateMin.Value.ToString(),
					form.dtpDateMax.Value.ToString()];

			return [];
		}

		private void запросыНаЛекарственныеПрепаратыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ReportMedicineProductSales();
		}

		private void наСкладеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowForm<StorageMedicineProductsForm>();
		}

		private void управляющиеОтделамиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var f = ShowForm<EmployeesForm>();
			f.ShowDepartmentManagers();
		}

		private void добавитьНакладныеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowForm<WaybillDataForm>();
		}
	}
}
