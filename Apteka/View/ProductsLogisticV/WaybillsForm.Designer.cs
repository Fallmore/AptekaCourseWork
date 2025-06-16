namespace Apteka.View
{
	partial class WaybillsForm
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
			components = new System.ComponentModel.Container();
			splitContainer1 = new SplitContainer();
			cbSupplier = new ComboBox();
			label2 = new Label();
			cbEmployee = new ComboBox();
			label1 = new Label();
			tbIdWaybill = new TextBox();
			dtpDateWaybillMin = new DateTimePicker();
			dtpDateWaybillMax = new DateTimePicker();
			label6 = new Label();
			label7 = new Label();
			label5 = new Label();
			cbDepartment = new ComboBox();
			lblDepartment = new Label();
			cbMedicineProduct = new ComboBox();
			label4 = new Label();
			btnResetSearch = new Button();
			btnSearch = new Button();
			splitContainer2 = new SplitContainer();
			dgvWaybill = new DataGridView();
			dgvMedicineProduct = new DataGridView();
			cmsWaybill = new ContextMenuStrip(components);
			cmsMedicineProduct = new ContextMenuStrip(components);
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvWaybill).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvMedicineProduct).BeginInit();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.FixedPanel = FixedPanel.Panel1;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(cbSupplier);
			splitContainer1.Panel1.Controls.Add(label2);
			splitContainer1.Panel1.Controls.Add(cbEmployee);
			splitContainer1.Panel1.Controls.Add(label1);
			splitContainer1.Panel1.Controls.Add(tbIdWaybill);
			splitContainer1.Panel1.Controls.Add(dtpDateWaybillMin);
			splitContainer1.Panel1.Controls.Add(dtpDateWaybillMax);
			splitContainer1.Panel1.Controls.Add(label6);
			splitContainer1.Panel1.Controls.Add(label7);
			splitContainer1.Panel1.Controls.Add(label5);
			splitContainer1.Panel1.Controls.Add(cbDepartment);
			splitContainer1.Panel1.Controls.Add(lblDepartment);
			splitContainer1.Panel1.Controls.Add(cbMedicineProduct);
			splitContainer1.Panel1.Controls.Add(label4);
			splitContainer1.Panel1.Controls.Add(btnResetSearch);
			splitContainer1.Panel1.Controls.Add(btnSearch);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(splitContainer2);
			splitContainer1.Size = new Size(836, 647);
			splitContainer1.SplitterDistance = 120;
			splitContainer1.SplitterWidth = 5;
			splitContainer1.TabIndex = 0;
			// 
			// cbSupplier
			// 
			cbSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			cbSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbSupplier.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbSupplier.DropDownWidth = 250;
			cbSupplier.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbSupplier.FormattingEnabled = true;
			cbSupplier.Location = new Point(445, 31);
			cbSupplier.Name = "cbSupplier";
			cbSupplier.Size = new Size(210, 25);
			cbSupplier.TabIndex = 44;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(445, 12);
			label2.Name = "label2";
			label2.Size = new Size(74, 17);
			label2.TabIndex = 43;
			label2.Text = "Поставщик";
			// 
			// cbEmployee
			// 
			cbEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			cbEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbEmployee.DropDownWidth = 250;
			cbEmployee.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbEmployee.FormattingEnabled = true;
			cbEmployee.Location = new Point(13, 84);
			cbEmployee.Name = "cbEmployee";
			cbEmployee.Size = new Size(210, 25);
			cbEmployee.TabIndex = 42;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(11, 62);
			label1.Name = "label1";
			label1.Size = new Size(70, 17);
			label1.TabIndex = 41;
			label1.Text = "Сотрудник";
			// 
			// tbIdWaybill
			// 
			tbIdWaybill.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			tbIdWaybill.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbIdWaybill.Location = new Point(13, 29);
			tbIdWaybill.Name = "tbIdWaybill";
			tbIdWaybill.Size = new Size(209, 27);
			tbIdWaybill.TabIndex = 40;
			tbIdWaybill.KeyPress += tbIdWaybill_KeyPress;
			// 
			// dtpDateWaybillMin
			// 
			dtpDateWaybillMin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			dtpDateWaybillMin.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateWaybillMin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateWaybillMin.Format = DateTimePickerFormat.Short;
			dtpDateWaybillMin.Location = new Point(446, 84);
			dtpDateWaybillMin.MinDate = new DateTime(1940, 1, 1, 0, 0, 0, 0);
			dtpDateWaybillMin.Name = "dtpDateWaybillMin";
			dtpDateWaybillMin.Size = new Size(93, 25);
			dtpDateWaybillMin.TabIndex = 36;
			// 
			// dtpDateWaybillMax
			// 
			dtpDateWaybillMax.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			dtpDateWaybillMax.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateWaybillMax.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateWaybillMax.Format = DateTimePickerFormat.Short;
			dtpDateWaybillMax.Location = new Point(561, 84);
			dtpDateWaybillMax.Name = "dtpDateWaybillMax";
			dtpDateWaybillMax.Size = new Size(94, 25);
			dtpDateWaybillMax.TabIndex = 39;
			// 
			// label6
			// 
			label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label6.Location = new Point(446, 62);
			label6.Name = "label6";
			label6.Size = new Size(36, 17);
			label6.TabIndex = 37;
			label6.Text = "Дата";
			// 
			// label7
			// 
			label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label7.Location = new Point(541, 84);
			label7.Name = "label7";
			label7.Size = new Size(20, 25);
			label7.TabIndex = 38;
			label7.Text = "-";
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label5.Location = new Point(12, 9);
			label5.Name = "label5";
			label5.Size = new Size(75, 17);
			label5.TabIndex = 35;
			label5.Text = "№ приказа";
			// 
			// cbDepartment
			// 
			cbDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			cbDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbDepartment.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbDepartment.FormattingEnabled = true;
			cbDepartment.Location = new Point(229, 84);
			cbDepartment.Name = "cbDepartment";
			cbDepartment.Size = new Size(210, 25);
			cbDepartment.TabIndex = 34;
			// 
			// lblDepartment
			// 
			lblDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			lblDepartment.AutoSize = true;
			lblDepartment.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			lblDepartment.Location = new Point(229, 65);
			lblDepartment.Name = "lblDepartment";
			lblDepartment.Size = new Size(44, 17);
			lblDepartment.TabIndex = 33;
			lblDepartment.Text = "Отдел";
			// 
			// cbMedicineProduct
			// 
			cbMedicineProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			cbMedicineProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbMedicineProduct.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbMedicineProduct.DropDownWidth = 250;
			cbMedicineProduct.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbMedicineProduct.FormattingEnabled = true;
			cbMedicineProduct.Location = new Point(229, 31);
			cbMedicineProduct.Name = "cbMedicineProduct";
			cbMedicineProduct.Size = new Size(210, 25);
			cbMedicineProduct.TabIndex = 32;
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label4.Location = new Point(229, 12);
			label4.Name = "label4";
			label4.Size = new Size(160, 17);
			label4.TabIndex = 31;
			label4.Text = "Лекарственный препарат";
			// 
			// btnResetSearch
			// 
			btnResetSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			btnResetSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnResetSearch.Enabled = false;
			btnResetSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnResetSearch.Location = new Point(664, 80);
			btnResetSearch.Name = "btnResetSearch";
			btnResetSearch.Size = new Size(162, 29);
			btnResetSearch.TabIndex = 30;
			btnResetSearch.Text = "Сбросить поиск";
			btnResetSearch.UseVisualStyleBackColor = true;
			btnResetSearch.Click += btnResetSearch_Click;
			// 
			// btnSearch
			// 
			btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			btnSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnSearch.Location = new Point(664, 30);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(162, 29);
			btnSearch.TabIndex = 29;
			btnSearch.Text = "Поиск";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = DockStyle.Fill;
			splitContainer2.FixedPanel = FixedPanel.Panel2;
			splitContainer2.Location = new Point(0, 0);
			splitContainer2.Name = "splitContainer2";
			splitContainer2.Orientation = Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(dgvWaybill);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(dgvMedicineProduct);
			splitContainer2.Size = new Size(836, 522);
			splitContainer2.SplitterDistance = 291;
			splitContainer2.SplitterWidth = 5;
			splitContainer2.TabIndex = 9;
			// 
			// dgvWaybill
			// 
			dgvWaybill.AllowUserToAddRows = false;
			dgvWaybill.AllowUserToDeleteRows = false;
			dgvWaybill.AllowUserToOrderColumns = true;
			dgvWaybill.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvWaybill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvWaybill.Dock = DockStyle.Fill;
			dgvWaybill.Location = new Point(0, 0);
			dgvWaybill.MultiSelect = false;
			dgvWaybill.Name = "dgvWaybill";
			dgvWaybill.ReadOnly = true;
			dgvWaybill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvWaybill.Size = new Size(836, 291);
			dgvWaybill.TabIndex = 8;
			dgvWaybill.CellMouseDown += dgv_CellMouseDown;
			dgvWaybill.SelectionChanged += dgvWaybill_SelectionChanged;
			// 
			// dgvMedicineProduct
			// 
			dgvMedicineProduct.AllowUserToAddRows = false;
			dgvMedicineProduct.AllowUserToDeleteRows = false;
			dgvMedicineProduct.AllowUserToOrderColumns = true;
			dgvMedicineProduct.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvMedicineProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvMedicineProduct.Dock = DockStyle.Fill;
			dgvMedicineProduct.Location = new Point(0, 0);
			dgvMedicineProduct.MultiSelect = false;
			dgvMedicineProduct.Name = "dgvMedicineProduct";
			dgvMedicineProduct.ReadOnly = true;
			dgvMedicineProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvMedicineProduct.Size = new Size(836, 226);
			dgvMedicineProduct.TabIndex = 9;
			dgvMedicineProduct.CellMouseDown += dgv_CellMouseDown;
			// 
			// cmsWaybill
			// 
			cmsWaybill.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cmsWaybill.Name = "cmsMedicineProductCost";
			cmsWaybill.Size = new Size(61, 4);
			// 
			// cmsMedicineProduct
			// 
			cmsMedicineProduct.Name = "contextMenuStrip1";
			cmsMedicineProduct.Size = new Size(61, 4);
			// 
			// WaybillsForm
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(836, 647);
			Controls.Add(splitContainer1);
			Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "WaybillsForm";
			Text = "Накладные";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvWaybill).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvMedicineProduct).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private DataGridView dgvWaybill;
		private ContextMenuStrip cmsMedicineProduct;
		private SplitContainer splitContainer2;
		private DataGridView dgvMedicineProduct;
		private ContextMenuStrip cmsWaybill;
		private Label label1;
		private TextBox tbIdWaybill;
		private DateTimePicker dtpDateWaybillMin;
		private DateTimePicker dtpDateWaybillMax;
		private Label label6;
		private Label label7;
		private Label label5;
		private ComboBox cbDepartment;
		private Label lblDepartment;
		private ComboBox cbMedicineProduct;
		private Label label4;
		private Button btnResetSearch;
		private Button btnSearch;
		private ComboBox cbSupplier;
		private Label label2;
		private ComboBox cbEmployee;
	}
}