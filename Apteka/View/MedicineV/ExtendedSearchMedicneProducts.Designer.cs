namespace Apteka.View.MedicineV
{
	partial class ExtendedSearchMedicneProducts
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
			label1 = new Label();
			tbSerialNumber = new TextBox();
			cbMedicineForm = new ComboBox();
			label2 = new Label();
			label3 = new Label();
			cbWayEnter = new ComboBox();
			label4 = new Label();
			cbPackagingForm = new ComboBox();
			dtpDateReleaseMin = new DateTimePicker();
			label5 = new Label();
			label6 = new Label();
			dtpDateReleaseMax = new DateTimePicker();
			dtpDateExpirationMin = new DateTimePicker();
			dtpDateExpirationMax = new DateTimePicker();
			label7 = new Label();
			label8 = new Label();
			label9 = new Label();
			cbDecommissioned = new ComboBox();
			label10 = new Label();
			tbConditionRelease = new TextBox();
			label11 = new Label();
			tbPharmGroup = new TextBox();
			label12 = new Label();
			tbComponentMeasure = new TextBox();
			label13 = new Label();
			tbComponent = new TextBox();
			btnOK = new Button();
			btnCancel = new Button();
			label14 = new Label();
			cbProducer = new ComboBox();
			label15 = new Label();
			tbConditionStorage = new TextBox();
			label16 = new Label();
			cbExpired = new ComboBox();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(12, 5);
			label1.Name = "label1";
			label1.Size = new Size(111, 17);
			label1.TabIndex = 3;
			label1.Text = "Серийный номер";
			// 
			// tbSerialNumber
			// 
			tbSerialNumber.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbSerialNumber.Location = new Point(12, 25);
			tbSerialNumber.Name = "tbSerialNumber";
			tbSerialNumber.Size = new Size(242, 27);
			tbSerialNumber.TabIndex = 2;
			// 
			// cbMedicineForm
			// 
			cbMedicineForm.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbMedicineForm.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbMedicineForm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbMedicineForm.FormattingEnabled = true;
			cbMedicineForm.Location = new Point(12, 76);
			cbMedicineForm.Name = "cbMedicineForm";
			cbMedicineForm.Size = new Size(242, 25);
			cbMedicineForm.Sorted = true;
			cbMedicineForm.TabIndex = 4;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(12, 56);
			label2.Name = "label2";
			label2.Size = new Size(143, 17);
			label2.TabIndex = 5;
			label2.Text = "Лекарственная форма";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label3.Location = new Point(12, 108);
			label3.Name = "label3";
			label3.Size = new Size(113, 17);
			label3.TabIndex = 7;
			label3.Text = "Способ введения";
			// 
			// cbWayEnter
			// 
			cbWayEnter.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbWayEnter.FormattingEnabled = true;
			cbWayEnter.Location = new Point(12, 128);
			cbWayEnter.Name = "cbWayEnter";
			cbWayEnter.Size = new Size(242, 25);
			cbWayEnter.Sorted = true;
			cbWayEnter.TabIndex = 6;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label4.Location = new Point(12, 159);
			label4.Name = "label4";
			label4.Size = new Size(107, 17);
			label4.TabIndex = 9;
			label4.Text = "Форма упаковки";
			// 
			// cbPackagingForm
			// 
			cbPackagingForm.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbPackagingForm.FormattingEnabled = true;
			cbPackagingForm.Location = new Point(12, 179);
			cbPackagingForm.Name = "cbPackagingForm";
			cbPackagingForm.Size = new Size(242, 25);
			cbPackagingForm.Sorted = true;
			cbPackagingForm.TabIndex = 8;
			// 
			// dtpDateReleaseMin
			// 
			dtpDateReleaseMin.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateReleaseMin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateReleaseMin.Format = DateTimePickerFormat.Short;
			dtpDateReleaseMin.Location = new Point(509, 27);
			dtpDateReleaseMin.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
			dtpDateReleaseMin.Name = "dtpDateReleaseMin";
			dtpDateReleaseMin.Size = new Size(82, 25);
			dtpDateReleaseMin.TabIndex = 10;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label5.Location = new Point(509, 5);
			label5.Name = "label5";
			label5.Size = new Size(123, 17);
			label5.TabIndex = 11;
			label5.Text = "Дата производства";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label6.Location = new Point(593, 27);
			label6.Name = "label6";
			label6.Size = new Size(20, 25);
			label6.TabIndex = 12;
			label6.Text = "-";
			// 
			// dtpDateReleaseMax
			// 
			dtpDateReleaseMax.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateReleaseMax.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateReleaseMax.Format = DateTimePickerFormat.Short;
			dtpDateReleaseMax.Location = new Point(614, 27);
			dtpDateReleaseMax.Name = "dtpDateReleaseMax";
			dtpDateReleaseMax.Size = new Size(82, 25);
			dtpDateReleaseMax.TabIndex = 13;
			// 
			// dtpDateExpirationMin
			// 
			dtpDateExpirationMin.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateExpirationMin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateExpirationMin.Format = DateTimePickerFormat.Short;
			dtpDateExpirationMin.Location = new Point(509, 78);
			dtpDateExpirationMin.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
			dtpDateExpirationMin.Name = "dtpDateExpirationMin";
			dtpDateExpirationMin.Size = new Size(82, 25);
			dtpDateExpirationMin.TabIndex = 14;
			// 
			// dtpDateExpirationMax
			// 
			dtpDateExpirationMax.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateExpirationMax.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateExpirationMax.Format = DateTimePickerFormat.Short;
			dtpDateExpirationMax.Location = new Point(614, 78);
			dtpDateExpirationMax.Name = "dtpDateExpirationMax";
			dtpDateExpirationMax.Size = new Size(82, 25);
			dtpDateExpirationMax.TabIndex = 17;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label7.Location = new Point(508, 56);
			label7.Name = "label7";
			label7.Size = new Size(196, 17);
			label7.TabIndex = 15;
			label7.Text = "Дата истечения срока годности";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label8.Location = new Point(593, 78);
			label8.Name = "label8";
			label8.Size = new Size(20, 25);
			label8.TabIndex = 16;
			label8.Text = "-";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label9.Location = new Point(509, 108);
			label9.Name = "label9";
			label9.Size = new Size(73, 17);
			label9.TabIndex = 19;
			label9.Text = "Списанный";
			// 
			// cbDecommissioned
			// 
			cbDecommissioned.DropDownStyle = ComboBoxStyle.DropDownList;
			cbDecommissioned.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbDecommissioned.FormattingEnabled = true;
			cbDecommissioned.Items.AddRange(new object[] { "", "Да", "Нет" });
			cbDecommissioned.Location = new Point(509, 128);
			cbDecommissioned.Name = "cbDecommissioned";
			cbDecommissioned.Size = new Size(187, 25);
			cbDecommissioned.TabIndex = 18;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label10.Location = new Point(260, 56);
			label10.Name = "label10";
			label10.Size = new Size(106, 17);
			label10.TabIndex = 23;
			label10.Text = "Условие отпуска";
			// 
			// tbConditionRelease
			// 
			tbConditionRelease.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbConditionRelease.Location = new Point(260, 76);
			tbConditionRelease.Name = "tbConditionRelease";
			tbConditionRelease.Size = new Size(242, 27);
			tbConditionRelease.TabIndex = 22;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label11.Location = new Point(260, 5);
			label11.Name = "label11";
			label11.Size = new Size(88, 17);
			label11.TabIndex = 21;
			label11.Text = "Фарм. группа";
			// 
			// tbPharmGroup
			// 
			tbPharmGroup.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbPharmGroup.Location = new Point(260, 25);
			tbPharmGroup.Name = "tbPharmGroup";
			tbPharmGroup.Size = new Size(242, 27);
			tbPharmGroup.TabIndex = 20;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label12.Location = new Point(260, 157);
			label12.Name = "label12";
			label12.Size = new Size(149, 17);
			label12.TabIndex = 27;
			label12.Text = "Дозировка компонента";
			// 
			// tbComponentMeasure
			// 
			tbComponentMeasure.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbComponentMeasure.Location = new Point(260, 177);
			tbComponentMeasure.Name = "tbComponentMeasure";
			tbComponentMeasure.Size = new Size(242, 27);
			tbComponentMeasure.TabIndex = 26;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label13.Location = new Point(260, 106);
			label13.Name = "label13";
			label13.Size = new Size(74, 17);
			label13.TabIndex = 25;
			label13.Text = "Компонент";
			// 
			// tbComponent
			// 
			tbComponent.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbComponent.Location = new Point(260, 126);
			tbComponent.Name = "tbComponent";
			tbComponent.Size = new Size(242, 27);
			tbComponent.TabIndex = 24;
			// 
			// btnOK
			// 
			btnOK.DialogResult = DialogResult.OK;
			btnOK.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnOK.Location = new Point(507, 220);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(84, 37);
			btnOK.TabIndex = 28;
			btnOK.Text = "ОК";
			btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnCancel.Location = new Point(614, 220);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(82, 37);
			btnCancel.TabIndex = 29;
			btnCancel.Text = "Отмена";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label14.Location = new Point(12, 210);
			label14.Name = "label14";
			label14.Size = new Size(101, 17);
			label14.TabIndex = 31;
			label14.Text = "Производитель";
			// 
			// cbProducer
			// 
			cbProducer.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbProducer.FormattingEnabled = true;
			cbProducer.Location = new Point(12, 230);
			cbProducer.Name = "cbProducer";
			cbProducer.Size = new Size(242, 25);
			cbProducer.Sorted = true;
			cbProducer.TabIndex = 30;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label15.Location = new Point(260, 210);
			label15.Name = "label15";
			label15.Size = new Size(117, 17);
			label15.TabIndex = 33;
			label15.Text = "Условия хранения";
			// 
			// tbConditionStorage
			// 
			tbConditionStorage.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbConditionStorage.Location = new Point(260, 230);
			tbConditionStorage.Name = "tbConditionStorage";
			tbConditionStorage.Size = new Size(242, 27);
			tbConditionStorage.TabIndex = 34;
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label16.Location = new Point(509, 159);
			label16.Name = "label16";
			label16.Size = new Size(99, 17);
			label16.TabIndex = 36;
			label16.Text = "Просроченный";
			// 
			// cbExpired
			// 
			cbExpired.DropDownStyle = ComboBoxStyle.DropDownList;
			cbExpired.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbExpired.FormattingEnabled = true;
			cbExpired.Items.AddRange(new object[] { "", "Да", "Нет" });
			cbExpired.Location = new Point(509, 179);
			cbExpired.Name = "cbExpired";
			cbExpired.Size = new Size(187, 25);
			cbExpired.TabIndex = 35;
			// 
			// ExtendedSearchMedicneProducts
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(714, 267);
			Controls.Add(label16);
			Controls.Add(cbExpired);
			Controls.Add(tbConditionStorage);
			Controls.Add(label15);
			Controls.Add(label14);
			Controls.Add(cbProducer);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			Controls.Add(label12);
			Controls.Add(tbComponentMeasure);
			Controls.Add(label13);
			Controls.Add(tbComponent);
			Controls.Add(label10);
			Controls.Add(tbConditionRelease);
			Controls.Add(label11);
			Controls.Add(tbPharmGroup);
			Controls.Add(label9);
			Controls.Add(cbDecommissioned);
			Controls.Add(dtpDateExpirationMin);
			Controls.Add(dtpDateExpirationMax);
			Controls.Add(label7);
			Controls.Add(label8);
			Controls.Add(dtpDateReleaseMin);
			Controls.Add(dtpDateReleaseMax);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(cbPackagingForm);
			Controls.Add(label3);
			Controls.Add(cbWayEnter);
			Controls.Add(label2);
			Controls.Add(cbMedicineForm);
			Controls.Add(label1);
			Controls.Add(tbSerialNumber);
			Controls.Add(label6);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "ExtendedSearchMedicneProducts";
			Text = "Расширенный поиск ЛП";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox tbSerialNumber;
		private ComboBox cbMedicineForm;
		private Label label2;
		private Label label3;
		private ComboBox cbWayEnter;
		private Label label4;
		private ComboBox cbPackagingForm;
		private DateTimePicker dtpDateReleaseMin;
		private Label label5;
		private Label label6;
		private DateTimePicker dtpDateReleaseMax;
		private DateTimePicker dtpDateExpirationMin;
		private DateTimePicker dtpDateExpirationMax;
		private Label label7;
		private Label label8;
		private Label label9;
		private ComboBox cbDecommissioned;
		private Label label10;
		private TextBox tbConditionRelease;
		private Label label11;
		private TextBox tbPharmGroup;
		private Label label12;
		private TextBox tbComponentMeasure;
		private Label label13;
		private TextBox tbComponent;
		private Button btnOK;
		private Button btnCancel;
		private Label label14;
		private ComboBox cbProducer;
		private Label label15;
		private TextBox tbConditionStorage;
		private Label label16;
		private ComboBox cbExpired;
	}
}