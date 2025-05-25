namespace Apteka
{
	partial class MedicinesForm
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
			btnResetSearch = new Button();
			btnSearch = new Button();
			label4 = new Label();
			tbConditionRelease = new TextBox();
			label3 = new Label();
			tbPharmGroup = new TextBox();
			label2 = new Label();
			tbMNN = new TextBox();
			label1 = new Label();
			tbName = new TextBox();
			dgvMedicine = new DataGridView();
			contextMenuStrip1 = new ContextMenuStrip(components);
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvMedicine).BeginInit();
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
			splitContainer1.Panel1.Controls.Add(btnResetSearch);
			splitContainer1.Panel1.Controls.Add(btnSearch);
			splitContainer1.Panel1.Controls.Add(label4);
			splitContainer1.Panel1.Controls.Add(tbConditionRelease);
			splitContainer1.Panel1.Controls.Add(label3);
			splitContainer1.Panel1.Controls.Add(tbPharmGroup);
			splitContainer1.Panel1.Controls.Add(label2);
			splitContainer1.Panel1.Controls.Add(tbMNN);
			splitContainer1.Panel1.Controls.Add(label1);
			splitContainer1.Panel1.Controls.Add(tbName);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(dgvMedicine);
			splitContainer1.Size = new Size(800, 450);
			splitContainer1.SplitterDistance = 120;
			splitContainer1.TabIndex = 0;
			// 
			// btnResetSearch
			// 
			btnResetSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			btnResetSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnResetSearch.Enabled = false;
			btnResetSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnResetSearch.Location = new Point(584, 76);
			btnResetSearch.Name = "btnResetSearch";
			btnResetSearch.Size = new Size(136, 33);
			btnResetSearch.TabIndex = 9;
			btnResetSearch.Text = "Сбросить поиск";
			btnResetSearch.UseVisualStyleBackColor = true;
			btnResetSearch.Click += btnResetSearch_Click;
			// 
			// btnSearch
			// 
			btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			btnSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			btnSearch.Location = new Point(584, 27);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(136, 29);
			btnSearch.TabIndex = 8;
			btnSearch.Text = "Поиск";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label4.Location = new Point(336, 59);
			label4.Name = "label4";
			label4.Size = new Size(106, 17);
			label4.TabIndex = 7;
			label4.Text = "Условие отпуска";
			// 
			// tbConditionRelease
			// 
			tbConditionRelease.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			tbConditionRelease.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbConditionRelease.Location = new Point(336, 79);
			tbConditionRelease.Name = "tbConditionRelease";
			tbConditionRelease.Size = new Size(242, 27);
			tbConditionRelease.TabIndex = 6;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label3.Location = new Point(336, 8);
			label3.Name = "label3";
			label3.Size = new Size(88, 17);
			label3.TabIndex = 5;
			label3.Text = "Фарм. группа";
			// 
			// tbPharmGroup
			// 
			tbPharmGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			tbPharmGroup.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbPharmGroup.Location = new Point(336, 28);
			tbPharmGroup.Name = "tbPharmGroup";
			tbPharmGroup.Size = new Size(242, 27);
			tbPharmGroup.TabIndex = 4;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(76, 59);
			label2.Name = "label2";
			label2.Size = new Size(38, 17);
			label2.TabIndex = 3;
			label2.Text = "МНН";
			// 
			// tbMNN
			// 
			tbMNN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			tbMNN.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbMNN.Location = new Point(76, 79);
			tbMNN.Name = "tbMNN";
			tbMNN.Size = new Size(242, 27);
			tbMNN.TabIndex = 2;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(76, 8);
			label1.Name = "label1";
			label1.Size = new Size(65, 17);
			label1.TabIndex = 1;
			label1.Text = "Название";
			// 
			// tbName
			// 
			tbName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			tbName.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			tbName.Location = new Point(76, 28);
			tbName.Name = "tbName";
			tbName.Size = new Size(242, 27);
			tbName.TabIndex = 0;
			// 
			// dgvMedicine
			// 
			dgvMedicine.AllowUserToAddRows = false;
			dgvMedicine.AllowUserToDeleteRows = false;
			dgvMedicine.AllowUserToOrderColumns = true;
			dgvMedicine.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			dgvMedicine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvMedicine.ContextMenuStrip = contextMenuStrip1;
			dgvMedicine.Dock = DockStyle.Fill;
			dgvMedicine.Location = new Point(0, 0);
			dgvMedicine.MultiSelect = false;
			dgvMedicine.Name = "dgvMedicine";
			dgvMedicine.ReadOnly = true;
			dgvMedicine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvMedicine.Size = new Size(800, 326);
			dgvMedicine.TabIndex = 0;
			dgvMedicine.CellMouseDown += dgv_CellMouseDown;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// MedicinesForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(splitContainer1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "MedicinesForm";
			Text = "Лекарства";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvMedicine).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private DataGridView dgvMedicine;
		private TextBox tbName;
		private Label label3;
		private TextBox tbPharmGroup;
		private Label label2;
		private TextBox tbMNN;
		private Label label1;
		private Button btnSearch;
		private Label label4;
		private TextBox tbConditionRelease;
		private Button btnResetSearch;
		private ContextMenuStrip contextMenuStrip1;
	}
}