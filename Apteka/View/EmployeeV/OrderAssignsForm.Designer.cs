namespace Apteka.View.EmployeeV
{
	partial class OrderAssignsForm
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
			dtpDateAssignMin = new DateTimePicker();
			dtpDateAssignMax = new DateTimePicker();
			label2 = new Label();
			label8 = new Label();
			tbAddress = new TextBox();
			label1 = new Label();
			tbName = new TextBox();
			label5 = new Label();
			cbDepartment = new ComboBox();
			lblDepartment = new Label();
			cbPost = new ComboBox();
			label4 = new Label();
			btnResetSearch = new Button();
			btnSearch = new Button();
			dgvOrderAssigns = new DataGridView();
			contextMenuStrip1 = new ContextMenuStrip(components);
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvOrderAssigns).BeginInit();
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
			splitContainer1.Panel1.Controls.Add(dtpDateAssignMin);
			splitContainer1.Panel1.Controls.Add(dtpDateAssignMax);
			splitContainer1.Panel1.Controls.Add(label2);
			splitContainer1.Panel1.Controls.Add(label8);
			splitContainer1.Panel1.Controls.Add(tbAddress);
			splitContainer1.Panel1.Controls.Add(label1);
			splitContainer1.Panel1.Controls.Add(tbName);
			splitContainer1.Panel1.Controls.Add(label5);
			splitContainer1.Panel1.Controls.Add(cbDepartment);
			splitContainer1.Panel1.Controls.Add(lblDepartment);
			splitContainer1.Panel1.Controls.Add(cbPost);
			splitContainer1.Panel1.Controls.Add(label4);
			splitContainer1.Panel1.Controls.Add(btnResetSearch);
			splitContainer1.Panel1.Controls.Add(btnSearch);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(dgvOrderAssigns);
			splitContainer1.Size = new Size(837, 450);
			splitContainer1.SplitterDistance = 120;
			splitContainer1.TabIndex = 0;
			// 
			// dtpDateAssignMin
			// 
			dtpDateAssignMin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			dtpDateAssignMin.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateAssignMin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateAssignMin.Format = DateTimePickerFormat.Short;
			dtpDateAssignMin.Location = new Point(445, 26);
			dtpDateAssignMin.MinDate = new DateTime(1940, 1, 1, 0, 0, 0, 0);
			dtpDateAssignMin.Name = "dtpDateAssignMin";
			dtpDateAssignMin.Size = new Size(93, 25);
			dtpDateAssignMin.TabIndex = 25;
			// 
			// dtpDateAssignMax
			// 
			dtpDateAssignMax.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			dtpDateAssignMax.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateAssignMax.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			dtpDateAssignMax.Format = DateTimePickerFormat.Short;
			dtpDateAssignMax.Location = new Point(560, 26);
			dtpDateAssignMax.Name = "dtpDateAssignMax";
			dtpDateAssignMax.Size = new Size(94, 25);
			dtpDateAssignMax.TabIndex = 28;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(445, 4);
			label2.Name = "label2";
			label2.Size = new Size(109, 17);
			label2.TabIndex = 26;
			label2.Text = "Дата назначения";
			// 
			// label8
			// 
			label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label8.Location = new Point(540, 26);
			label8.Name = "label8";
			label8.Size = new Size(20, 25);
			label8.TabIndex = 27;
			label8.Text = "-";
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
			// lblDepartment
			// 
			lblDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			lblDepartment.AutoSize = true;
			lblDepartment.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			lblDepartment.Location = new Point(228, 62);
			lblDepartment.Name = "lblDepartment";
			lblDepartment.Size = new Size(44, 17);
			lblDepartment.TabIndex = 14;
			lblDepartment.Text = "Отдел";
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
			// dgvOrderAssigns
			// 
			dgvOrderAssigns.AllowUserToAddRows = false;
			dgvOrderAssigns.AllowUserToDeleteRows = false;
			dgvOrderAssigns.AllowUserToOrderColumns = true;
			dgvOrderAssigns.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvOrderAssigns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvOrderAssigns.ContextMenuStrip = contextMenuStrip1;
			dgvOrderAssigns.Dock = DockStyle.Fill;
			dgvOrderAssigns.Location = new Point(0, 0);
			dgvOrderAssigns.MultiSelect = false;
			dgvOrderAssigns.Name = "dgvOrderAssigns";
			dgvOrderAssigns.ReadOnly = true;
			dgvOrderAssigns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvOrderAssigns.Size = new Size(837, 326);
			dgvOrderAssigns.TabIndex = 8;
			dgvOrderAssigns.CellMouseDown += dgv_CellMouseDown;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// OrderAssignsForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(837, 450);
			Controls.Add(splitContainer1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "OrderAssignsForm";
			Text = "Приказы назначений сотрудников";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvOrderAssigns).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private DataGridView dgvOrderAssigns;
		private Button btnSearch;
		private Button btnResetSearch;
		private ContextMenuStrip contextMenuStrip1;
		private ComboBox cbDepartment;
		private Label lblDepartment;
		private ComboBox cbPost;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private TextBox tbName;
		private TextBox tbAddress;
		private Label label1;
		private DateTimePicker dtpDateAssignMin;
		private DateTimePicker dtpDateAssignMax;
		private Label label2;
		private Label label8;
	}
}