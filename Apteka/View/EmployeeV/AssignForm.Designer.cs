namespace Apteka.View.EmployeeV
{
	partial class AssignForm
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
			cbNewPost = new ComboBox();
			rtbReason = new RichTextBox();
			label2 = new Label();
			button2 = new Button();
			button1 = new Button();
			label3 = new Label();
			tbNumberOrder = new TextBox();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(12, 66);
			label1.Name = "label1";
			label1.Size = new Size(136, 21);
			label1.TabIndex = 0;
			label1.Text = "Новая должность";
			// 
			// cbNewPost
			// 
			cbNewPost.Font = new Font("Segoe UI", 12F);
			cbNewPost.FormattingEnabled = true;
			cbNewPost.Location = new Point(12, 90);
			cbNewPost.Name = "cbNewPost";
			cbNewPost.Size = new Size(244, 29);
			cbNewPost.TabIndex = 1;
			// 
			// rtbReason
			// 
			rtbReason.Font = new Font("Segoe UI", 12F);
			rtbReason.Location = new Point(12, 147);
			rtbReason.Name = "rtbReason";
			rtbReason.Size = new Size(244, 96);
			rtbReason.TabIndex = 2;
			rtbReason.Text = "";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F);
			label2.Location = new Point(12, 123);
			label2.Name = "label2";
			label2.Size = new Size(162, 21);
			label2.TabIndex = 3;
			label2.Text = "Причина назначения";
			// 
			// button2
			// 
			button2.DialogResult = DialogResult.Cancel;
			button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button2.Location = new Point(181, 252);
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
			button1.Location = new Point(12, 252);
			button1.Name = "button1";
			button1.Size = new Size(75, 29);
			button1.TabIndex = 27;
			button1.Text = "ОК";
			button1.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F);
			label3.Location = new Point(12, 9);
			label3.Name = "label3";
			label3.Size = new Size(90, 21);
			label3.TabIndex = 29;
			label3.Text = "№ приказа";
			// 
			// tbNumberOrder
			// 
			tbNumberOrder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbNumberOrder.Location = new Point(12, 33);
			tbNumberOrder.Name = "tbNumberOrder";
			tbNumberOrder.Size = new Size(244, 29);
			tbNumberOrder.TabIndex = 30;
			tbNumberOrder.KeyPress += tbNumberOrder_KeyPress;
			// 
			// AssignForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(268, 290);
			Controls.Add(tbNumberOrder);
			Controls.Add(label3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(label2);
			Controls.Add(rtbReason);
			Controls.Add(cbNewPost);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "AssignForm";
			Text = "Назначение сотрудника";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Button button2;
		private Button button1;
		internal ComboBox cbNewPost;
		internal RichTextBox rtbReason;
		private Label label3;
		internal TextBox tbNumberOrder;
	}
}