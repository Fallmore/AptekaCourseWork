using Apteka.View;

namespace Apteka.View.MedicineV
{
	partial class MedicineProductsForm
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
			chbExtendedSearch = new CheckBox();
			btnOpenExtendedSearch = new Button();
			btnResetSearch = new Button();
			btnSearch = new Button();
			label1 = new Label();
			tbTextSearch = new TextBox();
			splitContainer2 = new SplitContainer();
			dgvMedicineProduct = new DataGridView();
			dgvMedicineProductCost = new DataGridView();
			cmsMedicineProductCost = new ContextMenuStrip(components);
			cmsMedicineProduct = new ContextMenuStrip(components);
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvMedicineProduct).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvMedicineProductCost).BeginInit();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.FixedPanel = FixedPanel.Panel1;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(chbExtendedSearch);
			splitContainer1.Panel1.Controls.Add(btnOpenExtendedSearch);
			splitContainer1.Panel1.Controls.Add(btnResetSearch);
			splitContainer1.Panel1.Controls.Add(btnSearch);
			splitContainer1.Panel1.Controls.Add(label1);
			splitContainer1.Panel1.Controls.Add(tbTextSearch);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(splitContainer2);
			splitContainer1.Size = new Size(800, 647);
			splitContainer1.SplitterDistance = 75;
			splitContainer1.SplitterWidth = 5;
			splitContainer1.TabIndex = 0;
			// 
			// chbExtendedSearch
			// 
			chbExtendedSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			chbExtendedSearch.AutoSize = true;
			chbExtendedSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			chbExtendedSearch.Location = new Point(260, 8);
			chbExtendedSearch.Name = "chbExtendedSearch";
			chbExtendedSearch.Size = new Size(148, 21);
			chbExtendedSearch.TabIndex = 8;
			chbExtendedSearch.Text = "Расширенный поиск";
			chbExtendedSearch.UseVisualStyleBackColor = true;
			chbExtendedSearch.CheckedChanged += chbExtendedSearch_CheckedChanged;
			// 
			// btnOpenExtendedSearch
			// 
			btnOpenExtendedSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			btnOpenExtendedSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnOpenExtendedSearch.Enabled = false;
			btnOpenExtendedSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnOpenExtendedSearch.Location = new Point(260, 31);
			btnOpenExtendedSearch.Name = "btnOpenExtendedSearch";
			btnOpenExtendedSearch.Size = new Size(192, 33);
			btnOpenExtendedSearch.TabIndex = 3;
			btnOpenExtendedSearch.Text = "Открыть параметры поиска";
			btnOpenExtendedSearch.UseVisualStyleBackColor = true;
			btnOpenExtendedSearch.Click += btnOpenExtendedSearch_Click;
			// 
			// btnResetSearch
			// 
			btnResetSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			btnResetSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnResetSearch.Enabled = false;
			btnResetSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnResetSearch.Location = new Point(626, 33);
			btnResetSearch.Name = "btnResetSearch";
			btnResetSearch.Size = new Size(162, 33);
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
			btnSearch.Location = new Point(458, 32);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(162, 33);
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
			label1.Location = new Point(12, 10);
			label1.Name = "label1";
			label1.Size = new Size(208, 17);
			label1.TabIndex = 1;
			label1.Text = "Название/МНН/Серийный номер";
			// 
			// tbTextSearch
			// 
			tbTextSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			tbTextSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbTextSearch.Location = new Point(12, 33);
			tbTextSearch.Name = "tbTextSearch";
			tbTextSearch.Size = new Size(242, 27);
			tbTextSearch.TabIndex = 0;
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = DockStyle.Fill;
			splitContainer2.FixedPanel = FixedPanel.Panel2;
			splitContainer2.Location = new Point(0, 0);
			splitContainer2.Name = "splitContainer2";
			splitContainer2.Orientation = Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(dgvMedicineProduct);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(dgvMedicineProductCost);
			splitContainer2.Size = new Size(800, 567);
			splitContainer2.SplitterDistance = 346;
			splitContainer2.SplitterWidth = 5;
			splitContainer2.TabIndex = 9;
			// 
			// dgvMedicineProduct
			// 
			dgvMedicineProduct.AllowUserToAddRows = false;
			dgvMedicineProduct.AllowUserToDeleteRows = false;
			dgvMedicineProduct.AllowUserToOrderColumns = true;
			dgvMedicineProduct.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvMedicineProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvMedicineProduct.Dock = DockStyle.Fill;
			dgvMedicineProduct.Location = new Point(0, 0);
			dgvMedicineProduct.MultiSelect = false;
			dgvMedicineProduct.Name = "dgvMedicineProduct";
			dgvMedicineProduct.ReadOnly = true;
			dgvMedicineProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvMedicineProduct.Size = new Size(800, 346);
			dgvMedicineProduct.TabIndex = 8;
			dgvMedicineProduct.CellFormatting += dgvMedicineProduct_CellFormatting;
			dgvMedicineProduct.CellMouseDown += dgv_CellMouseDown;
			dgvMedicineProduct.SelectionChanged += dgvMedicineProduct_SelectionChanged;
			// 
			// dgvMedicineProductCost
			// 
			dgvMedicineProductCost.AllowUserToAddRows = false;
			dgvMedicineProductCost.AllowUserToDeleteRows = false;
			dgvMedicineProductCost.AllowUserToOrderColumns = true;
			dgvMedicineProductCost.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvMedicineProductCost.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvMedicineProductCost.Dock = DockStyle.Fill;
			dgvMedicineProductCost.Location = new Point(0, 0);
			dgvMedicineProductCost.MultiSelect = false;
			dgvMedicineProductCost.Name = "dgvMedicineProductCost";
			dgvMedicineProductCost.ReadOnly = true;
			dgvMedicineProductCost.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvMedicineProductCost.Size = new Size(800, 216);
			dgvMedicineProductCost.TabIndex = 9;
			dgvMedicineProductCost.CellMouseDown += dgv_CellMouseDown;
			dgvMedicineProductCost.MouseDown += dgvMedicineProductCost_MouseDown;
			// 
			// cmsMedicineProductCost
			// 
			cmsMedicineProductCost.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			cmsMedicineProductCost.Name = "cmsMedicineProductCost";
			cmsMedicineProductCost.Size = new Size(61, 4);
			// 
			// cmsMedicineProduct
			// 
			cmsMedicineProduct.Name = "contextMenuStrip1";
			cmsMedicineProduct.Size = new Size(61, 4);
			// 
			// MedicineProductsForm
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 647);
			Controls.Add(splitContainer1);
			Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "MedicineProductsForm";
			Text = "Лекарственные препараты";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvMedicineProduct).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvMedicineProductCost).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private DataGridView dgvMedicineProduct;
		private TextBox tbTextSearch;
		private Label label1;
		private Button btnSearch;
		private Button btnResetSearch;
		private Button btnOpenExtendedSearch;
		private CheckBox chbExtendedSearch;
		private ContextMenuStrip cmsMedicineProduct;
		private SplitContainer splitContainer2;
		private DataGridView dgvMedicineProductCost;
		private ContextMenuStrip cmsMedicineProductCost;
	}
}