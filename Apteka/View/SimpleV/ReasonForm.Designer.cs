namespace Apteka.View.SimpleV
{
	partial class ReasonForm
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
			label5 = new Label();
			rtbReason = new RichTextBox();
			button1 = new Button();
			button2 = new Button();
			SuspendLayout();
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label5.Location = new Point(36, 9);
			label5.Name = "label5";
			label5.Size = new Size(245, 21);
			label5.TabIndex = 23;
			label5.Text = "Напишите, пожалуйста, причину";
			// 
			// rtbReason
			// 
			rtbReason.Location = new Point(12, 35);
			rtbReason.Name = "rtbReason";
			rtbReason.Size = new Size(290, 75);
			rtbReason.TabIndex = 24;
			rtbReason.Text = "";
			// 
			// button1
			// 
			button1.DialogResult = DialogResult.OK;
			button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button1.Location = new Point(12, 116);
			button1.Name = "button1";
			button1.Size = new Size(75, 29);
			button1.TabIndex = 25;
			button1.Text = "ОК";
			button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.DialogResult = DialogResult.Cancel;
			button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button2.Location = new Point(227, 116);
			button2.Name = "button2";
			button2.Size = new Size(75, 29);
			button2.TabIndex = 26;
			button2.Text = "Отмена";
			button2.UseVisualStyleBackColor = true;
			// 
			// ReasonForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(314, 154);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(rtbReason);
			Controls.Add(label5);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "ReasonForm";
			Text = "Причина";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label5;
		internal RichTextBox rtbReason;
		private Button button1;
		private Button button2;
	}
}