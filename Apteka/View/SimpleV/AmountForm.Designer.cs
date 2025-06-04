namespace Apteka.View.SimpleV
{
	partial class AmountForm
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
			label2 = new Label();
			tbAmount = new TextBox();
			SuspendLayout();
			// 
			// button2
			// 
			button2.DialogResult = DialogResult.Cancel;
			button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button2.Location = new Point(93, 74);
			button2.Name = "button2";
			button2.Size = new Size(75, 29);
			button2.TabIndex = 2;
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
			button1.TabIndex = 1;
			button1.Text = "ОК";
			button1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(12, 9);
			label2.Name = "label2";
			label2.Size = new Size(93, 21);
			label2.TabIndex = 29;
			label2.Text = "Количество";
			// 
			// tbAmount
			// 
			tbAmount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbAmount.Location = new Point(12, 33);
			tbAmount.Name = "tbAmount";
			tbAmount.Size = new Size(152, 29);
			tbAmount.TabIndex = 0;
			tbAmount.TextAlign = HorizontalAlignment.Right;
			tbAmount.KeyPress += tbAmount_KeyPress;
			// 
			// AmountForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(176, 115);
			Controls.Add(tbAmount);
			Controls.Add(label2);
			Controls.Add(button2);
			Controls.Add(button1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "AmountForm";
			Text = "Цена лекарства в упаковке";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button button2;
		private Button button1;
		private Label label2;
		internal TextBox tbAmount;
	}
}