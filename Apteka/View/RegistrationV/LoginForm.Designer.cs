namespace Apteka.View.LoginV
{
	partial class LoginForm
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
			btnEntry = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			label1.Location = new Point(12, 23);
			label1.Name = "label1";
			label1.Size = new Size(63, 21);
			label1.TabIndex = 0;
			label1.Text = "Логин:";
			// 
			// tbLogin
			// 
			tbLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			tbLogin.Location = new Point(99, 20);
			tbLogin.MaxLength = 20;
			tbLogin.Name = "tbLogin";
			tbLogin.Size = new Size(131, 29);
			tbLogin.TabIndex = 1;
			tbLogin.Text = "Petrova";
			tbLogin.KeyDown += RegistrationForm_KeyDown;
			// 
			// tbPassword
			// 
			tbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			tbPassword.Location = new Point(98, 61);
			tbPassword.MaxLength = 20;
			tbPassword.Name = "tbPassword";
			tbPassword.Size = new Size(131, 29);
			tbPassword.TabIndex = 3;
			tbPassword.Text = "Petrova123";
			tbPassword.UseSystemPasswordChar = true;
			tbPassword.KeyDown += RegistrationForm_KeyDown;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			label2.Location = new Point(11, 64);
			label2.Name = "label2";
			label2.Size = new Size(74, 21);
			label2.TabIndex = 2;
			label2.Text = "Пароль:";
			// 
			// btnEntry
			// 
			btnEntry.BackColor = Color.LightBlue;
			btnEntry.FlatStyle = FlatStyle.Flat;
			btnEntry.Font = new Font("Segoe UI", 12F);
			btnEntry.Location = new Point(54, 104);
			btnEntry.Name = "btnEntry";
			btnEntry.Size = new Size(131, 31);
			btnEntry.TabIndex = 4;
			btnEntry.Text = "ВВОД";
			btnEntry.UseVisualStyleBackColor = false;
			btnEntry.Click += btnEntry_Click;
			// 
			// LoginForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(243, 147);
			Controls.Add(btnEntry);
			Controls.Add(tbPassword);
			Controls.Add(label2);
			Controls.Add(tbLogin);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "LoginForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Авторизация пользователя";
			KeyDown += RegistrationForm_KeyDown;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox tbLogin;
		private TextBox tbPassword;
		private Label label2;
		private Button btnEntry;
	}
}