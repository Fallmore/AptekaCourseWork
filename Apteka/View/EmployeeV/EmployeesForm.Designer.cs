namespace Apteka.View.EmployeeV
{
	partial class EmployeesForm
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
			components = new System.ComponentModel.Container();
			splitContainer1 = new SplitContainer();
			tbAddress = new TextBox();
			label1 = new Label();
			tbName = new TextBox();
			dtpDateBirthMin = new DateTimePicker();
			dtpDateBirthMax = new DateTimePicker();
			label6 = new Label();
			label7 = new Label();
			label5 = new Label();
			cbDepartment = new ComboBox();
			label3 = new Label();
			cbPost = new ComboBox();
			label4 = new Label();
			btnResetSearch = new Button();
			btnSearch = new Button();
			dgvEmployees = new DataGridView();
			contextMenuStrip1 = new ContextMenuStrip(components);
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.FixedPanel = FixedPanel.Panel1;
			splitContainer1.IsSplitterFixed = true;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(tbAddress);
			splitContainer1.Panel1.Controls.Add(label1);
			splitContainer1.Panel1.Controls.Add(tbName);
			splitContainer1.Panel1.Controls.Add(dtpDateBirthMin);
			splitContainer1.Panel1.Controls.Add(dtpDateBirthMax);
			splitContainer1.Panel1.Controls.Add(label6);
			splitContainer1.Panel1.Controls.Add(label7);
			splitContainer1.Panel1.Controls.Add(label5);
			splitContainer1.Panel1.Controls.Add(cbDepartment);
			splitContainer1.Panel1.Controls.Add(label3);
			splitContainer1.Panel1.Controls.Add(cbPost);
			splitContainer1.Panel1.Controls.Add(label4);
			splitContainer1.Panel1.Controls.Add(btnResetSearch);
			splitContainer1.Panel1.Controls.Add(btnSearch);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(dgvEmployees);
			splitContainer1.Size = new Size(837, 450);
			splitContainer1.SplitterDistance = 120;
			splitContainer1.TabIndex = 0;
			// 
			// tbAddress
			// 
			tbAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			tbAddress.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbAddress.Location = new Point(11, 79);
			tbAddress.Name = "tbAddress";
			tbAddress.Size = new Size(209, 27);
			tbAddress.TabIndex = 24;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(10, 59);
			label1.Name = "label1";
			label1.Size = new Size(44, 17);
			label1.TabIndex = 23;
			label1.Text = "Адрес";
			// 
			// tbName
			// 
			tbName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			tbName.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbName.Location = new Point(12, 26);
			tbName.Name = "tbName";
			tbName.Size = new Size(209, 27);
			tbName.TabIndex = 22;
			// 
			// dtpDateBirthMin
			// 
			dtpDateBirthMin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			dtpDateBirthMin.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateBirthMin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateBirthMin.Format = DateTimePickerFormat.Short;
			dtpDateBirthMin.Location = new Point(445, 81);
			dtpDateBirthMin.MinDate = new DateTime(1940, 1, 1, 0, 0, 0, 0);
			dtpDateBirthMin.Name = "dtpDateBirthMin";
			dtpDateBirthMin.Size = new Size(93, 25);
			dtpDateBirthMin.TabIndex = 18;
			// 
			// dtpDateBirthMax
			// 
			dtpDateBirthMax.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			dtpDateBirthMax.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateBirthMax.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateBirthMax.Format = DateTimePickerFormat.Short;
			dtpDateBirthMax.Location = new Point(560, 81);
			dtpDateBirthMax.Name = "dtpDateBirthMax";
			dtpDateBirthMax.Size = new Size(94, 25);
			dtpDateBirthMax.TabIndex = 21;
			// 
			// label6
			// 
			label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label6.Location = new Point(445, 59);
			label6.Name = "label6";
			label6.Size = new Size(100, 17);
			label6.TabIndex = 19;
			label6.Text = "Дата рождения";
			// 
			// label7
			// 
			label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label7.Location = new Point(540, 81);
			label7.Name = "label7";
			label7.Size = new Size(20, 25);
			label7.TabIndex = 20;
			label7.Text = "-";
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label5.Location = new Point(11, 6);
			label5.Name = "label5";
			label5.Size = new Size(37, 17);
			label5.TabIndex = 16;
			label5.Text = "ФИО";
			// 
			// cbDepartment
			// 
			cbDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			cbDepartment.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbDepartment.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbDepartment.FormattingEnabled = true;
			cbDepartment.Location = new Point(228, 81);
			cbDepartment.Name = "cbDepartment";
			cbDepartment.Size = new Size(210, 25);
			cbDepartment.TabIndex = 15;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label3.Location = new Point(228, 62);
			label3.Name = "label3";
			label3.Size = new Size(44, 17);
			label3.TabIndex = 14;
			label3.Text = "Отдел";
			// 
			// cbPost
			// 
			cbPost.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			cbPost.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbPost.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbPost.DropDownWidth = 250;
			cbPost.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbPost.FormattingEnabled = true;
			cbPost.Location = new Point(228, 28);
			cbPost.Name = "cbPost";
			cbPost.Size = new Size(210, 25);
			cbPost.TabIndex = 13;
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label4.Location = new Point(228, 9);
			label4.Name = "label4";
			label4.Size = new Size(74, 17);
			label4.TabIndex = 12;
			label4.Text = "Должность";
			// 
			// btnResetSearch
			// 
			btnResetSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			btnResetSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnResetSearch.Enabled = false;
			btnResetSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnResetSearch.Location = new Point(663, 77);
			btnResetSearch.Name = "btnResetSearch";
			btnResetSearch.Size = new Size(162, 29);
			btnResetSearch.TabIndex = 4;
			btnResetSearch.Text = "Сбросить поиск";
			btnResetSearch.UseVisualStyleBackColor = true;
			btnResetSearch.Click += btnResetSearch_Click;
			// 
			// btnSearch
			// 
			btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			btnSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnSearch.Location = new Point(663, 27);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(162, 29);
			btnSearch.TabIndex = 1;
			btnSearch.Text = "Поиск";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// dgvEmployees
			// 
			dgvEmployees.AllowUserToAddRows = false;
			dgvEmployees.AllowUserToDeleteRows = false;
			dgvEmployees.AllowUserToOrderColumns = true;
			dgvEmployees.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvEmployees.ContextMenuStrip = contextMenuStrip1;
			dgvEmployees.Dock = DockStyle.Fill;
			dgvEmployees.Location = new Point(0, 0);
			dgvEmployees.MultiSelect = false;
			dgvEmployees.Name = "dgvEmployees";
			dgvEmployees.ReadOnly = true;
			dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvEmployees.Size = new Size(837, 326);
			dgvEmployees.TabIndex = 8;
			dgvEmployees.CellMouseDown += dgv_CellMouseDown;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// EmployeesForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(837, 450);
			Controls.Add(splitContainer1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "EmployeesForm";
			Text = "Сотрудники";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private Button btnSearch;
		private Button btnResetSearch;
		private ContextMenuStrip contextMenuStrip1;
		private ComboBox cbDepartment;
		private Label label3;
		private ComboBox cbPost;
		private Label label4;
		private Label label5;
		private DateTimePicker dtpDateBirthMin;
		private DateTimePicker dtpDateBirthMax;
		private Label label6;
		private Label label7;
		private TextBox tbName;
		private TextBox tbAddress;
		private Label label1;
		internal DataGridView dgvEmployees;
	}
}