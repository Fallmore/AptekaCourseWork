using Apteka.BaseClasses;
using Apteka.Model;
using Apteka.View;
using Apteka.View.SimpleV;
using Apteka.ViewModel.MenuVM;
using Apteka.ViewModel.ProductsLogisticVM;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.ComponentModel;
using System.Diagnostics;

namespace Apteka
{
	public partial class Касса : FormWithNotification
	{
		private КассаViewModel _viewModel;
		private HistorySalesViewModel _viewModelHS;
		private StorageMedicineProductsViewModel _viewModelSMP;

		private HistorySale _sale;
		private BindingList<HistorySaleMedicineProductWrapper> _listHSMPW;

		private int _indexRow = -1,
			_indexCell = -1;
		private bool _isColumnsPickedMPHide = false;
		private bool _isColumnsAnaloguesMPHide = false;
		private bool _isColumnsStorageMPHide = false;
		private DataGridView _selectedDgv;

		public Касса()
		{
			InitializeComponent();
			Init();
			ConfigureDGV();
			SubscribeTable();
			HideTechnicalColumns();
			SetCmsMedicineProductItems();
		}

		private void Init()
		{
			_viewModel = new();
			_viewModelHS = new();
			_viewModelSMP = new();
			_listHSMPW = [];
			_sale = new HistorySale()
			{
				IdSale = Guid.NewGuid()
			};
		}

		private void ConfigureDGV()
		{
			_viewModel.ConfigureSettingsDGV<StorageMedicineProductWrapper>(dgvStorageMedicineProduct);
			dgvStorageMedicineProduct.DataSource = new SortableBindingList<StorageMedicineProductWrapper>(
				StorageMedicineProductWrapper.ToList(_viewModel.GetStorageMedicineProductsForSale(), _viewModelSMP));

			_viewModel.ConfigureSettingsDGV<StorageMedicineProductWrapper>(dgvAnaloguesStorageMedicineProduct);
			_viewModel.ConfigureSettingsDGV<HistorySaleMedicineProductWrapper>(dgvPickedMedicineProduct);
		}

		private void SubscribeTable()
		{
			_viewModel.General.DatabaseNotificationService.Subscribe<Касса>("storage_medicine_product",
				data =>
				{
					RefreshData<StorageMedicineProduct>(_viewModel.General.StorageMedicineProducts,
					value => _viewModel.General.StorageMedicineProducts = value, data,
					() =>
					{
						dgvStorageMedicineProduct.DataSource = new SortableBindingList<StorageMedicineProductWrapper>(
				StorageMedicineProductWrapper.ToList(_viewModel.GetStorageMedicineProductsForSale(), _viewModelSMP));
						ShowAnalogues(dgvStorageMedicineProduct.SelectedRows[0]);
					});

				});

			_viewModel.General.DatabaseNotificationService.Subscribe<Касса>("medicine_product",
				data =>
				{
					RefreshData<MedicineProduct>(_viewModel.General.MedicineProducts,
					value => _viewModel.General.MedicineProducts = value, data);

				});
		}

		private void HideTechnicalColumns()
		{
			if (dgvStorageMedicineProduct.Columns.Contains("IdMedicineProduct"))
			{
				dgvStorageMedicineProduct.Columns["IdMedicineProduct"].Visible =
				dgvStorageMedicineProduct.Columns["IsCriticalAmount"].Visible =
				dgvStorageMedicineProduct.Columns["IdDepartment"].Visible =
				dgvStorageMedicineProduct.Columns["IdStorage"].Visible =
				dgvStorageMedicineProduct.Columns["IdPlace"].Visible = false;
				_isColumnsStorageMPHide = true;
			}

			if (dgvAnaloguesStorageMedicineProduct.Columns.Contains("IdMedicineProduct"))
			{
				dgvAnaloguesStorageMedicineProduct.Columns["IdMedicineProduct"].Visible =
				dgvAnaloguesStorageMedicineProduct.Columns["IsCriticalAmount"].Visible =
				dgvAnaloguesStorageMedicineProduct.Columns["IdDepartment"].Visible =
				dgvAnaloguesStorageMedicineProduct.Columns["IdStorage"].Visible =
				dgvAnaloguesStorageMedicineProduct.Columns["IdPlace"].Visible = false;
				_isColumnsAnaloguesMPHide = true;
			}

			if (dgvPickedMedicineProduct.Columns.Contains("IdMedicineProduct"))
			{
				dgvPickedMedicineProduct.Columns["IdMedicineProduct"].Visible =
				dgvPickedMedicineProduct.Columns["IdStorage"].Visible =
				dgvPickedMedicineProduct.Columns["IdPlace"].Visible =
				dgvPickedMedicineProduct.Columns["IdSale"].Visible = false;
				_isColumnsPickedMPHide = true;
			}
		}

		private void SetCmsMedicineProductItems()
		{
			cmsMedicineProduct.Items.Add("Показать подробности", null,
				(s, e) => ShowMedicineProduct());

			cmsMedicineProduct.Items.Add("Выбрать на продажу", null,
				(s, e) => PickMedicineProduct());

			cmsMedicineProduct.Items.Add("-");

			cmsMedicineProduct.Items.Add("Убрать из списка", null,
				(s, e) => RemovePickedMedicineProduct());

			cmsMedicineProduct.Items.Add("-");

			cmsMedicineProduct.Items.Add("Копировать содержимое ячейки", null,
				(s, e) =>
					Clipboard.SetText(dgvStorageMedicineProduct.Rows[_indexRow].Cells[_indexCell].Value.ToString() ?? ""));
		}

		private void ShowMedicineProduct()
		{
			MedicineProductsForm? mpf = _viewModel.General.GetActivatedForm<MedicineProductsForm>();

			if (mpf == null)
			{
				mpf = new();
				mpf.Show();
			}

			string serialNumber = _selectedDgv.SelectedRows[0].Cells["SerialNumber"].Value.ToString() ?? "";

			mpf.SearchMedicineProductFromOtherForm(serialNumber);
		}

		private StorageMedicineProduct? Find(StorageMedicineProduct smp)
		{
			try
			{
				return _viewModel.General.AptekaContext.StorageMedicineProducts
					.Find(smp.IdDepartment, smp.IdStorage, smp.IdPlace, smp.IdMedicineProduct);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return null;
			}
		}

		private void FindAndUpdate(StorageMedicineProduct smp)
		{
			try
			{
				var dbItem = _viewModel.General.AptekaContext.StorageMedicineProducts
					.Find(smp.IdDepartment, smp.IdStorage, smp.IdPlace, smp.IdMedicineProduct);

				if (dbItem != null)
				{
					// Копируем изменения из selectedItem в dbItem
					_viewModel.General.AptekaContext.Entry(dbItem).CurrentValues.SetValues(smp);

					// Сохраняем
					_viewModel.General.AptekaContext.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		private void PickMedicineProduct()
		{
			StorageMedicineProductWrapper selectedWrapperInStorage = _selectedDgv.SelectedRows[0]
				.DataBoundItem as StorageMedicineProductWrapper ?? new();
			StorageMedicineProduct? selectedMedicineProduct = new(selectedWrapperInStorage);

			float amount;
			{
				AmountForm af = new()
				{
					StartPosition = FormStartPosition.Manual,
				};
				af.Location = new Point(Cursor.Position.X - af.Width / 2, Cursor.Position.Y - af.Height / 2);
				if (af.ShowDialog() == DialogResult.OK)
				{
					if (af.tbAmount.Text.Trim() == "")
					{
						MessageBox.Show("Ошибка! Введите количество!",
					"Выбор препарата", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					amount = float.Parse(af.tbAmount.Text);

				}
				else return;
			}

			if ((selectedMedicineProduct = Find(selectedMedicineProduct)) == null)
			{
				MessageBox.Show("Ошибка! Данное лекарство только что изъяли из продажи!",
						"Выбор препарата", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (amount > selectedMedicineProduct.Amount)
			{
				MessageBox.Show("Ошибка! Введенное количество превышает фактическое количество на складе!",
					"Выбор препарата", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			selectedMedicineProduct.Amount -= amount;
			FindAndUpdate(selectedMedicineProduct);

			{
				HistorySaleMedicineProduct pickedMedicineProduct = new()
				{
					IdSale = _sale.IdSale,
					Amount = amount,
					Cost = _viewModel.CountCost(selectedMedicineProduct.IdMedicineProduct, amount)
				};
				pickedMedicineProduct.Parse(selectedMedicineProduct);

				HistorySaleMedicineProductWrapper? samePickedMedicineProduct = _listHSMPW.ToList().Find(mp => mp.IdMedicineProduct == pickedMedicineProduct.IdMedicineProduct &&
						mp.IdStorage == pickedMedicineProduct.IdStorage && mp.IdPlace == pickedMedicineProduct.IdPlace);

				if (samePickedMedicineProduct == null)
					_listHSMPW.Add(new(pickedMedicineProduct, _viewModelHS));
				else
				{
					samePickedMedicineProduct.Amount += pickedMedicineProduct.Amount;
					samePickedMedicineProduct.Cost += pickedMedicineProduct.Cost;
				}

				dgvPickedMedicineProduct.DataSource = _listHSMPW;
				ShowCost(pickedMedicineProduct.Cost);
				if (!_isColumnsPickedMPHide) HideTechnicalColumns();
				dgvPickedMedicineProduct.Refresh();
			}
		}

		private void RemovePickedMedicineProduct()
		{
			HistorySaleMedicineProductWrapper pickedMedicineProduct = dgvPickedMedicineProduct.SelectedRows[0]
				.DataBoundItem as HistorySaleMedicineProductWrapper ?? new();

			if (dgvStorageMedicineProduct
				.DataSource is not SortableBindingList<StorageMedicineProductWrapper> allMedicineProductsInStorage) return;

			StorageMedicineProductWrapper? medicineProductWrapperInStorage = allMedicineProductsInStorage
				.FirstOrDefault(mp => mp.IdMedicineProduct == pickedMedicineProduct.IdMedicineProduct &&
					mp.IdStorage == pickedMedicineProduct.IdStorage && mp.IdPlace == pickedMedicineProduct.IdPlace);

			if (medicineProductWrapperInStorage == null)
			{
				dgvPickedMedicineProduct.Rows.Remove(dgvPickedMedicineProduct.SelectedRows[0]);
				return;
			}

			medicineProductWrapperInStorage.Amount += pickedMedicineProduct.Amount;
			dgvStorageMedicineProduct.Refresh();

			StorageMedicineProduct? medicineProductInStorage = new(medicineProductWrapperInStorage);
			FindAndUpdate(medicineProductInStorage);
			ShowCost(-pickedMedicineProduct.Cost);
			_listHSMPW.Remove(pickedMedicineProduct);
		}

		private void ShowAnalogues(DataGridViewRow row)
		{
			Guid id = Guid.Parse(row.Cells["IdMedicineProduct"].Value?.ToString() ?? "");
			List<StorageMedicineProductWrapper> lsmpw = StorageMedicineProductWrapper
				.ToList(_viewModel.GetStorageMedicineProductsAnaloguesForSale(id), _viewModelSMP);

			dgvAnaloguesStorageMedicineProduct.DataSource =
				new SortableBindingList<StorageMedicineProductWrapper>(lsmpw);
			if (!_isColumnsAnaloguesMPHide) HideTechnicalColumns();
		}

		private void ShowCost(float cost)
		{
			tstbCost.Text = float.Round(float.Parse(tstbCost.Text) + cost, 2).ToString();
		}

		private void RemoveAllPickedMedicineProduct()
		{
			for (int i = dgvPickedMedicineProduct.Rows.Count - 1; i >= 0; i--)
			{
				dgvPickedMedicineProduct.Rows[i].Selected = true;
				RemovePickedMedicineProduct();
			}
		}

		private async void SearchStorageMedicineProduct()
		{
			List<StorageMedicineProduct>? results = await _viewModel
				.SearchStorageMedicineProductsForSale(tstbTexSearchtMP.Text);

			if (results == null) return;

			if (results.Count == 0)
			{
				MessageBox.Show("ЛП не найдено", "Поиск ЛП",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			dgvStorageMedicineProduct.DataSource = new SortableBindingList<StorageMedicineProductWrapper>(
				StorageMedicineProductWrapper.ToList(results, _viewModelSMP));
			tsbResetSearchMP.Enabled = true;
		}

		private async void SearchAnaloguesMedicineProduct()
		{
			Guid id = Guid.Parse(dgvStorageMedicineProduct.SelectedRows[0]
				.Cells["IdMedicineProduct"].Value?.ToString() ?? "");

			List<StorageMedicineProduct>? results = await _viewModel
				.SearchAnaloguesMedicineProductsForSale(id, tstbTextSearchAnaloguesMP.Text);

			if (results == null) return;

			if (results.Count == 0)
			{
				MessageBox.Show("ЛП не найдено", "Поиск ЛП",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			dgvAnaloguesStorageMedicineProduct.DataSource = new SortableBindingList<StorageMedicineProductWrapper>(
				StorageMedicineProductWrapper.ToList(results, _viewModelSMP));
			tsbResetSearchAnaloguesMP.Enabled = true;
		}

		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (sender is DataGridView dgv && e.RowIndex != -1)
			{
				_indexRow = e.RowIndex;
				_indexCell = e.ColumnIndex;
				DataGridViewRow row = dgv.Rows[e.RowIndex];
				row.Selected = true;
				_selectedDgv = dgv;

				if (dgv.Name == "dgvStorageMedicineProduct")
					ShowAnalogues(row);

				if (dgv.Name == "dgvPickedMedicineProduct")
				{
					cmsMedicineProduct.Items[1].Visible = false;
					cmsMedicineProduct.Items[2].Visible =
					cmsMedicineProduct.Items[3].Visible = true;
					if (MouseButtons.Right == e.Button)
						cmsMedicineProduct.Show(Cursor.Position);
				}
				else
				{
					cmsMedicineProduct.Items[1].Visible = true;
					cmsMedicineProduct.Items[2].Visible =
					cmsMedicineProduct.Items[3].Visible = false;
					if (MouseButtons.Right == e.Button)
						cmsMedicineProduct.Show(Cursor.Position);
				}
			}
		}

		private void dgvStorageMedicineProduct_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			if (!_isColumnsStorageMPHide) HideTechnicalColumns();
		}

		private void tsbSearchMP_Click(object sender, EventArgs e)
		{
			SearchStorageMedicineProduct();
		}

		private void tsbSearchAnaloguesMP_Click(object sender, EventArgs e)
		{
			SearchAnaloguesMedicineProduct();
		}

		private void tsbResetSearch_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripButton btn)
			{
				btn.Enabled = false;
				switch (btn.Name)
				{
					case "tsbResetSearchMP":
						dgvStorageMedicineProduct.DataSource = new SortableBindingList<StorageMedicineProductWrapper>(
				StorageMedicineProductWrapper.ToList(_viewModel.GetStorageMedicineProductsForSale(), _viewModelSMP));
						break;
					case "tsbResetSearchAnaloguesMP":
						ShowAnalogues(dgvStorageMedicineProduct.SelectedRows[0]);
						break;
					default:
						break;
				}
			}
		}

		private void tsbResetPickedMedicineProduct_Click(object sender, EventArgs e)
		{
			RemoveAllPickedMedicineProduct();
		}

		private void Касса_FormClosing(object sender, FormClosingEventArgs e)
		{
			RemoveAllPickedMedicineProduct();
		}

		private void лекарстваToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MedicinesForm? mf = _viewModel.General.GetActivatedForm<MedicinesForm>();

			mf ??= new();

			mf.Show();
		}

		private void препаратыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MedicineProductsForm? mpf = _viewModel.General.GetActivatedForm<MedicineProductsForm>();

			mpf ??= new();

			mpf.Show();
		}

		private void списанныеПрепаратыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MedicineProductDecommissionedForm? mpdf = _viewModel.General.GetActivatedForm<MedicineProductDecommissionedForm>();

			mpdf ??= new();

			mpdf.Show();
		}

		private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm? af = _viewModel.General.GetActivatedForm<AboutForm>();

			af ??= new();

			af.Show();
		}

		private void tsbSale_Click(object sender, EventArgs e)
		{
			if (!_viewModel.InsertSale(_sale))
				return;

			if (!_viewModel.InsertSaleMedicineProduct(HistorySaleMedicineProduct.ToList(_listHSMPW.ToList())))
				return;
		}
	}
}
