namespace Apteka.View.EmployeeV
{
	partial class EmployeeRolesForm
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
			clbRoles = new CheckedListBox();
			button2 = new Button();
			button1 = new Button();
			SuspendLayout();
			// 
			// clbRoles
			// 
			clbRoles.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			clbRoles.FormattingEnabled = true;
			clbRoles.Location = new Point(12, 12);
			clbRoles.Name = "clbRoles";
			clbRoles.Size = new Size(189, 124);
			clbRoles.TabIndex = 3;
			// 
			// button2
			// 
			button2.DialogResult = DialogResult.Cancel;
			button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button2.Location = new Point(126, 142);
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
			button1.Location = new Point(12, 142);
			button1.Name = "button1";
			button1.Size = new Size(75, 29);
			button1.TabIndex = 27;
			button1.Text = "ОК";
			button1.UseVisualStyleBackColor = true;
			// 
			// EmployeeRolesForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(213, 175);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(clbRoles);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "EmployeeRolesForm";
			Text = "Роли";
			ResumeLayout(false);
		}

		#endregion
		private Button button2;
		private Button button1;
		internal CheckedListBox clbRoles;
	}
}