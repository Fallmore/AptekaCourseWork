namespace Apteka.View.EmployeeV
{
	partial class EmployeeAccountForm
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
			tbLogin = new TextBox();
			tbPassword = new TextBox();
			label2 = new Label();
			btnOK = new Button();
			lblMatchPassword = new Label();
			tbMatchPassword = new TextBox();
			btnCancel = new Button();
			lblTitle = new Label();
			lblIdEmployee = new Label();
			label3 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(12, 37);
			label1.Name = "label1";
			label1.Size = new Size(54, 21);
			label1.TabIndex = 0;
			label1.Text = "Логин";
			// 
			// tbLogin
			// 
			tbLogin.Font = new Font("Segoe UI", 12F);
			tbLogin.Location = new Point(12, 61);
			tbLogin.Name = "tbLogin";
			tbLogin.PlaceholderText = "Введите новый логин";
			tbLogin.Size = new Size(234, 29);
			tbLogin.TabIndex = 1;
			// 
			// tbPassword
			// 
			tbPassword.Font = new Font("Segoe UI", 12F);
			tbPassword.Location = new Point(12, 117);
			tbPassword.Name = "tbPassword";
			tbPassword.PlaceholderText = "Введите новый пароль";
			tbPassword.Size = new Size(234, 29);
			tbPassword.TabIndex = 3;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F);
			label2.Location = new Point(12, 93);
			label2.Name = "label2";
			label2.Size = new Size(63, 21);
			label2.TabIndex = 2;
			label2.Text = "Пароль";
			// 
			// btnOK
			// 
			btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnOK.DialogResult = DialogResult.OK;
			btnOK.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnOK.Location = new Point(12, 218);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 29);
			btnOK.TabIndex = 29;
			btnOK.Text = "ОК";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnOK_Click;
			// 
			// lblMatchPassword
			// 
			lblMatchPassword.AutoSize = true;
			lblMatchPassword.Font = new Font("Segoe UI", 12F);
			lblMatchPassword.Location = new Point(12, 149);
			lblMatchPassword.Name = "lblMatchPassword";
			lblMatchPassword.Size = new Size(159, 21);
			lblMatchPassword.TabIndex = 4;
			lblMatchPassword.Text = "Подтвердите пароль";
			// 
			// tbMatchPassword
			// 
			tbMatchPassword.Font = new Font("Segoe UI", 12F);
			tbMatchPassword.Location = new Point(12, 173);
			tbMatchPassword.Name = "tbMatchPassword";
			tbMatchPassword.PlaceholderText = "Повторите пароль";
			tbMatchPassword.Size = new Size(234, 29);
			tbMatchPassword.TabIndex = 5;
			// 
			// btnCancel
			// 
			btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnCancel.Location = new Point(171, 218);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 29);
			btnCancel.TabIndex = 30;
			btnCancel.Text = "Отмена";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// lblTitle
			// 
			lblTitle.Anchor = AnchorStyles.Top;
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Segoe UI", 12F);
			lblTitle.Location = new Point(12, 9);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(234, 21);
			lblTitle.TabIndex = 31;
			lblTitle.Text = "Создание аккаунта сотрудника";
			// 
			// lblIdEmployee
			// 
			lblIdEmployee.AutoSize = true;
			lblIdEmployee.Location = new Point(130, 122);
			lblIdEmployee.Name = "lblIdEmployee";
			lblIdEmployee.Size = new Size(0, 15);
			lblIdEmployee.TabIndex = 32;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(138, 130);
			label3.Name = "label3";
			label3.Size = new Size(0, 15);
			label3.TabIndex = 33;
			label3.Visible = false;
			// 
			// EmployeeAccountForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(260, 259);
			Controls.Add(label3);
			Controls.Add(lblIdEmployee);
			Controls.Add(lblTitle);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			Controls.Add(tbMatchPassword);
			Controls.Add(lblMatchPassword);
			Controls.Add(tbPassword);
			Controls.Add(label2);
			Controls.Add(tbLogin);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "EmployeeAccountForm";
			Text = "Акканут";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox tbLogin;
		private TextBox tbPassword;
		private Label label2;
		private Button button2;
		private Button btnOK;
		internal Label lblMatchPassword;
		internal TextBox tbMatchPassword;
		private Button btnCancel;
		internal Label lblTitle;
		internal Label lblIdEmployee;
		internal Label label3;
	}
}