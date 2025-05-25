namespace Apteka.View
{
	partial class MedicineProductDecommissionedForm
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
			tbReason = new TextBox();
			dtpDateDecommissionMin = new DateTimePicker();
			dtpDateDecommissionMax = new DateTimePicker();
			label6 = new Label();
			label7 = new Label();
			label3 = new Label();
			cbMedicineProductName = new ComboBox();
			label4 = new Label();
			btnResetSearch = new Button();
			btnSearch = new Button();
			dgvMedicineProductDecommissioned = new DataGridView();
			contextMenuStrip1 = new ContextMenuStrip(components);
			cbDepartment = new ComboBox();
			label2 = new Label();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvMedicineProductDecommissioned).BeginInit();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.FixedPanel = FixedPanel.Panel1;
			splitContainer1.IsSplitterFixed = true;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(cbDepartment);
			splitContainer1.Panel1.Controls.Add(label2);
			splitContainer1.Panel1.Controls.Add(tbReason);
			splitContainer1.Panel1.Controls.Add(dtpDateDecommissionMin);
			splitContainer1.Panel1.Controls.Add(dtpDateDecommissionMax);
			splitContainer1.Panel1.Controls.Add(label6);
			splitContainer1.Panel1.Controls.Add(label7);
			splitContainer1.Panel1.Controls.Add(label3);
			splitContainer1.Panel1.Controls.Add(cbMedicineProductName);
			splitContainer1.Panel1.Controls.Add(label4);
			splitContainer1.Panel1.Controls.Add(btnResetSearch);
			splitContainer1.Panel1.Controls.Add(btnSearch);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(dgvMedicineProductDecommissioned);
			splitContainer1.Size = new Size(837, 450);
			splitContainer1.SplitterDistance = 120;
			splitContainer1.TabIndex = 0;
			// 
			// tbReason
			// 
			tbReason.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			tbReason.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbReason.Location = new Point(339, 26);
			tbReason.Name = "tbReason";
			tbReason.Size = new Size(210, 27);
			tbReason.TabIndex = 22;
			// 
			// dtpDateDecommissionMin
			// 
			dtpDateDecommissionMin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			dtpDateDecommissionMin.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateDecommissionMin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateDecommissionMin.Format = DateTimePickerFormat.Short;
			dtpDateDecommissionMin.Location = new Point(340, 81);
			dtpDateDecommissionMin.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
			dtpDateDecommissionMin.Name = "dtpDateDecommissionMin";
			dtpDateDecommissionMin.Size = new Size(93, 25);
			dtpDateDecommissionMin.TabIndex = 18;
			// 
			// dtpDateDecommissionMax
			// 
			dtpDateDecommissionMax.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			dtpDateDecommissionMax.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateDecommissionMax.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateDecommissionMax.Format = DateTimePickerFormat.Short;
			dtpDateDecommissionMax.Location = new Point(455, 81);
			dtpDateDecommissionMax.Name = "dtpDateDecommissionMax";
			dtpDateDecommissionMax.Size = new Size(94, 25);
			dtpDateDecommissionMax.TabIndex = 21;
			// 
			// label6
			// 
			label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label6.Location = new Point(340, 59);
			label6.Name = "label6";
			label6.Size = new Size(94, 17);
			label6.TabIndex = 19;
			label6.Text = "Дата списания";
			// 
			// label7
			// 
			label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label7.Location = new Point(435, 81);
			label7.Name = "label7";
			label7.Size = new Size(20, 25);
			label7.TabIndex = 20;
			label7.Text = "-";
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label3.Location = new Point(339, 6);
			label3.Name = "label3";
			label3.Size = new Size(60, 17);
			label3.TabIndex = 14;
			label3.Text = "Причина";
			// 
			// cbMedicineProductName
			// 
			cbMedicineProductName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			cbMedicineProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbMedicineProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbMedicineProductName.DropDownWidth = 250;
			cbMedicineProductName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbMedicineProductName.FormattingEnabled = true;
			cbMedicineProductName.Location = new Point(123, 28);
			cbMedicineProductName.Name = "cbMedicineProductName";
			cbMedicineProductName.Size = new Size(210, 25);
			cbMedicineProductName.TabIndex = 13;
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label4.Location = new Point(123, 9);
			label4.Name = "label4";
			label4.Size = new Size(87, 17);
			label4.TabIndex = 12;
			label4.Text = "Название ЛП";
			// 
			// btnResetSearch
			// 
			btnResetSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			btnResetSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnResetSearch.Enabled = false;
			btnResetSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnResetSearch.Location = new Point(558, 77);
			btnResetSearch.Name = "btnResetSearch";
			btnResetSearch.Size = new Size(162, 29);
			btnResetSearch.TabIndex = 4;
			btnResetSearch.Text = "Сбросить поиск";
			btnResetSearch.UseVisualStyleBackColor = true;
			btnResetSearch.Click += btnResetSearch_Click;
			// 
			// btnSearch
			// 
			btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			btnSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnSearch.Location = new Point(558, 27);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(162, 29);
			btnSearch.TabIndex = 1;
			btnSearch.Text = "Поиск";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// dgvMedicineProductDecommissioned
			// 
			dgvMedicineProductDecommissioned.AllowUserToAddRows = false;
			dgvMedicineProductDecommissioned.AllowUserToDeleteRows = false;
			dgvMedicineProductDecommissioned.AllowUserToOrderColumns = true;
			dgvMedicineProductDecommissioned.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvMedicineProductDecommissioned.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvMedicineProductDecommissioned.ContextMenuStrip = contextMenuStrip1;
			dgvMedicineProductDecommissioned.Dock = DockStyle.Fill;
			dgvMedicineProductDecommissioned.Location = new Point(0, 0);
			dgvMedicineProductDecommissioned.MultiSelect = false;
			dgvMedicineProductDecommissioned.Name = "dgvMedicineProductDecommissioned";
			dgvMedicineProductDecommissioned.ReadOnly = true;
			dgvMedicineProductDecommissioned.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvMedicineProductDecommissioned.Size = new Size(837, 326);
			dgvMedicineProductDecommissioned.TabIndex = 8;
			dgvMedicineProductDecommissioned.CellMouseDown += dgv_CellMouseDown;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// cbDepartment
			// 
			cbDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			cbDepartment.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbDepartment.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbDepartment.FormattingEnabled = true;
			cbDepartment.Location = new Point(123, 81);
			cbDepartment.Name = "cbDepartment";
			cbDepartment.Size = new Size(210, 25);
			cbDepartment.TabIndex = 17;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(123, 62);
			label2.Name = "label2";
			label2.Size = new Size(44, 17);
			label2.TabIndex = 16;
			label2.Text = "Отдел";
			// 
			// MedicineProductDecommissionedForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(837, 450);
			Controls.Add(splitContainer1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "MedicineProductDecommissionedForm";
			Text = "Списанные лекарственные препараты";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvMedicineProductDecommissioned).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private DataGridView dgvMedicineProductDecommissioned;
		private Label label1;
		private Button btnSearch;
		private Button btnResetSearch;
		private ContextMenuStrip contextMenuStrip1;
		private Label label3;
		private ComboBox cbMedicineProductName;
		private Label label4;
		private DateTimePicker dtpDateDecommissionMin;
		private DateTimePicker dtpDateDecommissionMax;
		private Label label6;
		private Label label7;
		private TextBox tbReason;
		private ComboBox cbDepartment;
		private Label label2;
	}
}