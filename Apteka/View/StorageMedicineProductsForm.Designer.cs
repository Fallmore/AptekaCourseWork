namespace Apteka
{
    partial class StorageMedicineProductsForm
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
			cbDepartment = new ComboBox();
			label3 = new Label();
			cbMedicineProductName = new ComboBox();
			label4 = new Label();
			cbPlace = new ComboBox();
			label2 = new Label();
			cbStorage = new ComboBox();
			btnResetSearch = new Button();
			btnSearch = new Button();
			label1 = new Label();
			dgvStorageMedicineProducts = new DataGridView();
			contextMenuStrip1 = new ContextMenuStrip(components);
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvStorageMedicineProducts).BeginInit();
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
			splitContainer1.Panel1.Controls.Add(cbDepartment);
			splitContainer1.Panel1.Controls.Add(label3);
			splitContainer1.Panel1.Controls.Add(cbMedicineProductName);
			splitContainer1.Panel1.Controls.Add(label4);
			splitContainer1.Panel1.Controls.Add(cbPlace);
			splitContainer1.Panel1.Controls.Add(label2);
			splitContainer1.Panel1.Controls.Add(cbStorage);
			splitContainer1.Panel1.Controls.Add(btnResetSearch);
			splitContainer1.Panel1.Controls.Add(btnSearch);
			splitContainer1.Panel1.Controls.Add(label1);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(dgvStorageMedicineProducts);
			splitContainer1.Size = new Size(800, 450);
			splitContainer1.SplitterDistance = 120;
			splitContainer1.TabIndex = 0;
			// 
			// cbDepartment
			// 
			cbDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			cbDepartment.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbDepartment.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbDepartment.FormattingEnabled = true;
			cbDepartment.Location = new Point(310, 81);
			cbDepartment.Name = "cbDepartment";
			cbDepartment.Size = new Size(210, 25);
			cbDepartment.TabIndex = 15;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label3.Location = new Point(310, 62);
			label3.Name = "label3";
			label3.Size = new Size(44, 17);
			label3.TabIndex = 14;
			label3.Text = "Отдел";
			// 
			// cbMedicineProductName
			// 
			cbMedicineProductName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			cbMedicineProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbMedicineProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbMedicineProductName.DropDownWidth = 250;
			cbMedicineProductName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbMedicineProductName.FormattingEnabled = true;
			cbMedicineProductName.Location = new Point(310, 28);
			cbMedicineProductName.Name = "cbMedicineProductName";
			cbMedicineProductName.Size = new Size(210, 25);
			cbMedicineProductName.TabIndex = 13;
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label4.Location = new Point(310, 9);
			label4.Name = "label4";
			label4.Size = new Size(87, 17);
			label4.TabIndex = 12;
			label4.Text = "Название ЛП";
			// 
			// cbPlace
			// 
			cbPlace.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			cbPlace.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbPlace.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbPlace.Enabled = false;
			cbPlace.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbPlace.FormattingEnabled = true;
			cbPlace.Location = new Point(94, 81);
			cbPlace.Name = "cbPlace";
			cbPlace.Size = new Size(210, 25);
			cbPlace.TabIndex = 11;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(94, 62);
			label2.Name = "label2";
			label2.Size = new Size(46, 17);
			label2.TabIndex = 10;
			label2.Text = "Место";
			// 
			// cbStorage
			// 
			cbStorage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			cbStorage.AutoCompleteMode = AutoCompleteMode.Suggest;
			cbStorage.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbStorage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cbStorage.FormattingEnabled = true;
			cbStorage.Location = new Point(94, 28);
			cbStorage.Name = "cbStorage";
			cbStorage.Size = new Size(210, 25);
			cbStorage.TabIndex = 9;
			cbStorage.SelectedIndexChanged += cbStorage_SelectedIndexChanged;
			// 
			// btnResetSearch
			// 
			btnResetSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			btnResetSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnResetSearch.Enabled = false;
			btnResetSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnResetSearch.Location = new Point(526, 78);
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
			btnSearch.Location = new Point(526, 28);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(162, 29);
			btnSearch.TabIndex = 1;
			btnSearch.Text = "Поиск";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(94, 9);
			label1.Name = "label1";
			label1.Size = new Size(43, 17);
			label1.TabIndex = 1;
			label1.Text = "Склад";
			// 
			// dgvStorageMedicineProducts
			// 
			dgvStorageMedicineProducts.AllowUserToAddRows = false;
			dgvStorageMedicineProducts.AllowUserToDeleteRows = false;
			dgvStorageMedicineProducts.AllowUserToOrderColumns = true;
			dgvStorageMedicineProducts.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvStorageMedicineProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvStorageMedicineProducts.ContextMenuStrip = contextMenuStrip1;
			dgvStorageMedicineProducts.Dock = DockStyle.Fill;
			dgvStorageMedicineProducts.Location = new Point(0, 0);
			dgvStorageMedicineProducts.MultiSelect = false;
			dgvStorageMedicineProducts.Name = "dgvStorageMedicineProducts";
			dgvStorageMedicineProducts.ReadOnly = true;
			dgvStorageMedicineProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvStorageMedicineProducts.Size = new Size(800, 326);
			dgvStorageMedicineProducts.TabIndex = 8;
			dgvStorageMedicineProducts.CellFormatting += dgvStorageMedicineProducts_CellFormatting;
			dgvStorageMedicineProducts.CellMouseDown += dgv_CellMouseDown;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// StorageMedicineProductsForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(splitContainer1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "StorageMedicineProductsForm";
			Text = "Склад лекарственных препаратов";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvStorageMedicineProducts).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private DataGridView dgvStorageMedicineProducts;
		private Label label1;
		private Button btnSearch;
		private Button btnResetSearch;
		private ContextMenuStrip contextMenuStrip1;
		private ComboBox cbPlace;
		private Label label2;
		private ComboBox cbStorage;
		private ComboBox cbDepartment;
		private Label label3;
		private ComboBox cbMedicineProductName;
		private Label label4;
	}
}