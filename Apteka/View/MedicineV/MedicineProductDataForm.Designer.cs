namespace Apteka.View.MedicineV
{
	partial class MedicineProductDataForm
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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			splitContainer1 = new SplitContainer();
			rtbDosageMode = new RichTextBox();
			label13 = new Label();
			rtbConditionStorage = new RichTextBox();
			label12 = new Label();
			tbAmount = new TextBox();
			label9 = new Label();
			cbMedicine = new ComboBox();
			label15 = new Label();
			label14 = new Label();
			cbProducer = new ComboBox();
			btnCancel = new Button();
			btnAdd = new Button();
			dtpDateExpiration = new DateTimePicker();
			label7 = new Label();
			dtpDateRelease = new DateTimePicker();
			label5 = new Label();
			label4 = new Label();
			cbPackagingForm = new ComboBox();
			label3 = new Label();
			cbWayEnter = new ComboBox();
			label2 = new Label();
			cbMedicineForm = new ComboBox();
			label1 = new Label();
			tbSerialNumber = new TextBox();
			dgvComponents = new DataGridView();
			Component = new DataGridViewTextBoxColumn();
			Amount = new DataGridViewTextBoxColumn();
			Measure = new DataGridViewComboBoxColumn();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvComponents).BeginInit();
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
			splitContainer1.Panel1.Controls.Add(rtbDosageMode);
			splitContainer1.Panel1.Controls.Add(label13);
			splitContainer1.Panel1.Controls.Add(rtbConditionStorage);
			splitContainer1.Panel1.Controls.Add(label12);
			splitContainer1.Panel1.Controls.Add(tbAmount);
			splitContainer1.Panel1.Controls.Add(label9);
			splitContainer1.Panel1.Controls.Add(cbMedicine);
			splitContainer1.Panel1.Controls.Add(label15);
			splitContainer1.Panel1.Controls.Add(label14);
			splitContainer1.Panel1.Controls.Add(cbProducer);
			splitContainer1.Panel1.Controls.Add(btnCancel);
			splitContainer1.Panel1.Controls.Add(btnAdd);
			splitContainer1.Panel1.Controls.Add(dtpDateExpiration);
			splitContainer1.Panel1.Controls.Add(label7);
			splitContainer1.Panel1.Controls.Add(dtpDateRelease);
			splitContainer1.Panel1.Controls.Add(label5);
			splitContainer1.Panel1.Controls.Add(label4);
			splitContainer1.Panel1.Controls.Add(cbPackagingForm);
			splitContainer1.Panel1.Controls.Add(label3);
			splitContainer1.Panel1.Controls.Add(cbWayEnter);
			splitContainer1.Panel1.Controls.Add(label2);
			splitContainer1.Panel1.Controls.Add(cbMedicineForm);
			splitContainer1.Panel1.Controls.Add(label1);
			splitContainer1.Panel1.Controls.Add(tbSerialNumber);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(dgvComponents);
			splitContainer1.Size = new Size(708, 421);
			splitContainer1.SplitterDistance = 264;
			splitContainer1.TabIndex = 71;
			// 
			// rtbDosageMode
			// 
			rtbDosageMode.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			rtbDosageMode.Location = new Point(261, 183);
			rtbDosageMode.Name = "rtbDosageMode";
			rtbDosageMode.Size = new Size(241, 74);
			rtbDosageMode.TabIndex = 104;
			rtbDosageMode.Text = "тест";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label13.Location = new Point(260, 161);
			label13.Name = "label13";
			label13.Size = new Size(130, 17);
			label13.TabIndex = 103;
			label13.Text = "Режим дозирования";
			// 
			// rtbConditionStorage
			// 
			rtbConditionStorage.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			rtbConditionStorage.Location = new Point(260, 78);
			rtbConditionStorage.Name = "rtbConditionStorage";
			rtbConditionStorage.Size = new Size(242, 76);
			rtbConditionStorage.TabIndex = 102;
			rtbConditionStorage.Text = "тест";
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label12.Location = new Point(507, 109);
			label12.Name = "label12";
			label12.Size = new Size(78, 17);
			label12.TabIndex = 100;
			label12.Text = "Количество";
			// 
			// tbAmount
			// 
			tbAmount.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbAmount.Location = new Point(507, 127);
			tbAmount.MaxLength = 6;
			tbAmount.Name = "tbAmount";
			tbAmount.Size = new Size(82, 27);
			tbAmount.TabIndex = 99;
			tbAmount.Text = "20";
			tbAmount.KeyPress += tbNumber_KeyPress;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label9.Location = new Point(12, 9);
			label9.Name = "label9";
			label9.Size = new Size(71, 17);
			label9.TabIndex = 98;
			label9.Text = "Лекарство";
			// 
			// cbMedicine
			// 
			cbMedicine.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbMedicine.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbMedicine.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbMedicine.FormattingEnabled = true;
			cbMedicine.Location = new Point(12, 29);
			cbMedicine.Name = "cbMedicine";
			cbMedicine.Size = new Size(242, 25);
			cbMedicine.Sorted = true;
			cbMedicine.TabIndex = 97;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label15.Location = new Point(260, 58);
			label15.Name = "label15";
			label15.Size = new Size(117, 17);
			label15.TabIndex = 95;
			label15.Text = "Условия хранения";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label14.Location = new Point(260, 9);
			label14.Name = "label14";
			label14.Size = new Size(101, 17);
			label14.TabIndex = 94;
			label14.Text = "Производитель";
			// 
			// cbProducer
			// 
			cbProducer.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbProducer.FormattingEnabled = true;
			cbProducer.Location = new Point(260, 29);
			cbProducer.Name = "cbProducer";
			cbProducer.Size = new Size(242, 25);
			cbProducer.Sorted = true;
			cbProducer.TabIndex = 93;
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnCancel.Location = new Point(613, 220);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(82, 37);
			btnCancel.TabIndex = 92;
			btnCancel.Text = "Отмена";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnAdd
			// 
			btnAdd.DialogResult = DialogResult.OK;
			btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnAdd.Location = new Point(508, 220);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(82, 37);
			btnAdd.TabIndex = 91;
			btnAdd.Text = "Добавить";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// dtpDateExpiration
			// 
			dtpDateExpiration.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateExpiration.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateExpiration.Format = DateTimePickerFormat.Short;
			dtpDateExpiration.Location = new Point(508, 80);
			dtpDateExpiration.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
			dtpDateExpiration.Name = "dtpDateExpiration";
			dtpDateExpiration.Size = new Size(188, 25);
			dtpDateExpiration.TabIndex = 83;
			dtpDateExpiration.Value = new DateTime(2027, 12, 21, 0, 0, 0, 0);
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label7.Location = new Point(507, 58);
			label7.Name = "label7";
			label7.Size = new Size(95, 17);
			label7.TabIndex = 84;
			label7.Text = "Cрок годности";
			// 
			// dtpDateRelease
			// 
			dtpDateRelease.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateRelease.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateRelease.Format = DateTimePickerFormat.Short;
			dtpDateRelease.Location = new Point(508, 29);
			dtpDateRelease.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
			dtpDateRelease.Name = "dtpDateRelease";
			dtpDateRelease.Size = new Size(188, 25);
			dtpDateRelease.TabIndex = 79;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label5.Location = new Point(508, 7);
			label5.Name = "label5";
			label5.Size = new Size(123, 17);
			label5.TabIndex = 80;
			label5.Text = "Дата производства";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label4.Location = new Point(12, 212);
			label4.Name = "label4";
			label4.Size = new Size(107, 17);
			label4.TabIndex = 78;
			label4.Text = "Форма упаковки";
			// 
			// cbPackagingForm
			// 
			cbPackagingForm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbPackagingForm.FormattingEnabled = true;
			cbPackagingForm.Location = new Point(12, 232);
			cbPackagingForm.Name = "cbPackagingForm";
			cbPackagingForm.Size = new Size(242, 25);
			cbPackagingForm.Sorted = true;
			cbPackagingForm.TabIndex = 77;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label3.Location = new Point(12, 161);
			label3.Name = "label3";
			label3.Size = new Size(113, 17);
			label3.TabIndex = 76;
			label3.Text = "Способ введения";
			// 
			// cbWayEnter
			// 
			cbWayEnter.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbWayEnter.FormattingEnabled = true;
			cbWayEnter.Location = new Point(12, 181);
			cbWayEnter.Name = "cbWayEnter";
			cbWayEnter.Size = new Size(242, 25);
			cbWayEnter.Sorted = true;
			cbWayEnter.TabIndex = 75;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(12, 109);
			label2.Name = "label2";
			label2.Size = new Size(143, 17);
			label2.TabIndex = 74;
			label2.Text = "Лекарственная форма";
			// 
			// cbMedicineForm
			// 
			cbMedicineForm.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbMedicineForm.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbMedicineForm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbMedicineForm.FormattingEnabled = true;
			cbMedicineForm.Location = new Point(12, 129);
			cbMedicineForm.Name = "cbMedicineForm";
			cbMedicineForm.Size = new Size(242, 25);
			cbMedicineForm.Sorted = true;
			cbMedicineForm.TabIndex = 73;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(12, 58);
			label1.Name = "label1";
			label1.Size = new Size(111, 17);
			label1.TabIndex = 72;
			label1.Text = "Серийный номер";
			// 
			// tbSerialNumber
			// 
			tbSerialNumber.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbSerialNumber.Location = new Point(12, 78);
			tbSerialNumber.Name = "tbSerialNumber";
			tbSerialNumber.Size = new Size(242, 27);
			tbSerialNumber.TabIndex = 71;
			tbSerialNumber.Text = "тест-2025";
			// 
			// dgvComponents
			// 
			dgvComponents.AllowDrop = true;
			dgvComponents.AllowUserToOrderColumns = true;
			dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dgvComponents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dgvComponents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvComponents.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvComponents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvComponents.Columns.AddRange(new DataGridViewColumn[] { Component, Amount, Measure });
			dgvComponents.Dock = DockStyle.Fill;
			dgvComponents.Location = new Point(0, 0);
			dgvComponents.MultiSelect = false;
			dgvComponents.Name = "dgvComponents";
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvComponents.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dgvComponents.RowsDefaultCellStyle = dataGridViewCellStyle3;
			dgvComponents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvComponents.Size = new Size(708, 153);
			dgvComponents.TabIndex = 10;
			dgvComponents.EditingControlShowing += dgvComponents_EditingControlShowing;
			dgvComponents.KeyDown += dgv_KeyDown;
			// 
			// Component
			// 
			Component.HeaderText = "Вещество";
			Component.Name = "Component";
			Component.Resizable = DataGridViewTriState.True;
			Component.SortMode = DataGridViewColumnSortMode.NotSortable;
			// 
			// Amount
			// 
			Amount.HeaderText = "Количество";
			Amount.Name = "Amount";
			// 
			// Measure
			// 
			Measure.HeaderText = "Мера";
			Measure.Name = "Measure";
			Measure.Resizable = DataGridViewTriState.True;
			// 
			// MedicineProductDataForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(708, 421);
			Controls.Add(splitContainer1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "MedicineProductDataForm";
			Text = "Данные лекарственного препарата";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvComponents).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private Label label9;
		private ComboBox cbMedicine;
		private Label label15;
		private Label label14;
		private ComboBox cbProducer;
		private Button btnCancel;
		private Button btnAdd;
		private DateTimePicker dtpDateExpiration;
		private Label label7;
		private DateTimePicker dtpDateRelease;
		private Label label5;
		private Label label4;
		private ComboBox cbPackagingForm;
		private Label label3;
		private ComboBox cbWayEnter;
		private Label label2;
		private ComboBox cbMedicineForm;
		private Label label1;
		private TextBox tbSerialNumber;
		private DataGridView dgvComponents;
		private Label label12;
		private TextBox tbAmount;
		private RichTextBox rtbConditionStorage;
		private RichTextBox rtbDosageMode;
		private Label label13;
		private DataGridViewTextBoxColumn Component;
		private DataGridViewTextBoxColumn Amount;
		private DataGridViewComboBoxColumn Measure;
	}
}