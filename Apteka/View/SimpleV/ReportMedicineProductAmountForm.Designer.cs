namespace Apteka.View.SimpleV
{
	partial class ReportMedicineProductAmountForm
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
			cbDepartment = new ComboBox();
			label3 = new Label();
			button2 = new Button();
			button1 = new Button();
			SuspendLayout();
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
			cbDepartment.TabIndex = 17;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label3.Location = new Point(12, 9);
			label3.Name = "label3";
			label3.Size = new Size(104, 17);
			label3.TabIndex = 16;
			label3.Text = "Выберите отдел";
			// 
			// button2
			// 
			button2.DialogResult = DialogResult.Cancel;
			button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button2.Location = new Point(147, 59);
			button2.Name = "button2";
			button2.Size = new Size(75, 29);
			button2.TabIndex = 19;
			button2.Text = "Отмена";
			button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.DialogResult = DialogResult.OK;
			button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button1.Location = new Point(12, 59);
			button1.Name = "button1";
			button1.Size = new Size(75, 29);
			button1.TabIndex = 18;
			button1.Text = "ОК";
			button1.UseVisualStyleBackColor = true;
			// 
			// ReportMedicineProductAmountForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(231, 93);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(cbDepartment);
			Controls.Add(label3);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "ReportMedicineProductAmountForm";
			Text = "Количество ЛП на конец дня";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label label3;
		private Button button2;
		private Button button1;
		internal ComboBox cbDepartment;
	}
}