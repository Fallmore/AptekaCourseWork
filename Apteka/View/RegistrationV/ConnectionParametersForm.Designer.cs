namespace Apteka.View.RegistrationV
{
	partial class ConnectionParametersForm
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
			button1 = new Button();
			tbHost = new TextBox();
			label2 = new Label();
			tbDataBase = new TextBox();
			label1 = new Label();
			tbPassword = new TextBox();
			label3 = new Label();
			tbUsername = new TextBox();
			label4 = new Label();
			SuspendLayout();
			// 
			// button1
			// 
			button1.DialogResult = DialogResult.OK;
			button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button1.Location = new Point(12, 236);
			button1.Name = "button1";
			button1.Size = new Size(75, 29);
			button1.TabIndex = 2;
			button1.Text = "ОК";
			button1.UseVisualStyleBackColor = true;
			// 
			// tbHost
			// 
			tbHost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbHost.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbHost.Location = new Point(12, 33);
			tbHost.Name = "tbHost";
			tbHost.Size = new Size(212, 29);
			tbHost.TabIndex = 30;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(12, 9);
			label2.Name = "label2";
			label2.Size = new Size(124, 21);
			label2.TabIndex = 31;
			label2.Text = "Владелец (Host)";
			// 
			// tbDataBase
			// 
			tbDataBase.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbDataBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbDataBase.Location = new Point(12, 89);
			tbDataBase.Name = "tbDataBase";
			tbDataBase.Size = new Size(212, 29);
			tbDataBase.TabIndex = 32;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(12, 65);
			label1.Name = "label1";
			label1.Size = new Size(99, 21);
			label1.TabIndex = 33;
			label1.Text = "База данных";
			// 
			// tbPassword
			// 
			tbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbPassword.Location = new Point(12, 201);
			tbPassword.Name = "tbPassword";
			tbPassword.Size = new Size(212, 29);
			tbPassword.TabIndex = 36;
			tbPassword.UseSystemPasswordChar = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label3.Location = new Point(12, 177);
			label3.Name = "label3";
			label3.Size = new Size(63, 21);
			label3.TabIndex = 37;
			label3.Text = "Пароль";
			// 
			// tbUsername
			// 
			tbUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbUsername.Location = new Point(12, 145);
			tbUsername.Name = "tbUsername";
			tbUsername.Size = new Size(212, 29);
			tbUsername.TabIndex = 34;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label4.Location = new Point(12, 121);
			label4.Name = "label4";
			label4.Size = new Size(151, 21);
			label4.TabIndex = 35;
			label4.Text = "Суперпользователь";
			// 
			// ConnectionParametersForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(236, 269);
			Controls.Add(tbPassword);
			Controls.Add(label3);
			Controls.Add(tbUsername);
			Controls.Add(label4);
			Controls.Add(tbDataBase);
			Controls.Add(label1);
			Controls.Add(tbHost);
			Controls.Add(label2);
			Controls.Add(button1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "ConnectionParametersForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Параметры подключения";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		internal TextBox tbHost;
		private Label label2;
		internal TextBox tbDataBase;
		private Label label1;
		internal TextBox tbPassword;
		private Label label3;
		internal TextBox tbUsername;
		private Label label4;
	}
}