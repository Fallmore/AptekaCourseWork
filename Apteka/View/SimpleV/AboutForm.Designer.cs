namespace Apteka.View.SimpleV
{
    partial class AboutForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			tableLayoutPanel1 = new TableLayoutPanel();
			pictureBox1 = new PictureBox();
			label3 = new Label();
			label1 = new Label();
			label2 = new Label();
			label4 = new Label();
			textBox1 = new TextBox();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.93976F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.06024F));
			tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
			tableLayoutPanel1.Controls.Add(label3, 1, 2);
			tableLayoutPanel1.Controls.Add(label1, 1, 0);
			tableLayoutPanel1.Controls.Add(label2, 1, 1);
			tableLayoutPanel1.Controls.Add(label4, 1, 3);
			tableLayoutPanel1.Controls.Add(textBox1, 1, 4);
			tableLayoutPanel1.Location = new Point(12, 12);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 5;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 204F));
			tableLayoutPanel1.Size = new Size(664, 339);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// pictureBox1
			// 
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(3, 3);
			pictureBox1.Name = "pictureBox1";
			tableLayoutPanel1.SetRowSpan(pictureBox1, 5);
			pictureBox1.Size = new Size(226, 333);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 5;
			pictureBox1.TabStop = false;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Dock = DockStyle.Fill;
			label3.Font = new Font("Segoe UI", 12F);
			label3.Location = new Point(235, 67);
			label3.Name = "label3";
			label3.Size = new Size(426, 34);
			label3.TabIndex = 2;
			label3.Text = "Авторские права: Самодуров В.А.";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Dock = DockStyle.Fill;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(235, 0);
			label1.Name = "label1";
			label1.Size = new Size(426, 33);
			label1.TabIndex = 0;
			label1.Text = "Название продукта: Информационная система \"Аптека\"";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Dock = DockStyle.Fill;
			label2.Font = new Font("Segoe UI", 12F);
			label2.Location = new Point(235, 33);
			label2.Name = "label2";
			label2.Size = new Size(426, 34);
			label2.TabIndex = 1;
			label2.Text = "Версия: 0.1";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Dock = DockStyle.Fill;
			label4.Font = new Font("Segoe UI", 12F);
			label4.Location = new Point(235, 101);
			label4.Name = "label4";
			label4.Size = new Size(426, 34);
			label4.TabIndex = 3;
			label4.Text = "Название организации: Unfallen More";
			// 
			// textBox1
			// 
			textBox1.BackColor = SystemColors.Control;
			textBox1.BorderStyle = BorderStyle.None;
			textBox1.Dock = DockStyle.Fill;
			textBox1.Font = new Font("Segoe UI", 12F);
			textBox1.Location = new Point(235, 138);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new Size(426, 198);
			textBox1.TabIndex = 4;
			textBox1.TabStop = false;
			textBox1.Text = resources.GetString("textBox1.Text");
			// 
			// AboutForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(688, 363);
			Controls.Add(tableLayoutPanel1);
			Font = new Font("Segoe UI", 9F);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "AboutForm";
			Text = "О программе";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox textBox1;
        private PictureBox pictureBox1;
    }
}