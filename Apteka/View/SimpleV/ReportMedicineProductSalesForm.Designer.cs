namespace Apteka.View.SimpleV
{
	partial class ReportMedicineProductSalesForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			button2 = new Button();
			button1 = new Button();
			cbDepartment = new ComboBox();
			label3 = new Label();
			cbMedicineProduct = new ComboBox();
			label1 = new Label();
			dtpDateMin = new DateTimePicker();
			dtpDateMax = new DateTimePicker();
			label2 = new Label();
			label8 = new Label();
			SuspendLayout();
			// 
			// button2
			// 
			button2.DialogResult = DialogResult.Cancel;
			button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button2.Location = new Point(147, 163);
			button2.Name = "button2";
			button2.Size = new Size(75, 29);
			button2.TabIndex = 23;
			button2.Text = "Отмена";
			button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.DialogResult = DialogResult.OK;
			button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button1.Location = new Point(12, 163);
			button1.Name = "button1";
			button1.Size = new Size(75, 29);
			button1.TabIndex = 22;
			button1.Text = "ОК";
			button1.UseVisualStyleBackColor = true;
			// 
			// cbDepartment
			// 
			cbDepartment.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
			cbDepartment.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbDepartment.FormattingEnabled = true;
			cbDepartment.Location = new Point(12, 28);
			cbDepartment.Name = "cbDepartment";
			cbDepartment.Size = new Size(210, 25);
			cbDepartment.TabIndex = 21;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label3.Location = new Point(12, 9);
			label3.Name = "label3";
			label3.Size = new Size(104, 17);
			label3.TabIndex = 20;
			label3.Text = "Выберите отдел";
			// 
			// cbMedicineProduct
			// 
			cbMedicineProduct.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbMedicineProduct.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbMedicineProduct.DropDownStyle = ComboBoxStyle.DropDownList;
			cbMedicineProduct.DropDownWidth = 500;
			cbMedicineProduct.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbMedicineProduct.FormattingEnabled = true;
			cbMedicineProduct.Location = new Point(12, 75);
			cbMedicineProduct.Name = "cbMedicineProduct";
			cbMedicineProduct.Size = new Size(210, 25);
			cbMedicineProduct.TabIndex = 25;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(12, 56);
			label1.Name = "label1";
			label1.Size = new Size(88, 17);
			label1.TabIndex = 24;
			label1.Text = "Выберите ЛП";
			// 
			// dtpDateMin
			// 
			dtpDateMin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			dtpDateMin.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateMin.CustomFormat = "MMMM";
			dtpDateMin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateMin.Format = DateTimePickerFormat.Short;
			dtpDateMin.Location = new Point(12, 125);
			dtpDateMin.MinDate = new DateTime(1940, 1, 1, 0, 0, 0, 0);
			dtpDateMin.Name = "dtpDateMin";
			dtpDateMin.Size = new Size(93, 25);
			dtpDateMin.TabIndex = 29;
			dtpDateMin.ValueChanged += dtpDateMin_ValueChanged;
			// 
			// dtpDateMax
			// 
			dtpDateMax.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			dtpDateMax.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateMax.CustomFormat = "MMMM";
			dtpDateMax.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateMax.Format = DateTimePickerFormat.Short;
			dtpDateMax.Location = new Point(127, 125);
			dtpDateMax.Name = "dtpDateMax";
			dtpDateMax.Size = new Size(94, 25);
			dtpDateMax.TabIndex = 32;
			dtpDateMax.ValueChanged += dtpDateMax_ValueChanged;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(12, 103);
			label2.Name = "label2";
			label2.Size = new Size(54, 17);
			label2.TabIndex = 30;
			label2.Text = "Период";
			// 
			// label8
			// 
			label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label8.Location = new Point(107, 125);
			label8.Name = "label8";
			label8.Size = new Size(20, 25);
			label8.TabIndex = 31;
			label8.Text = "-";
			// 
			// ReportMedicineProductSalesForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(234, 204);
			Controls.Add(dtpDateMin);
			Controls.Add(dtpDateMax);
			Controls.Add(label2);
			Controls.Add(label8);
			Controls.Add(cbMedicineProduct);
			Controls.Add(label1);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(cbDepartment);
			Controls.Add(label3);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "ReportMedicineProductSalesForm";
			Text = "Запросы на ЛП";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button2;
		private Button button1;
		internal ComboBox cbDepartment;
		private Label label3;
		internal ComboBox cbMedicineProduct;
		private Label label1;
		private Label label2;
		private Label label8;
		internal DateTimePicker dtpDateMin;
		internal DateTimePicker dtpDateMax;
	}
}