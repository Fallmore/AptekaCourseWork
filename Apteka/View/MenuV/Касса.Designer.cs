namespace Apteka.View.MenuV
{
    partial class Касса
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Касса));
			splitContainer1 = new SplitContainer();
			splitContainer3 = new SplitContainer();
			tsPickedMedicineProduct = new ToolStrip();
			toolStripLabel2 = new ToolStripLabel();
			tsbSale = new ToolStripButton();
			toolStripSeparator2 = new ToolStripSeparator();
			tsbResetPickedMedicineProduct = new ToolStripButton();
			toolStripSeparator6 = new ToolStripSeparator();
			tstbCost = new ToolStripTextBox();
			toolStripLabel3 = new ToolStripLabel();
			dgvPickedMedicineProduct = new DataGridView();
			splitContainer2 = new SplitContainer();
			tsMedicineProduct = new ToolStrip();
			toolStripLabel1 = new ToolStripLabel();
			toolStripSeparator1 = new ToolStripSeparator();
			tstbTexSearchtMP = new ToolStripTextBox();
			tsbSearchMP = new ToolStripButton();
			toolStripSeparator4 = new ToolStripSeparator();
			tsbResetSearchMP = new ToolStripButton();
			splitContainer4 = new SplitContainer();
			dgvStorageMedicineProduct = new DataGridView();
			splitContainer5 = new SplitContainer();
			toolStrip1 = new ToolStrip();
			toolStripLabel6 = new ToolStripLabel();
			toolStripSeparator3 = new ToolStripSeparator();
			tstbTextSearchAnaloguesMP = new ToolStripTextBox();
			tsbSearchAnaloguesMP = new ToolStripButton();
			toolStripSeparator5 = new ToolStripSeparator();
			tsbResetSearchAnaloguesMP = new ToolStripButton();
			dgvAnaloguesStorageMedicineProduct = new DataGridView();
			menuStrip1 = new MenuStrip();
			лекарстваToolStripMenuItem = new ToolStripMenuItem();
			лекарстваToolStripMenuItem1 = new ToolStripMenuItem();
			препаратыToolStripMenuItem = new ToolStripMenuItem();
			списанныеПрепаратыToolStripMenuItem = new ToolStripMenuItem();
			справкаToolStripMenuItem = new ToolStripMenuItem();
			cmsMedicineProduct = new ContextMenuStrip(components);
			contextMenuStrip1 = new ContextMenuStrip(components);
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
			splitContainer3.Panel1.SuspendLayout();
			splitContainer3.Panel2.SuspendLayout();
			splitContainer3.SuspendLayout();
			tsPickedMedicineProduct.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvPickedMedicineProduct).BeginInit();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			tsMedicineProduct.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
			splitContainer4.Panel1.SuspendLayout();
			splitContainer4.Panel2.SuspendLayout();
			splitContainer4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvStorageMedicineProduct).BeginInit();
			((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
			splitContainer5.Panel1.SuspendLayout();
			splitContainer5.Panel2.SuspendLayout();
			splitContainer5.SuspendLayout();
			toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvAnaloguesStorageMedicineProduct).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 29);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(splitContainer3);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(splitContainer2);
			splitContainer1.Size = new Size(800, 747);
			splitContainer1.SplitterDistance = 219;
			splitContainer1.TabIndex = 3;
			// 
			// splitContainer3
			// 
			splitContainer3.Dock = DockStyle.Fill;
			splitContainer3.Location = new Point(0, 0);
			splitContainer3.Name = "splitContainer3";
			splitContainer3.Orientation = Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			splitContainer3.Panel1.Controls.Add(tsPickedMedicineProduct);
			// 
			// splitContainer3.Panel2
			// 
			splitContainer3.Panel2.Controls.Add(dgvPickedMedicineProduct);
			splitContainer3.Size = new Size(800, 219);
			splitContainer3.SplitterDistance = 25;
			splitContainer3.TabIndex = 0;
			// 
			// tsPickedMedicineProduct
			// 
			tsPickedMedicineProduct.BackColor = SystemColors.ControlLight;
			tsPickedMedicineProduct.Items.AddRange(new ToolStripItem[] { toolStripLabel2, tsbSale, toolStripSeparator2, tsbResetPickedMedicineProduct, toolStripSeparator6, tstbCost, toolStripLabel3 });
			tsPickedMedicineProduct.Location = new Point(0, 0);
			tsPickedMedicineProduct.Name = "tsPickedMedicineProduct";
			tsPickedMedicineProduct.Size = new Size(800, 29);
			tsPickedMedicineProduct.TabIndex = 0;
			tsPickedMedicineProduct.Text = "toolStrip2";
			// 
			// toolStripLabel2
			// 
			toolStripLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			toolStripLabel2.Name = "toolStripLabel2";
			toolStripLabel2.Size = new Size(153, 26);
			toolStripLabel2.Text = "Лекарства к выдаче";
			// 
			// tsbSale
			// 
			tsbSale.Alignment = ToolStripItemAlignment.Right;
			tsbSale.BackColor = SystemColors.ActiveCaption;
			tsbSale.DisplayStyle = ToolStripItemDisplayStyle.Text;
			tsbSale.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tsbSale.Image = (Image)resources.GetObject("tsbSale.Image");
			tsbSale.ImageTransparentColor = Color.Magenta;
			tsbSale.Name = "tsbSale";
			tsbSale.Size = new Size(84, 26);
			tsbSale.Text = "ПРОДАТЬ";
			tsbSale.Click += tsbSale_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(6, 29);
			// 
			// tsbResetPickedMedicineProduct
			// 
			tsbResetPickedMedicineProduct.Alignment = ToolStripItemAlignment.Right;
			tsbResetPickedMedicineProduct.BackColor = SystemColors.ActiveCaption;
			tsbResetPickedMedicineProduct.DisplayStyle = ToolStripItemDisplayStyle.Text;
			tsbResetPickedMedicineProduct.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tsbResetPickedMedicineProduct.Image = (Image)resources.GetObject("tsbResetPickedMedicineProduct.Image");
			tsbResetPickedMedicineProduct.ImageTransparentColor = Color.Magenta;
			tsbResetPickedMedicineProduct.Name = "tsbResetPickedMedicineProduct";
			tsbResetPickedMedicineProduct.Size = new Size(153, 26);
			tsbResetPickedMedicineProduct.Text = "Отменить продажу";
			tsbResetPickedMedicineProduct.Click += tsbResetPickedMedicineProduct_Click;
			// 
			// toolStripSeparator6
			// 
			toolStripSeparator6.Alignment = ToolStripItemAlignment.Right;
			toolStripSeparator6.Name = "toolStripSeparator6";
			toolStripSeparator6.Size = new Size(6, 29);
			// 
			// tstbCost
			// 
			tstbCost.Alignment = ToolStripItemAlignment.Right;
			tstbCost.BorderStyle = BorderStyle.FixedSingle;
			tstbCost.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tstbCost.Name = "tstbCost";
			tstbCost.ReadOnly = true;
			tstbCost.Size = new Size(100, 29);
			tstbCost.Text = "0";
			// 
			// toolStripLabel3
			// 
			toolStripLabel3.Alignment = ToolStripItemAlignment.Right;
			toolStripLabel3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			toolStripLabel3.Name = "toolStripLabel3";
			toolStripLabel3.Size = new Size(192, 26);
			toolStripLabel3.Text = "ИТОГОВАЯ СТОИМОСТЬ:";
			// 
			// dgvPickedMedicineProduct
			// 
			dgvPickedMedicineProduct.AllowUserToAddRows = false;
			dgvPickedMedicineProduct.AllowUserToDeleteRows = false;
			dgvPickedMedicineProduct.AllowUserToOrderColumns = true;
			dgvPickedMedicineProduct.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvPickedMedicineProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvPickedMedicineProduct.Dock = DockStyle.Fill;
			dgvPickedMedicineProduct.Location = new Point(0, 0);
			dgvPickedMedicineProduct.MultiSelect = false;
			dgvPickedMedicineProduct.Name = "dgvPickedMedicineProduct";
			dgvPickedMedicineProduct.ReadOnly = true;
			dgvPickedMedicineProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvPickedMedicineProduct.Size = new Size(800, 190);
			dgvPickedMedicineProduct.TabIndex = 1;
			dgvPickedMedicineProduct.CellMouseDown += dgv_CellMouseDown;
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = DockStyle.Fill;
			splitContainer2.FixedPanel = FixedPanel.Panel1;
			splitContainer2.IsSplitterFixed = true;
			splitContainer2.Location = new Point(0, 0);
			splitContainer2.Name = "splitContainer2";
			splitContainer2.Orientation = Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(tsMedicineProduct);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(splitContainer4);
			splitContainer2.Size = new Size(800, 524);
			splitContainer2.SplitterDistance = 31;
			splitContainer2.TabIndex = 0;
			// 
			// tsMedicineProduct
			// 
			tsMedicineProduct.BackColor = SystemColors.ControlLight;
			tsMedicineProduct.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripSeparator1, tstbTexSearchtMP, tsbSearchMP, toolStripSeparator4, tsbResetSearchMP });
			tsMedicineProduct.Location = new Point(0, 0);
			tsMedicineProduct.Name = "tsMedicineProduct";
			tsMedicineProduct.Size = new Size(800, 29);
			tsMedicineProduct.TabIndex = 0;
			tsMedicineProduct.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			toolStripLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			toolStripLabel1.Name = "toolStripLabel1";
			toolStripLabel1.Size = new Size(157, 26);
			toolStripLabel1.Text = "Лекарства на складе";
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(6, 29);
			// 
			// tstbTexSearchtMP
			// 
			tstbTexSearchtMP.BorderStyle = BorderStyle.FixedSingle;
			tstbTexSearchtMP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tstbTexSearchtMP.ForeColor = SystemColors.WindowText;
			tstbTexSearchtMP.Name = "tstbTexSearchtMP";
			tstbTexSearchtMP.Size = new Size(250, 29);
			// 
			// tsbSearchMP
			// 
			tsbSearchMP.BackColor = SystemColors.ActiveCaption;
			tsbSearchMP.DisplayStyle = ToolStripItemDisplayStyle.Text;
			tsbSearchMP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tsbSearchMP.Image = (Image)resources.GetObject("tsbSearchMP.Image");
			tsbSearchMP.ImageTransparentColor = Color.Magenta;
			tsbSearchMP.Name = "tsbSearchMP";
			tsbSearchMP.Size = new Size(58, 26);
			tsbSearchMP.Text = "Поиск";
			tsbSearchMP.Click += tsbSearchMP_Click;
			// 
			// toolStripSeparator4
			// 
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new Size(6, 29);
			// 
			// tsbResetSearchMP
			// 
			tsbResetSearchMP.BackColor = SystemColors.ActiveCaption;
			tsbResetSearchMP.DisplayStyle = ToolStripItemDisplayStyle.Text;
			tsbResetSearchMP.Enabled = false;
			tsbResetSearchMP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tsbResetSearchMP.Image = (Image)resources.GetObject("tsbResetSearchMP.Image");
			tsbResetSearchMP.ImageTransparentColor = Color.Magenta;
			tsbResetSearchMP.Name = "tsbResetSearchMP";
			tsbResetSearchMP.Size = new Size(128, 26);
			tsbResetSearchMP.Text = "Сбросить поиск";
			tsbResetSearchMP.Click += tsbResetSearch_Click;
			// 
			// splitContainer4
			// 
			splitContainer4.Dock = DockStyle.Fill;
			splitContainer4.Location = new Point(0, 0);
			splitContainer4.Name = "splitContainer4";
			splitContainer4.Orientation = Orientation.Horizontal;
			// 
			// splitContainer4.Panel1
			// 
			splitContainer4.Panel1.Controls.Add(dgvStorageMedicineProduct);
			// 
			// splitContainer4.Panel2
			// 
			splitContainer4.Panel2.Controls.Add(splitContainer5);
			splitContainer4.Size = new Size(800, 489);
			splitContainer4.SplitterDistance = 244;
			splitContainer4.TabIndex = 2;
			// 
			// dgvStorageMedicineProduct
			// 
			dgvStorageMedicineProduct.AllowUserToAddRows = false;
			dgvStorageMedicineProduct.AllowUserToDeleteRows = false;
			dgvStorageMedicineProduct.AllowUserToOrderColumns = true;
			dgvStorageMedicineProduct.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvStorageMedicineProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvStorageMedicineProduct.Dock = DockStyle.Fill;
			dgvStorageMedicineProduct.Location = new Point(0, 0);
			dgvStorageMedicineProduct.MultiSelect = false;
			dgvStorageMedicineProduct.Name = "dgvStorageMedicineProduct";
			dgvStorageMedicineProduct.ReadOnly = true;
			dgvStorageMedicineProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvStorageMedicineProduct.Size = new Size(800, 244);
			dgvStorageMedicineProduct.TabIndex = 1;
			dgvStorageMedicineProduct.CellMouseDown += dgv_CellMouseDown;
			dgvStorageMedicineProduct.RowsAdded += dgvStorageMedicineProduct_RowsAdded;
			// 
			// splitContainer5
			// 
			splitContainer5.Dock = DockStyle.Fill;
			splitContainer5.FixedPanel = FixedPanel.Panel1;
			splitContainer5.Location = new Point(0, 0);
			splitContainer5.Name = "splitContainer5";
			splitContainer5.Orientation = Orientation.Horizontal;
			// 
			// splitContainer5.Panel1
			// 
			splitContainer5.Panel1.Controls.Add(toolStrip1);
			// 
			// splitContainer5.Panel2
			// 
			splitContainer5.Panel2.Controls.Add(dgvAnaloguesStorageMedicineProduct);
			splitContainer5.Size = new Size(800, 241);
			splitContainer5.SplitterDistance = 30;
			splitContainer5.TabIndex = 0;
			// 
			// toolStrip1
			// 
			toolStrip1.BackColor = SystemColors.ControlLight;
			toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel6, toolStripSeparator3, tstbTextSearchAnaloguesMP, tsbSearchAnaloguesMP, toolStripSeparator5, tsbResetSearchAnaloguesMP });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(800, 29);
			toolStrip1.TabIndex = 1;
			toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel6
			// 
			toolStripLabel6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			toolStripLabel6.Name = "toolStripLabel6";
			toolStripLabel6.Size = new Size(142, 26);
			toolStripLabel6.Text = "Аналоги на складе";
			// 
			// toolStripSeparator3
			// 
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new Size(6, 29);
			// 
			// tstbTextSearchAnaloguesMP
			// 
			tstbTextSearchAnaloguesMP.BorderStyle = BorderStyle.FixedSingle;
			tstbTextSearchAnaloguesMP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tstbTextSearchAnaloguesMP.Name = "tstbTextSearchAnaloguesMP";
			tstbTextSearchAnaloguesMP.Size = new Size(250, 29);
			// 
			// tsbSearchAnaloguesMP
			// 
			tsbSearchAnaloguesMP.BackColor = SystemColors.ActiveCaption;
			tsbSearchAnaloguesMP.DisplayStyle = ToolStripItemDisplayStyle.Text;
			tsbSearchAnaloguesMP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tsbSearchAnaloguesMP.Image = (Image)resources.GetObject("tsbSearchAnaloguesMP.Image");
			tsbSearchAnaloguesMP.ImageTransparentColor = Color.Magenta;
			tsbSearchAnaloguesMP.Name = "tsbSearchAnaloguesMP";
			tsbSearchAnaloguesMP.Size = new Size(58, 26);
			tsbSearchAnaloguesMP.Text = "Поиск";
			tsbSearchAnaloguesMP.Click += tsbSearchAnaloguesMP_Click;
			// 
			// toolStripSeparator5
			// 
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new Size(6, 29);
			// 
			// tsbResetSearchAnaloguesMP
			// 
			tsbResetSearchAnaloguesMP.BackColor = SystemColors.ActiveCaption;
			tsbResetSearchAnaloguesMP.DisplayStyle = ToolStripItemDisplayStyle.Text;
			tsbResetSearchAnaloguesMP.Enabled = false;
			tsbResetSearchAnaloguesMP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tsbResetSearchAnaloguesMP.Image = (Image)resources.GetObject("tsbResetSearchAnaloguesMP.Image");
			tsbResetSearchAnaloguesMP.ImageTransparentColor = Color.Magenta;
			tsbResetSearchAnaloguesMP.Name = "tsbResetSearchAnaloguesMP";
			tsbResetSearchAnaloguesMP.Size = new Size(128, 26);
			tsbResetSearchAnaloguesMP.Text = "Сбросить поиск";
			tsbResetSearchAnaloguesMP.Click += tsbResetSearch_Click;
			// 
			// dgvAnaloguesStorageMedicineProduct
			// 
			dgvAnaloguesStorageMedicineProduct.AllowUserToAddRows = false;
			dgvAnaloguesStorageMedicineProduct.AllowUserToDeleteRows = false;
			dgvAnaloguesStorageMedicineProduct.AllowUserToOrderColumns = true;
			dgvAnaloguesStorageMedicineProduct.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvAnaloguesStorageMedicineProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvAnaloguesStorageMedicineProduct.Dock = DockStyle.Fill;
			dgvAnaloguesStorageMedicineProduct.Location = new Point(0, 0);
			dgvAnaloguesStorageMedicineProduct.MultiSelect = false;
			dgvAnaloguesStorageMedicineProduct.Name = "dgvAnaloguesStorageMedicineProduct";
			dgvAnaloguesStorageMedicineProduct.ReadOnly = true;
			dgvAnaloguesStorageMedicineProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvAnaloguesStorageMedicineProduct.Size = new Size(800, 207);
			dgvAnaloguesStorageMedicineProduct.TabIndex = 2;
			dgvAnaloguesStorageMedicineProduct.CellMouseDown += dgv_CellMouseDown;
			// 
			// menuStrip1
			// 
			menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			menuStrip1.Items.AddRange(new ToolStripItem[] { лекарстваToolStripMenuItem, справкаToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(800, 29);
			menuStrip1.TabIndex = 2;
			menuStrip1.Text = "menuStrip1";
			// 
			// лекарстваToolStripMenuItem
			// 
			лекарстваToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { лекарстваToolStripMenuItem1, препаратыToolStripMenuItem, списанныеПрепаратыToolStripMenuItem });
			лекарстваToolStripMenuItem.Name = "лекарстваToolStripMenuItem";
			лекарстваToolStripMenuItem.Size = new Size(110, 25);
			лекарстваToolStripMenuItem.Text = "Справочник";
			// 
			// лекарстваToolStripMenuItem1
			// 
			лекарстваToolStripMenuItem1.Name = "лекарстваToolStripMenuItem1";
			лекарстваToolStripMenuItem1.Size = new Size(251, 26);
			лекарстваToolStripMenuItem1.Text = "Лекарства...";
			лекарстваToolStripMenuItem1.Click += лекарстваToolStripMenuItem1_Click;
			// 
			// препаратыToolStripMenuItem
			// 
			препаратыToolStripMenuItem.Name = "препаратыToolStripMenuItem";
			препаратыToolStripMenuItem.Size = new Size(251, 26);
			препаратыToolStripMenuItem.Text = "Препараты...";
			препаратыToolStripMenuItem.Click += препаратыToolStripMenuItem_Click;
			// 
			// списанныеПрепаратыToolStripMenuItem
			// 
			списанныеПрепаратыToolStripMenuItem.Name = "списанныеПрепаратыToolStripMenuItem";
			списанныеПрепаратыToolStripMenuItem.Size = new Size(251, 26);
			списанныеПрепаратыToolStripMenuItem.Text = "Списанные препараты...";
			списанныеПрепаратыToolStripMenuItem.Click += списанныеПрепаратыToolStripMenuItem_Click;
			// 
			// справкаToolStripMenuItem
			// 
			справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
			справкаToolStripMenuItem.Size = new Size(82, 25);
			справкаToolStripMenuItem.Text = "Справка";
			справкаToolStripMenuItem.Click += справкаToolStripMenuItem_Click;
			// 
			// cmsMedicineProduct
			// 
			cmsMedicineProduct.Name = "contextMenuStrip1";
			cmsMedicineProduct.Size = new Size(61, 4);
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// Касса
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 776);
			Controls.Add(splitContainer1);
			Controls.Add(menuStrip1);
			MaximizeBox = false;
			Name = "Касса";
			Text = "КАССА";
			WindowState = FormWindowState.Maximized;
			FormClosing += Касса_FormClosing;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			splitContainer3.Panel1.ResumeLayout(false);
			splitContainer3.Panel1.PerformLayout();
			splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
			splitContainer3.ResumeLayout(false);
			tsPickedMedicineProduct.ResumeLayout(false);
			tsPickedMedicineProduct.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvPickedMedicineProduct).EndInit();
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel1.PerformLayout();
			splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			tsMedicineProduct.ResumeLayout(false);
			tsMedicineProduct.PerformLayout();
			splitContainer4.Panel1.ResumeLayout(false);
			splitContainer4.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
			splitContainer4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvStorageMedicineProduct).EndInit();
			splitContainer5.Panel1.ResumeLayout(false);
			splitContainer5.Panel1.PerformLayout();
			splitContainer5.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
			splitContainer5.ResumeLayout(false);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvAnaloguesStorageMedicineProduct).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private SplitContainer splitContainer1;
        private SplitContainer splitContainer3;
        private ToolStrip tsPickedMedicineProduct;
        private ToolStripLabel toolStripLabel2;
        private ToolStripSeparator toolStripSeparator2;
        private SplitContainer splitContainer2;
        private ToolStrip tsMedicineProduct;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox tstbTexSearchtMP;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem лекарстваToolStripMenuItem;
        private ToolStripTextBox tstbCost;
		private DataGridView dgvPickedMedicineProduct;
		private DataGridView dgvStorageMedicineProduct;
		private ToolStripLabel toolStripLabel3;
		private ToolStripButton tsbSale;
		private SplitContainer splitContainer4;
		private SplitContainer splitContainer5;
		private ToolStrip toolStrip1;
		private ToolStripLabel toolStripLabel6;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripTextBox tstbTextSearchAnaloguesMP;
		private DataGridView dgvAnaloguesStorageMedicineProduct;
		private ContextMenuStrip cmsMedicineProduct;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripButton tsbSearchMP;
		private ToolStripButton tsbSearchAnaloguesMP;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripButton tsbResetSearchMP;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripButton tsbResetSearchAnaloguesMP;
		private ToolStripButton tsbResetPickedMedicineProduct;
		private ToolStripSeparator toolStripSeparator6;
		private ToolStripMenuItem лекарстваToolStripMenuItem1;
		private ToolStripMenuItem препаратыToolStripMenuItem;
		private ToolStripMenuItem списанныеПрепаратыToolStripMenuItem;
		private ToolStripMenuItem справкаToolStripMenuItem;
	}
}