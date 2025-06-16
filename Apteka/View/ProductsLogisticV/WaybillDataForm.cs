using Apteka.Model;
using Apteka.View.MedicineV;
using Apteka.ViewModel;
using Apteka.ViewModel.EmployeeVM;
using Apteka.ViewModel.MedicineVM;
using Apteka.ViewModel.ProductsLogisticVM;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;

namespace Apteka.View.ProductsLogisticV
{
	public partial class WaybillDataForm : Form
	{
		private WaybillDataViewModel _viewModel;
		private MedicineProductsViewModel _viewModelMP;
		private StorageMedicineProductsViewModel _viewModelSMP;
		internal BindingList<WaybillMedicineProductWrapper> WaybillMedicineProducts = [];
		internal List<MedicineProduct> MedicineProducts = [];

		private DataGridView? _selectedDgv = null;
		private Dictionary<string, float[]> _medicineProductAmountInStorage = [];
		private string _oldCellValue = "";
		private Dictionary<string, string> _storagePlace = [];

		public WaybillDataForm()
		{
			InitializeComponent();
			TopMost = true;
			_viewModel = new();
			_viewModelMP = new();
			_viewModelSMP = new();
			dtpDateWaybill.Value =
				dtpDateWaybill.MaxDate = DateTime.Now;
			SetCmsMedicineProductCostItems();
			SetDataSourceToComboBoxes();
			SetDgvMedicineProduct();
			SetDgvStorage();
		}

		private void SetCmsMedicineProductCostItems()
		{
			cmsDgv.Items.Add("Изменить данные препарата", null,
				(s, e) => ChangeMedicineProduct());

			cmsDgv.Items.Add("-");

			cmsDgv.Items.Add("Удалить", null,
				(s, e) => DeleteRow());
		}

		private void SetDataSourceToComboBoxes()
		{
			cbSupplier.DataSource = _viewModel.GetSupplier()
				.Select(d => new ComboBoxItem { Name = d.Name, Id = d.IdSupplier })
			.OrderBy(cbi => cbi.Name).ToList();

			cbSupplier.DisplayMember = "Name";
			cbSupplier.ValueMember = "Id";
		}

		private void SetDgvMedicineProduct()
		{
			_viewModel.ConfigureSettingsDGV<WaybillMedicineProductWrapper>(dgvMedicineProduct);
			dgvMedicineProduct.DataSource = WaybillMedicineProducts;

			dgvMedicineProduct.Columns["IdWaybill"].Visible =
			dgvMedicineProduct.Columns["IdMedicineProduct"].Visible = false;

			int columnIndex = dgvMedicineProduct.Columns["Measure"].Index;
			dgvMedicineProduct.Columns.RemoveAt(columnIndex);
			var cbMeasure = new DataGridViewComboBoxColumn
			{
				Name = "Measure",
				HeaderText = "Мера",
				DataPropertyName = "Measure",
				DataSource = _viewModel.General.MeasureMeasurabilities
					.Select(mm => mm.Measure)
					.ToList(),
				ValueType = typeof(string)
			};
			dgvMedicineProduct.Columns.Insert(columnIndex - 2, cbMeasure);
		}

		private void SetDgvStorage()
		{
			_viewModel.General.SetDefaultSettingsToDGV(dgvStorage);
			dgvStorage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

			DataGridViewComboBoxColumn cbStorage = dgvStorage.Columns["Storage"] as DataGridViewComboBoxColumn
				?? new DataGridViewComboBoxColumn();
			DataGridViewComboBoxColumn cbPlace = dgvStorage.Columns["Place"] as DataGridViewComboBoxColumn
				?? new DataGridViewComboBoxColumn();
			cbStorage.Width = 200; cbPlace.Width = 150;
			cbStorage.Frozen = cbPlace.Frozen = true;

			cbStorage.DataSource = _viewModel.GetStoragePharmacy()
				.Select(sp => new ComboBoxItem { Name = sp.Name, Id = sp.IdStorage }).OrderBy(cbi => cbi.Name).ToList();

			cbPlace.DataSource = _viewModel.GetStoragePlace()
				.Select(sp => new ComboBoxItem { Name = sp.Name, Id = sp.IdPlace }).OrderBy(cbi => cbi.Name).ToList();

			cbPlace.DisplayMember =
			cbStorage.DisplayMember = "Name";

			cbPlace.ValueMember =
			cbStorage.ValueMember = "Id";
		}

		private void AddColumnToDgvStorage(DataGridViewRow row)
		{
			string idMedicineProduct = row.Cells["IdMedicineProduct"].Value.ToString() ?? "";
			_medicineProductAmountInStorage.Add(idMedicineProduct, [0, 0]);

			DataGridViewTextBoxColumn column = new()
			{
				HeaderText = row.Cells["SerialNumber"].Value.ToString() + "\n" +
					"0/" + row.Cells["Amount"].Value.ToString(),
				Name = idMedicineProduct,
				ValueType = typeof(float),
				Width = 100
			};
			dgvStorage.Columns.Add(column);

			foreach (DataGridViewRow r in dgvStorage.Rows)
				r.Cells[idMedicineProduct].Value = 0;
		}

		private void dgvMedicineProduct_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			DataGridViewRow row = dgvMedicineProduct.Rows[e.RowIndex];
			AddColumnToDgvStorage(row);
		}

		private void AddRowToDgvMedicineProduct(MedicineProduct mp)
		{
			WaybillMedicineProduct wmp = new()
			{
				IdMedicineProduct = mp.IdMedicineProduct,
				Amount = 0,
				Cost = 0,
				Measure = "шт."
			};
			WaybillMedicineProducts.Add(new(wmp, mp));
		}

		private void UpdateRowInDgvMedicineProduct(MedicineProduct mp, DataGridViewRow row)
		{
			WaybillMedicineProduct wmp = new()
			{
				IdMedicineProduct = mp.IdMedicineProduct,
				Amount = float.Parse(row.Cells["Amount"].Value.ToString() ?? "0"),
				Cost = float.Parse(row.Cells["Cost"].Value.ToString() ?? "0"),
				Measure = row.Cells["Measure"].Value.ToString() ?? "шт."
			};

			Guid id = Guid.Parse(row.Cells["IdMedicineProduct"].Value.ToString() ?? "");
			WaybillMedicineProductWrapper? oldWmp = WaybillMedicineProducts
				.Where(wmp => wmp.IdMedicineProduct == id)
				.First();
			if (oldWmp != null)
				oldWmp = new(wmp, mp);

			dgvMedicineProduct.Refresh();
		}

		private void DeleteRow()
		{
			if (_selectedDgv != null)
			{
				DataGridViewRow row = _selectedDgv.SelectedRows[0];
				if (MessageBox.Show("Удалить выбранный препарат?", "Подтверждение",
					MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (_selectedDgv.Name == "dgvMedicineProduct")
					{
						Guid idMedicineProduct = Guid.Parse(
							row.Cells["IdMedicineProduct"].Value.ToString() ?? "");

						_viewModelMP.DeleteMedicineProduct(idMedicineProduct);
						dgvStorage.Columns.Remove(idMedicineProduct.ToString());

						WaybillMedicineProductWrapper wmp = WaybillMedicineProducts
													.Where(
							wmp => wmp.IdMedicineProduct == idMedicineProduct)
													.First();
						WaybillMedicineProducts.Remove(wmp);
					}
					_selectedDgv.Rows.Remove(row);
				}
			}
		}

		private void ChangeMedicineProduct()
		{
			DataGridViewRow row = dgvMedicineProduct.SelectedRows[0];
			Guid id = Guid.Parse(row.Cells["IdMedicineProduct"].Value.ToString() ?? "");
			MedicineProduct? mp = MedicineProducts.Find(mp => mp.IdMedicineProduct == id);
			MedicineProductDataForm mpdf = new(mp);

			if (mpdf.ShowDialog() == DialogResult.OK)
			{
				UpdateRowInDgvMedicineProduct(mpdf.NewMedicineProduct, row);
			}
		}

		private void OpenAddMedicineProduct()
		{
			MedicineProductDataForm mpdf = new();

			if (mpdf.ShowDialog() == DialogResult.OK)
			{
				MedicineProducts.Add(mpdf.NewMedicineProduct);
				AddRowToDgvMedicineProduct(mpdf.NewMedicineProduct);
			}
		}

		private void ValidateAmountInDgvStorage(DataGridView dgv, DataGridViewCellEventArgs e)
		{
			DataGridViewColumn storageColumn = dgv.Columns[e.ColumnIndex];
			string columnName = storageColumn.Name;
			string name = storageColumn.HeaderText;
			float oldInsertedAmount = _medicineProductAmountInStorage[columnName][0];
			float maxAmount = _medicineProductAmountInStorage[columnName][1];

			if (maxAmount == 0)
			{
				dgv.CurrentCell.Value = _oldCellValue;
				return;
			}

			float newInsertedAmount = oldInsertedAmount;
			if (_oldCellValue != "0")
				newInsertedAmount -= float.Parse(_oldCellValue);

			float leftAmount = maxAmount - newInsertedAmount;
			float cellAmount = float.Parse(dgv.CurrentCell.Value?.ToString() ?? "-1");

			if (cellAmount == -1) return;

			if (cellAmount > leftAmount)
			{
				if (leftAmount == 0) cellAmount = float.Parse(_oldCellValue);
				else cellAmount -= cellAmount - leftAmount;
			}

			dgv.CurrentCell.Value = cellAmount;

			if (leftAmount != 0)
			{
				dgv.Columns[e.ColumnIndex].HeaderText =
					name.Replace(string.Concat("\n", oldInsertedAmount, "/"),
					string.Concat("\n", newInsertedAmount + cellAmount, "/"));
				_medicineProductAmountInStorage[columnName][0] = newInsertedAmount + cellAmount;
			}
		}

		private void ValidateAmountInDgvMedicineProduct(DataGridView dgv, DataGridViewCellEventArgs e)
		{
			string columnName = dgv.Rows[e.RowIndex].Cells["IdMedicineProduct"].Value.ToString() ?? "";
			DataGridViewColumn storageColumn = dgvStorage.Columns[columnName];
			string name = storageColumn.HeaderText;

			float insertedAmount = _medicineProductAmountInStorage[columnName][0];
			float oldMaxAmount = _medicineProductAmountInStorage[columnName][1];
			float leftAmount = oldMaxAmount - insertedAmount;

			float newMaxAmount = float.Parse(dgv.CurrentCell.Value.ToString() ?? "");

			dgvStorage.Columns[columnName].HeaderText =
				name.Replace(string.Concat("/", oldMaxAmount),
				string.Concat("/", newMaxAmount));
			_medicineProductAmountInStorage[columnName][1] = newMaxAmount;

			if (oldMaxAmount > newMaxAmount && leftAmount == 0)
			{
				float oldCellAmount = float.Parse(dgvStorage.Rows[0].Cells[columnName].Value.ToString() ?? "");
				float newCellAmount = oldCellAmount - (oldMaxAmount - newMaxAmount);
				dgvStorage.Rows[0].Cells[columnName].Value = newCellAmount;

				dgvStorage.Columns[columnName].HeaderText =
					dgvStorage.Columns[columnName].HeaderText.Replace(string.Concat("\n", oldMaxAmount, "/"),
					string.Concat("\n", newMaxAmount, "/"));
				_medicineProductAmountInStorage[columnName][0] = newMaxAmount;
			}

		}

		private void btnAddMedicineProduct_Click(object sender, EventArgs e)
		{
			OpenAddMedicineProduct();
		}

		private bool IsWaybillMedicineProductOK()
		{
			foreach (WaybillMedicineProductWrapper wmpw in WaybillMedicineProducts)
				if (wmpw.Cost == 0 || wmpw.Amount == 0)
					return false;
			return true;
		}

		private int CheckStorageMedicineProduct()
		{
			foreach (var item in _medicineProductAmountInStorage)
				if (item.Value[0] != item.Value[1])
					return -1;

			_storagePlace = [];
			foreach (DataGridViewRow row in dgvStorage.Rows)
			{
				if (row.IsNewRow) continue;

				string storage = row.Cells["Storage"].Value?.ToString() ?? "";
				string place = row.Cells["Place"].Value?.ToString() ?? "";

				if (storage == "") return -2;
				if (place == "") return -3;

				if (_storagePlace.TryGetValue(storage, out string? temp))
				{
					_storagePlace.Clear();
					_storagePlace.Add(storage, place);
					return -4;
				}

				_storagePlace.Add(storage, place);
			}

			return 0;
		}

		private bool CheckAllData()
		{
			string message = "";
			if (!IsWaybillMedicineProductOK())
				message = "Ошибка! Цена или количество препарата не может быть 0!";

			switch (CheckStorageMedicineProduct())
			{
				case -1:
					message = "Ошибка! Не все запасы препаратов разложены!";
					break;
				case -2:
					message = "Ошибка! Не выбран склад в распределении партий препаратов!";
					break;
				case -3:
					message = "Ошибка! Не выбрано место на складе в распределении партий препаратов!";
					break;
				case -4:
					message = "Ошибка! Не может быть несколько одинаковых места на складе, оставьте только одно: " +
						_storagePlace.Select(x => $"{x.Key} {x.Value}").First();
					break;
				default:
					break;
			}

			if (tbNumberWaybill.Text.Trim() == "")
				message = "Ошибка! Вы не ввели номер накладной!";

			if (message != "")
			{
				MessageBox.Show(message, "Заполнение накладной",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		private void btnDone_Click(object sender, EventArgs e)
		{
			try
			{
				if (!CheckAllData())
				{
					DialogResult = DialogResult.None;
					return;
				}

				Waybill w = new()
				{
					IdWaybill = int.Parse(tbNumberWaybill.Text),
					IdSupplier = int.Parse(cbSupplier.SelectedValue?.ToString() ?? ""),
					DateWaybill = DateOnly.FromDateTime(dtpDateWaybill.Value),
					IdDepartment = EmployeeAccountViewModel.GetCurrentDepartment()
				};

				_viewModel.InsertWaybill(w);
				_viewModel.General.AptekaContext.SaveChanges();

				List<WaybillMedicineProduct> lwmp = [];
				foreach (WaybillMedicineProductWrapper item in WaybillMedicineProducts)
				{
					WaybillMedicineProduct wmp = new()
					{
						IdWaybill = w.IdWaybill,
						IdMedicineProduct = item.IdMedicineProduct,
						Amount = item.Amount,
						Cost = item.Cost,
						Measure = item.Measure
					};
					lwmp.Add(wmp);
				}

				_viewModel.InsertWaybillMedicineProduct(lwmp);
				_viewModel.General.AptekaContext.SaveChanges();

				List<StorageMedicineProduct> lsmp = [];
				for (int i = 2; i < dgvStorage.Columns.Count; i++)
				{
					for (int j = 0; j < dgvStorage.Rows.Count; j++)
					{
						DataGridViewRow row = dgvStorage.Rows[j];
						if (row.IsNewRow) continue;

						DataGridViewComboBoxCell cbStorage = row.Cells[0] as DataGridViewComboBoxCell ?? new();
						DataGridViewComboBoxCell cbPlace = row.Cells[1] as DataGridViewComboBoxCell ?? new();

						Guid id = Guid.Parse(dgvStorage.Columns[i].Name);
						float amount = float.Parse(dgvStorage.Rows[j].Cells[i].Value?.ToString() ?? "");
						if (amount == 0) continue;

						StorageMedicineProduct smp = new()
						{
							IdMedicineProduct = id,
							IdStorage = int.Parse(cbStorage.Value?.ToString() ?? ""),
							IdPlace = int.Parse(cbPlace.Value?.ToString() ?? ""),
							Amount = amount,
							Measure = _viewModel.GetMeasure(id)
								.Select(wmp => wmp.Measure).First(),
							IdDepartment = EmployeeAccountViewModel.GetCurrentDepartment()
						};
						lsmp.Add(smp);
					}
				}

				_viewModelSMP.InsertStorageMedicineProduct(lsmp);
				_viewModel.General.AptekaContext.SaveChanges();
				MessageBox.Show("Накладная успешно добавлена", "Добавление накладной",
										MessageBoxButtons.OK, MessageBoxIcon.Information);
				Close();
			}
			catch (DbUpdateException ex)
			{
				string message = ex.InnerException?.Message ?? "";

				if (message.Contains("wrong_date_waybill"))
					message = "Ошибка! Дата накладной не должна быть позже сегодняшней даты!";

				MessageBox.Show(message, "Ошибка данных",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				DialogResult = DialogResult.None;
				return;
			}
		}

		private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (sender is DataGridView dgv && e.RowIndex != -1)
			{
				DataGridViewRow row = dgv.Rows[e.RowIndex];
				if (!row.IsNewRow)
				{
					row.Selected = true;
					_selectedDgv = dgv;
					cmsDgv.Items[0].Visible = dgv.Name == "dgvMedicineProduct";
					if (MouseButtons.Right == e.Button)
						cmsDgv.Show(Cursor.Position);
				}
			}
		}

		private void tbInt_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Разрешаем:
			// - цифры (0-9)
			// - Backspace (удаление)
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true; // Блокируем ввод
			}
		}

		private void tbFloat_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Разрешаем:
			// - цифры (0-9)
			// - Backspace (удаление)
			// - точку и запятую
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
				e.KeyChar != '.' && e.KeyChar != ',')
			{
				e.Handled = true; // Блокируем ввод
			}

			// Проверяем, чтобы точка/запятая была только одна
			if ((e.KeyChar == '.' || e.KeyChar == ',') &&
				((TextBox)sender).Text.IndexOfAny(['.', ',']) > -1)
			{
				e.Handled = true;
			}
		}

		private void WaybillDataForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (WaybillMedicineProducts.Count != 0 && DialogResult != DialogResult.OK)
			{
				foreach (WaybillMedicineProductWrapper wmpw in WaybillMedicineProducts)
					_viewModelMP.DeleteMedicineProduct(wmpw.IdMedicineProduct);
			}
		}

		private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (sender is DataGridView dgv)
			{
				int cIndex = dgv.CurrentCell.ColumnIndex;
				bool isTargetCell = false;
				if (dgv.Name == "dgvMedicineProduct")
				{
					if (cIndex == dgv.Columns["Amount"].Index
						|| cIndex == dgv.Columns["Cost"].Index)
						isTargetCell = true;
				}
				else
				{
					if (cIndex != dgv.Columns["Storage"].Index
						&& cIndex != dgv.Columns["Place"].Index)
						isTargetCell = true;
				}

				if (isTargetCell)
				{
					TextBox tb = (e.Control as TextBox) ?? new();
					if (tb != null)
					{
						tb.KeyPress += new KeyPressEventHandler(tbFloat_KeyPress);
					}
				}
			}
		}

		private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (sender is DataGridView dgv)
			{
				int cIndex = dgv.CurrentCell.ColumnIndex;
				if (dgv.Name == "dgvMedicineProduct")
				{
					if (cIndex == dgv.Columns["Amount"].Index)
					{
						ValidateAmountInDgvMedicineProduct(dgv, e);
					}
				}
				else
				{
					if (cIndex != dgv.Columns["Place"].Index
						&& cIndex != dgv.Columns["Storage"].Index)
					{
						if (dgv.CurrentCell.Value == null || dgv.CurrentCell.Value?.ToString() == "")
						{
							if (_oldCellValue != "0") dgv.CurrentCell.Value = _oldCellValue;
							else dgv.CurrentCell.Value = 0;
						}

						ValidateAmountInDgvStorage(dgv, e);
					}
				}
			}
		}

		private void dgvStorage_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			_oldCellValue = dgvStorage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";
		}

		private void dgvStorage_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			for (int i = 2; i < e.Row.Cells.Count; i++)
			{
				e.Row.Cells[i].Value = 0;
			}

		}
	}
}
