namespace Apteka.View.MedicineV
{
	partial class MedicineCostDataForm
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
			cbPackagingForm = new ComboBox();
			button2 = new Button();
			button1 = new Button();
			label2 = new Label();
			tbCost = new TextBox();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(77, 21);
			label1.TabIndex = 0;
			label1.Text = "Упаковка";
			// 
			// cbPackagingForm
			// 
			cbPackagingForm.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbPackagingForm.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbPackagingForm.DropDownStyle = ComboBoxStyle.DropDownList;
			cbPackagingForm.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbPackagingForm.FormattingEnabled = true;
			cbPackagingForm.Location = new Point(12, 33);
			cbPackagingForm.Name = "cbPackagingForm";
			cbPackagingForm.Size = new Size(197, 29);
			cbPackagingForm.TabIndex = 1;
			// 
			// button2
			// 
			button2.DialogResult = DialogResult.Cancel;
			button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button2.Location = new Point(218, 74);
			button2.Name = "button2";
			button2.Size = new Size(75, 29);
			button2.TabIndex = 28;
			button2.Text = "Отмена";
			button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.DialogResult = DialogResult.OK;
			button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button1.Location = new Point(12, 74);
			button1.Name = "button1";
			button1.Size = new Size(75, 29);
			button1.TabIndex = 27;
			button1.Text = "ОК";
			button1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(215, 9);
			label2.Name = "label2";
			label2.Size = new Size(47, 21);
			label2.TabIndex = 29;
			label2.Text = "Цена";
			// 
			// tbCost
			// 
			tbCost.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbCost.Location = new Point(215, 33);
			tbCost.Name = "tbCost";
			tbCost.PlaceholderText = "00.00";
			tbCost.Size = new Size(78, 29);
			tbCost.TabIndex = 31;
			tbCost.KeyPress += tbCost_KeyPress;
			// 
			// MedicineCostDataForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(309, 115);
			Controls.Add(tbCost);
			Controls.Add(label2);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(cbPackagingForm);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "MedicineCostDataForm";
			Text = "Цена лекарства в упаковке";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Button button2;
		private Button button1;
		internal ComboBox cbPackagingForm;
		private Label label2;
		internal TextBox tbCost;
	}
}