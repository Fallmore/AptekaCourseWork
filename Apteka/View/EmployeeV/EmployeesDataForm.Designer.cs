namespace Apteka.View.EmployeeV
{
    partial class EmployeesDataForm
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
			tbName = new TextBox();
			lblData = new Label();
			tbSurname = new TextBox();
			label3 = new Label();
			tbPatronymic = new TextBox();
			label4 = new Label();
			tbAddress = new TextBox();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			btnOK = new Button();
			button2 = new Button();
			dtpBirthday = new DateTimePicker();
			cbPost = new ComboBox();
			cbDepartment = new ComboBox();
			label8 = new Label();
			lblIdEmployee = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(12, 49);
			label1.Name = "label1";
			label1.Size = new Size(91, 25);
			label1.TabIndex = 0;
			label1.Text = "Фамилия";
			// 
			// tbName
			// 
			tbName.Font = new Font("Segoe UI", 12F);
			tbName.Location = new Point(12, 137);
			tbName.Name = "tbName";
			tbName.Size = new Size(398, 29);
			tbName.TabIndex = 1;
			tbName.KeyPress += TextBoxKeyPress;
			// 
			// lblData
			// 
			lblData.AutoSize = true;
			lblData.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
			lblData.Location = new Point(78, 9);
			lblData.Name = "lblData";
			lblData.Size = new Size(256, 32);
			lblData.TabIndex = 2;
			lblData.Text = "Данные о сотруднике";
			// 
			// tbSurname
			// 
			tbSurname.Font = new Font("Segoe UI", 12F);
			tbSurname.Location = new Point(12, 77);
			tbSurname.Name = "tbSurname";
			tbSurname.Size = new Size(398, 29);
			tbSurname.TabIndex = 4;
			tbSurname.KeyPress += TextBoxKeyPress;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label3.Location = new Point(12, 109);
			label3.Name = "label3";
			label3.Size = new Size(49, 25);
			label3.TabIndex = 3;
			label3.Text = "Имя";
			// 
			// tbPatronymic
			// 
			tbPatronymic.Font = new Font("Segoe UI", 12F);
			tbPatronymic.Location = new Point(12, 197);
			tbPatronymic.Name = "tbPatronymic";
			tbPatronymic.Size = new Size(398, 29);
			tbPatronymic.TabIndex = 6;
			tbPatronymic.KeyPress += TextBoxKeyPress;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label4.Location = new Point(12, 169);
			label4.Name = "label4";
			label4.Size = new Size(93, 25);
			label4.TabIndex = 5;
			label4.Text = "Отчество";
			// 
			// tbAddress
			// 
			tbAddress.Font = new Font("Segoe UI", 12F);
			tbAddress.Location = new Point(12, 257);
			tbAddress.Name = "tbAddress";
			tbAddress.Size = new Size(398, 29);
			tbAddress.TabIndex = 8;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label5.Location = new Point(12, 229);
			label5.Name = "label5";
			label5.Size = new Size(64, 25);
			label5.TabIndex = 7;
			label5.Text = "Адрес";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label6.Location = new Point(12, 289);
			label6.Name = "label6";
			label6.Size = new Size(146, 25);
			label6.TabIndex = 9;
			label6.Text = "Дата рождения";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label7.Location = new Point(12, 349);
			label7.Name = "label7";
			label7.Size = new Size(109, 25);
			label7.TabIndex = 11;
			label7.Text = "Должность";
			// 
			// btnOK
			// 
			btnOK.DialogResult = DialogResult.OK;
			btnOK.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnOK.Location = new Point(12, 480);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(161, 42);
			btnOK.TabIndex = 15;
			btnOK.Text = "Принять";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnOK_Click;
			// 
			// button2
			// 
			button2.DialogResult = DialogResult.Cancel;
			button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button2.Location = new Point(249, 480);
			button2.Name = "button2";
			button2.Size = new Size(161, 42);
			button2.TabIndex = 16;
			button2.Text = "Отмена";
			button2.UseVisualStyleBackColor = true;
			// 
			// dtpBirthday
			// 
			dtpBirthday.Font = new Font("Segoe UI", 12F);
			dtpBirthday.Location = new Point(12, 317);
			dtpBirthday.MinDate = new DateTime(1940, 1, 1, 0, 0, 0, 0);
			dtpBirthday.Name = "dtpBirthday";
			dtpBirthday.Size = new Size(200, 29);
			dtpBirthday.TabIndex = 17;
			// 
			// cbPost
			// 
			cbPost.DropDownStyle = ComboBoxStyle.DropDownList;
			cbPost.Font = new Font("Segoe UI", 12F);
			cbPost.FormattingEnabled = true;
			cbPost.Location = new Point(12, 377);
			cbPost.Name = "cbPost";
			cbPost.Size = new Size(398, 29);
			cbPost.TabIndex = 18;
			// 
			// cbDepartment
			// 
			cbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
			cbDepartment.Font = new Font("Segoe UI", 12F);
			cbDepartment.FormattingEnabled = true;
			cbDepartment.Location = new Point(12, 437);
			cbDepartment.Name = "cbDepartment";
			cbDepartment.Size = new Size(398, 29);
			cbDepartment.TabIndex = 20;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label8.Location = new Point(12, 409);
			label8.Name = "label8";
			label8.Size = new Size(64, 25);
			label8.TabIndex = 19;
			label8.Text = "Отдел";
			// 
			// lblIdEmployee
			// 
			lblIdEmployee.AutoSize = true;
			lblIdEmployee.Location = new Point(229, 328);
			lblIdEmployee.Name = "lblIdEmployee";
			lblIdEmployee.Size = new Size(0, 15);
			lblIdEmployee.TabIndex = 21;
			lblIdEmployee.Visible = false;
			// 
			// EmployeesDataForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(425, 534);
			Controls.Add(lblIdEmployee);
			Controls.Add(cbDepartment);
			Controls.Add(label8);
			Controls.Add(cbPost);
			Controls.Add(dtpBirthday);
			Controls.Add(button2);
			Controls.Add(btnOK);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(tbAddress);
			Controls.Add(label5);
			Controls.Add(tbPatronymic);
			Controls.Add(label4);
			Controls.Add(tbSurname);
			Controls.Add(label3);
			Controls.Add(lblData);
			Controls.Add(tbName);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "EmployeesDataForm";
			Text = "Данные сотрудника";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button1;
        private Button button2;
		private Label label8;
		internal DateTimePicker dtpBirthday;
		internal ComboBox cbPost;
		internal ComboBox cbDepartment;
		internal TextBox tbName;
		internal TextBox tbSurname;
		internal TextBox tbPatronymic;
		internal TextBox tbAddress;
		internal Label lblData;
		internal Button btnOK;
		internal Label lblIdEmployee;
	}
}