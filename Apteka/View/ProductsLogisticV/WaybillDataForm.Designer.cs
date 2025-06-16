using Apteka.Model;

namespace Apteka.View.ProductsLogisticV
{
	partial class WaybillDataForm
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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			splitContainer1 = new SplitContainer();
			splitContainer2 = new SplitContainer();
			label1 = new Label();
			dtpDateWaybill = new DateTimePicker();
			btnAddMedicineProduct = new Button();
			btnCancel = new Button();
			tbNumberWaybill = new TextBox();
			btnDone = new Button();
			label5 = new Label();
			label4 = new Label();
			cbSupplier = new ComboBox();
			dgvStorage = new DataGridView();
			Storage = new DataGridViewComboBoxColumn();
			Place = new DataGridViewComboBoxColumn();
			dgvMedicineProduct = new DataGridView();
			cmsDgv = new ContextMenuStrip(components);
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvStorage).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvMedicineProduct).BeginInit();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(dgvMedicineProduct);
			splitContainer1.Size = new Size(1154, 358);
			splitContainer1.SplitterDistance = 576;
			splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = DockStyle.Fill;
			splitContainer2.IsSplitterFixed = true;
			splitContainer2.Location = new Point(0, 0);
			splitContainer2.Name = "splitContainer2";
			splitContainer2.Orientation = Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(label1);
			splitContainer2.Panel1.Controls.Add(dtpDateWaybill);
			splitContainer2.Panel1.Controls.Add(btnAddMedicineProduct);
			splitContainer2.Panel1.Controls.Add(btnCancel);
			splitContainer2.Panel1.Controls.Add(tbNumberWaybill);
			splitContainer2.Panel1.Controls.Add(btnDone);
			splitContainer2.Panel1.Controls.Add(label5);
			splitContainer2.Panel1.Controls.Add(label4);
			splitContainer2.Panel1.Controls.Add(cbSupplier);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(dgvStorage);
			splitContainer2.Size = new Size(576, 358);
			splitContainer2.SplitterDistance = 99;
			splitContainer2.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(352, 8);
			label1.Name = "label1";
			label1.Size = new Size(36, 17);
			label1.TabIndex = 47;
			label1.Text = "Дата";
			// 
			// dtpDateWaybill
			// 
			dtpDateWaybill.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateWaybill.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateWaybill.Location = new Point(352, 28);
			dtpDateWaybill.Name = "dtpDateWaybill";
			dtpDateWaybill.Size = new Size(183, 29);
			dtpDateWaybill.TabIndex = 3;
			// 
			// btnAddMedicineProduct
			// 
			btnAddMedicineProduct.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnAddMedicineProduct.Location = new Point(41, 64);
			btnAddMedicineProduct.Name = "btnAddMedicineProduct";
			btnAddMedicineProduct.Size = new Size(305, 29);
			btnAddMedicineProduct.TabIndex = 4;
			btnAddMedicineProduct.Text = "Добавить лекарственный препарат";
			btnAddMedicineProduct.UseVisualStyleBackColor = true;
			btnAddMedicineProduct.Click += btnAddMedicineProduct_Click;
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnCancel.Location = new Point(460, 63);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 29);
			btnCancel.TabIndex = 8;
			btnCancel.Text = "Отмена";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// tbNumberWaybill
			// 
			tbNumberWaybill.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbNumberWaybill.Location = new Point(54, 28);
			tbNumberWaybill.MaxLength = 6;
			tbNumberWaybill.Name = "tbNumberWaybill";
			tbNumberWaybill.Size = new Size(60, 29);
			tbNumberWaybill.TabIndex = 1;
			tbNumberWaybill.KeyPress += tbInt_KeyPress;
			// 
			// btnDone
			// 
			btnDone.DialogResult = DialogResult.OK;
			btnDone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnDone.Location = new Point(352, 64);
			btnDone.Name = "btnDone";
			btnDone.Size = new Size(102, 29);
			btnDone.TabIndex = 7;
			btnDone.Text = "Закончить";
			btnDone.UseVisualStyleBackColor = true;
			btnDone.Click += btnDone_Click;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label5.Location = new Point(40, 9);
			label5.Name = "label5";
			label5.Size = new Size(90, 17);
			label5.TabIndex = 43;
			label5.Text = "№ накладной";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label4.Location = new Point(136, 9);
			label4.Name = "label4";
			label4.Size = new Size(74, 17);
			label4.TabIndex = 41;
			label4.Text = "Поставщик";
			// 
			// cbSupplier
			// 
			cbSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbSupplier.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbSupplier.DropDownWidth = 260;
			cbSupplier.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbSupplier.FormattingEnabled = true;
			cbSupplier.Location = new Point(136, 28);
			cbSupplier.MaxDropDownItems = 30;
			cbSupplier.Name = "cbSupplier";
			cbSupplier.Size = new Size(210, 29);
			cbSupplier.TabIndex = 2;
			// 
			// dgvStorage
			// 
			dgvStorage.AllowDrop = true;
			dgvStorage.AllowUserToOrderColumns = true;
			dgvStorage.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvStorage.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvStorage.Columns.AddRange(new DataGridViewColumn[] { Storage, Place });
			dgvStorage.Dock = DockStyle.Fill;
			dgvStorage.Location = new Point(0, 0);
			dgvStorage.MultiSelect = false;
			dgvStorage.Name = "dgvStorage";
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvStorage.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvStorage.Size = new Size(576, 255);
			dgvStorage.TabIndex = 6;
			dgvStorage.CellBeginEdit += dgvStorage_CellBeginEdit;
			dgvStorage.CellEndEdit += dgv_CellEndEdit;
			dgvStorage.CellMouseDown += dgv_CellMouseDown;
			dgvStorage.DefaultValuesNeeded += dgvStorage_DefaultValuesNeeded;
			dgvStorage.EditingControlShowing += dgv_EditingControlShowing;
			// 
			// Storage
			// 
			Storage.HeaderText = "Склад";
			Storage.Name = "Storage";
			// 
			// Place
			// 
			Place.HeaderText = "Место";
			Place.Name = "Place";
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
			dgvMedicineProduct.Size = new Size(574, 358);
			dgvMedicineProduct.TabIndex = 5;
			dgvMedicineProduct.CellEndEdit += dgv_CellEndEdit;
			dgvMedicineProduct.CellMouseDown += dgv_CellMouseDown;
			dgvMedicineProduct.EditingControlShowing += dgv_EditingControlShowing;
			dgvMedicineProduct.RowsAdded += dgvMedicineProduct_RowsAdded;
			// 
			// cmsDgv
			// 
			cmsDgv.Name = "contextMenuStrip1";
			cmsDgv.Size = new Size(61, 4);
			// 
			// WaybillDataForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1154, 358);
			Controls.Add(splitContainer1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "WaybillDataForm";
			Text = "Заполнение накладной";
			FormClosing += WaybillDataForm_FormClosing;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel1.PerformLayout();
			splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvStorage).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvMedicineProduct).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private SplitContainer splitContainer2;
		private DataGridView dgvStorage;
		private DataGridView dgvMedicineProduct;
		private TextBox tbNumberWaybill;
		private Label label5;
		private Label label4;
		private ComboBox cbSupplier;
		private Button btnCancel;
		private Button btnDone;
		private Button btnAddMedicineProduct;
		private Label label1;
		private DateTimePicker dtpDateWaybill;
		private ContextMenuStrip cmsDgv;
		private DataGridViewComboBoxColumn Storage;
		private DataGridViewComboBoxColumn Place;
	}
}