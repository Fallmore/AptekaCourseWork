using Apteka.BaseClasses;
using Apteka.Model;
using Apteka.View;
using Apteka.View.Medicine;
using Apteka.View.SimpleV;
using Apteka.ViewModel.MedicineVM;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Data;

namespace Apteka
{
	public partial class MedicineProductsForm : FormWithNotification
	{
		private MedicineProductsViewModel _viewModel;
		private string[] _keyContexMenuItems = ["Показать списание", "Списание препарата", "Добавить упаковку и цену"];
		private int _indexRow = -1,
			_indexCell = -1;
		internal int IdMedicine = -1;
		internal string
			TextSearch = "",
			SerialNumber = "",
			MedicineForm = "",
			WayEnter = "",
			PackagingForm = "",
			Producer = "",
			PharmGroup = "",
			ConditionRelease = "",
			StorageCondition = "",
			Component = "",
			ComponentMeasure = "",
			Decommissioned = "",
			Expired = "";
		internal DateOnly
			DateReleaseMin,
			DateReleaseMax,
			DateExpirationMin,
			DateExpirationMax;

		public MedicineProductsForm()
		{
			InitializeComponent();
			_viewModel = new();
			_viewModel.ConfigureSettingsDGV<MedicineProductWrapper>(dgvMedicineProduct);
			_viewModel.SetDefaultDataSourceMedicineProduct(dgvMedicineProduct);
			_viewModel.ConfigureSettingsDGV<MedicineCost>(dgvMedicineProductCost);
			_viewModel.SetDefaultDataSourceMedicineProductCost(dgvMedicineProductCost);
			SetDefaultDates();
			SetCmsMedicineProductItems();
			SetCmsMedicineProductCostItems();
			SubscribeTable();
		}

		private void SubscribeTable()
		{
			_viewModel.General.DatabaseNotificationService.Subscribe<MedicineProductsForm>("medicine_product",
				data =>
				{
					RefreshData<MedicineProduct>(_viewModel.General.MedicineProducts,
					value => _viewModel.General.MedicineProducts = value, data,
					() => _viewModel.SetDefaultDataSourceMedicineProduct(dgvMedicineProduct));

				});

			_viewModel.General.DatabaseNotificationService.Subscribe<MedicineProductsForm>("medicine_cost",
				data =>
				{
					RefreshData<MedicineCost>(_viewModel.General.MedicineCosts,
					value => _viewModel.General.MedicineCosts = value, data,
					() => ShowCost(dgvMedicineProduct.SelectedRows[0]));

				});
		}

		private void SetCmsMedicineProductItems()
		{
			cmsMedicineProduct.Items.Add("Показать лекарство", null,
				(s, e) => ShowMedicine());

			cmsMedicineProduct.Items.Add("Показать аналоги", null,
				(s, e) => ShowAnalogues());

			cmsMedicineProduct.Items.Add("Показать на складе", null,
				(s, e) => ShowProductInStorage());

			cmsMedicineProduct.Items.Add("Показать продажи", null,
				(s, e) => ShowHistorySale());

			cmsMedicineProduct.Items.Add("-");

			cmsMedicineProduct.Items.Add("Показать списание", null,
				(s, e) => ShowDecommission());
			cmsMedicineProduct.Items[cmsMedicineProduct.Items.Count - 1].Name = _keyContexMenuItems[0];

			cmsMedicineProduct.Items.Add("Подтвердить факт списания", null,
				(s, e) => Decommission(IsExpired()));
			cmsMedicineProduct.Items[cmsMedicineProduct.Items.Count - 1].Name = _keyContexMenuItems[1];

			cmsMedicineProduct.Items.Add("-");

			cmsMedicineProduct.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvMedicineProduct.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
		}

		private void SetCmsMedicineProductCostItems()
		{
			cmsMedicineProductCost.Items.Add("Изменить данные", null,
				(s, e) => ChangeDataCost());

			cmsMedicineProductCost.Items.Add("Добавить упаковку и цену", null,
				(s, e) => AddDataCost());
			cmsMedicineProduct.Items[cmsMedicineProduct.Items.Count - 1].Name = _keyContexMenuItems[2];

			cmsMedicineProductCost.Items.Add("-");

			cmsMedicineProductCost.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvMedicineProduct.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
		}

		#region Всё, что связано с поиском

		private string[] GetStrParameters(bool isForExtendedParameters)
		{
			if (isForExtendedParameters)
				return [SerialNumber, MedicineForm, WayEnter,
								PackagingForm, Producer, PharmGroup, StorageCondition,
								ConditionRelease, Component, ComponentMeasure, Decommissioned, Expired];
			else
				return [TextSearch, PharmGroup,
								ConditionRelease, Component, ComponentMeasure];
		}

		private DateOnly?[] GetDoParameters()
		{
			return [DateReleaseMin, DateReleaseMax, DateExpirationMin, DateExpirationMax];
		}

		/// <summary>
		/// Устанавливает значения элементов формы
		/// </summary>
		/// <param name="strParams">Обязательны следующие параметры: SerialNumber,
		/// MedicineForm, WayEnter, PackagingForm, Producer, PharmGroup, ConditionRelease,
		/// Component, ComponentMeasure, Decommissioned</param>
		/// <param name="dtParams">Обязательны следующие параметры: DateReleaseMin, 
		/// DateReleaseMax, DateExpirationMin, DateExpirationMax</param>
		internal void SetParameters(string[] strParams, DateOnly[] dtParams)
		{
			SerialNumber = strParams[0];
			MedicineForm = strParams[1];
			WayEnter = strParams[2];
			PackagingForm = strParams[3];
			Producer = strParams[4];
			PharmGroup = strParams[5];
			StorageCondition = strParams[6];
			ConditionRelease = strParams[7];
			Component = strParams[8];
			ComponentMeasure = strParams[9];
			Decommissioned = strParams[10];
			Expired = strParams[11];

			DateReleaseMin = dtParams[0];
			DateReleaseMax = dtParams[1];
			DateExpirationMin = dtParams[2];
			DateExpirationMax = dtParams[3];
		}

		private async void SearchMedicineProduct(bool isExtendedSearch)
		{
			MedicineProduct mp = new()
			{
				SerialNumber = this.SerialNumber,
				Form = this.MedicineForm,
				WayEnter = this.WayEnter,
				PackagingForm = this.PackagingForm,
				Producer = this.Producer,
				StorageCondition = this.StorageCondition,
			};

			List<MedicineProduct>? results = await _viewModel.SearchMedicineProductAsync(
				mp, GetStrParameters(false), GetDoParameters(),
		Decommissioned, Expired, isExtendedSearch);

			if (results == null) return;

			if (results.Count == 0)
			{
				MessageBox.Show("ЛП не найдено", "Поиск ЛП",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			dgvMedicineProduct.DataSource = new SortableBindingList<MedicineProductWrapper>(
			MedicineProductWrapper.ToList(results));
			btnResetSearch.Enabled = true;
		}

		internal void SearchMedicineProductFromMedicinesForm(int idMedicine, string mnn)
		{
			IdMedicine = idMedicine;
			TextSearch = mnn;
			tbTextSearch.Text = TextSearch;
			SearchMedicineProduct(false);
			IdMedicine = -1;
		}

		internal void SearchMedicineProductFromOtherForm(string serialNumber)
		{
			TextSearch = serialNumber;
			IdMedicine = -1;
			tbTextSearch.Text = TextSearch;
			SearchMedicineProduct(false);
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			TextSearch = tbTextSearch.Text;
			SearchMedicineProduct(chbExtendedSearch.Checked);
		}

		private void btnResetSearch_Click(object sender, EventArgs e)
		{
			_viewModel.SetDefaultDataSourceMedicineProduct(dgvMedicineProduct);
			btnResetSearch.Enabled = false;
		}

		private void chbExtendedSearch_CheckedChanged(object sender, EventArgs e)
		{
			btnOpenExtendedSearch.Enabled = chbExtendedSearch.Checked;
		}

		private void btnOpenExtendedSearch_Click(object sender, EventArgs e)
		{
			ExtendedSearchMedicneProducts? esmp = new();

			esmp.SetDataSourceToComboBoxes(_viewModel.GetMedicineForms(), _viewModel.GetWayEnters(),
				_viewModel.GetPackagingForms(), _viewModel.GetProducers());
			esmp.SetParameters(GetStrParameters(true), GetDoParameters());

			if (esmp.ShowDialog() == DialogResult.OK)
				SetParameters(esmp.GetStrParameters(), esmp.GetDoParameters());
		}

		private void SetDefaultDates()
		{
			DateOnly[] dates = _viewModel.GetMinMaxDatesMedicineProducts();
			if (dates.Length == 0) return;

			if (DateReleaseMin == new DateOnly()) DateReleaseMin = dates[0];
			if (DateReleaseMax == new DateOnly()) DateReleaseMax = dates[1];
			if (DateExpirationMin == new DateOnly()) DateExpirationMin = dates[2];
			if (DateExpirationMax == new DateOnly()) DateExpirationMax = dates[3];
		}
		#endregion

		private void ShowCost(DataGridViewRow row)
		{
			int idMedicine = int.Parse(row.Cells["IdMedicine"].Value.ToString());
			List<MedicineCost> costs = _viewModel.General.MedicineCosts
				.Where(mc => mc.IdMedicine == idMedicine).ToList();
			dgvMedicineProductCost.DataSource = new SortableBindingList<MedicineCost>(costs);

			if (dgvMedicineProductCost.Columns.Contains("IdMedicine"))
				dgvMedicineProductCost.Columns["IdMedicine"].Visible = false;
		}

		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (sender is DataGridView dgv && e.RowIndex != -1)
			{
				_indexRow = e.RowIndex;
				_indexCell = e.ColumnIndex;
				DataGridViewRow row = dgv.Rows[e.RowIndex];
				row.Selected = true;
				if (dgv.Name == "dgvMedicineProduct")
				{
					bool isDecommissioned = row.Cells["Decommissioned"].Value.ToString() == "Да";
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
					cmsMedicineProduct.Items[_keyContexMenuItems[0]].Visible = isDecommissioned;
					cmsMedicineProduct.Items[_keyContexMenuItems[1]].Visible = !isDecommissioned;
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
					ShowCost(row);
					if (MouseButtons.Right == e.Button)
						cmsMedicineProduct.Show(Cursor.Position);
				}
				else
				{
					cmsMedicineProductCost.Items[0].Visible =
						cmsMedicineProductCost.Items[2].Visible =
						cmsMedicineProductCost.Items[3].Visible = true;
					cmsMedicineProductCost.Items[1].Visible = false;
					if (MouseButtons.Right == e.Button)
						cmsMedicineProductCost.Show(Cursor.Position);
				}
			}
		}

		private void dgvMedicineProductCost_MouseDown(object sender, MouseEventArgs e)
		{
			if (sender is DataGridView dgv)
			{
				if (dgv.Name == "dgvMedicineProductCost")
				{
					cmsMedicineProductCost.Items[0].Visible =
						cmsMedicineProductCost.Items[2].Visible =
						cmsMedicineProductCost.Items[3].Visible = false;
					cmsMedicineProductCost.Items[1].Visible = true;
					if (MouseButtons.Right == e.Button)
						cmsMedicineProductCost.Show(Cursor.Position);
				}
			}
		}

		private void dgvMedicineProduct_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvMedicineProduct.SelectedRows.Count != 0 && !dgvMedicineProduct.CurrentRow.IsNewRow)
			{
				DataGridViewRow selectedRow = dgvMedicineProduct.SelectedRows[0];

				ShowCost(selectedRow);
			}
		}

		private bool IsExpired()
		{
			return DateOnly.Parse(dgvMedicineProduct.SelectedRows[0].Cells["DateExpiration"].Value?.ToString() ?? "")
					<= DateOnly.FromDateTime(DateTime.Now).AddDays(_viewModel.General.CriticalTimeOfExpiration.Days);
		}

		private void dgvMedicineProduct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

			DataGridViewRow row = dgvMedicineProduct.Rows[e.RowIndex];

			if (row.Cells["Decommissioned"].Value.ToString() == "Да")
			{
				e.CellStyle.BackColor = Color.LightPink;
				e.CellStyle.ForeColor = Color.DarkRed;
				e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
				e.CellStyle.SelectionForeColor = Color.Black;
			}
			else
			{
				bool isExpired = DateOnly.Parse(row.Cells["DateExpiration"].Value.ToString())
					<= DateOnly.FromDateTime(DateTime.Now).AddDays(_viewModel.General.CriticalTimeOfExpiration.Days);
				if (isExpired)
				{
					e.CellStyle.BackColor = Color.LightYellow;
					e.CellStyle.ForeColor = Color.DarkGray;
					e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
					e.CellStyle.SelectionForeColor = Color.Black;
				}
			}
		}

		#region Всё, что связано с вызовом форм
		private void ShowMedicine()
		{
			MedicinesForm? mf = _viewModel.General.GetActivatedForm<MedicinesForm>();

			if (mf == null)
			{
				mf = new();
				mf.Show();
			}

			MedicineProduct mp = _viewModel.General.MedicineProducts
				.Find(m =>
					m.SerialNumber == dgvMedicineProduct.SelectedRows[0].Cells["SerialNumber"].Value.ToString())
					?? new();

			mf.SearchMedicineFromMedicineProductsForm(mp.IdMedicine);
		}

		private void ShowProductInStorage()
		{
			StorageMedicineProductsForm? msf = _viewModel.General.GetActivatedForm<StorageMedicineProductsForm>();

			if (msf == null)
			{
				msf = new();
				msf.Show();
			}

			string medicineProductName = dgvMedicineProduct.SelectedRows[0].Cells["Name"].Value.ToString() ?? "";

			msf.SearchStorageMedicineProductFromMedicineProductsForm(medicineProductName);
		}

		private void ShowHistorySale()
		{
			HistorySalesForm? hsf = _viewModel.General.GetActivatedForm<HistorySalesForm>();

			if (hsf == null)
			{
				hsf = new();
				hsf.Show();
			}

			string medicineProductName = dgvMedicineProduct.SelectedRows[0].Cells["Name"].Value.ToString() ?? string.Empty;
			hsf.SearchSaleFromOtherForm([string.Empty, string.Empty, string.Empty, medicineProductName, string.Empty]);
		}

		private void ShowDecommission()
		{
			MedicineProductDecommissionedForm? mpdf = _viewModel.General.GetActivatedForm<MedicineProductDecommissionedForm>();

			if (mpdf == null)
			{
				mpdf = new();
				mpdf.Show();
			}

			string medicineProductName = dgvMedicineProduct.SelectedRows[0].Cells["Name"].Value.ToString() ?? string.Empty;
			mpdf.SearchMedicineProductDecommissionedFromOtherForm(medicineProductName);
		}

		private void ShowAnalogues()
		{
			MedicineProductsForm mpf = new();
			DataGridViewRow row = dgvMedicineProduct.SelectedRows[0];
			Guid idMedicineProduct = Guid.Parse(row.Cells["IdMedicineProduct"].Value.ToString() ?? "");
			List<MedicineProduct> mp = mpf._viewModel.GetMedicineProductAnalogues(idMedicineProduct);
			mpf._viewModel.SetDataSourceMedicineProduct(mpf.dgvMedicineProduct, mp);

			mpf.Text = "Аналоги " + row.Cells["Name"].Value.ToString();
			mpf.Show();
			if (mp.Count == 0)
				MessageBox.Show("Аналоги не найдены", mpf.Text,
						MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#endregion

		#region Всё, что связано с изменениями данных
		private void Decommission(bool isExpired)
		{

			DataGridViewRow row = dgvMedicineProduct.SelectedRows[0];
			Guid idMedicineProduct = new(row.Cells["IdMedicineProduct"].Value.ToString() ?? string.Empty);
			string reason = "Просрочено";
			DialogResult dlgRsult = DialogResult.Cancel;

			if (!isExpired)
			{
				ReasonForm rf = new();
				rf.Text = "Причина списания " + row.Cells["Name"].Value.ToString();
				dlgRsult = rf.ShowDialog();
				if (dlgRsult == DialogResult.OK)
					reason = rf.rtbReason.Text;
			}

			if (dlgRsult == DialogResult.OK)
				_viewModel.Decommission(idMedicineProduct, reason);
		}

		private void ChangeDataCost()
		{
			MedicineCostDataForm mcdf = new();

			mcdf.cbPackagingForm.DataSource = _viewModel.General.MedicinePackagingForms
				.Select(mpf => mpf.PackagingForm).ToList();

			DataGridViewRow row = dgvMedicineProductCost.SelectedRows[0];
			int idMedicine = int.Parse(row.Cells["IdMedicine"].Value.ToString() ?? "");
			float cost = float.Parse(row.Cells["Cost"].Value.ToString() ?? "0");
			string oldPackagingForm = row.Cells["PackagingForm"].Value.ToString() ?? "";

			mcdf.cbPackagingForm.SelectedItem = oldPackagingForm;
			mcdf.tbCost.Text = cost.ToString();

			if (mcdf.ShowDialog() == DialogResult.OK)
			{
				_viewModel.UpdateMedicineCost(idMedicine, oldPackagingForm,
					mcdf.cbPackagingForm.Text, float.Parse(mcdf.tbCost.Text));
				Thread.Sleep(_viewModel.General.MillisecondsWait);
				ShowCost(row);
			}
		}

		private void AddDataCost()
		{
			MedicineCostDataForm mcdf = new();

			List<string> havingPackagingForm = ((SortableBindingList<MedicineCost>)dgvMedicineProductCost.DataSource)
				.Select(mc => mc.PackagingForm).ToList();

			mcdf.cbPackagingForm.DataSource = _viewModel.General.MedicinePackagingForms
				.Select(mpf => mpf.PackagingForm)
				.Where(form => !havingPackagingForm.Contains(form))
				.ToList();

			DataGridViewRow row = dgvMedicineProductCost.SelectedRows[0];
			int idMedicine = int.Parse(row.Cells["IdMedicine"].Value.ToString() ?? "");

			if (mcdf.ShowDialog() == DialogResult.OK)
			{
				_viewModel.InsertMedicineCost(idMedicine,
					mcdf.cbPackagingForm.Text, float.Parse(mcdf.tbCost.Text));
				Thread.Sleep(1000);
				ShowCost(row);
			}
		}
		#endregion
	}
}
