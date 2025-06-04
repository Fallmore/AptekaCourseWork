using Apteka.BaseClasses;
using Apteka.Model;
using Apteka.View.Medicine;
using Apteka.ViewModel;
using Apteka.ViewModel.MedicineVM;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace Apteka.View.ProductsLogisticV
{
	public partial class MedicineProductDataForm : FormWithNotification
	{
		MedicineProductsViewModel _viewModel;
		internal MedicineProduct NewMedicineProduct = new();

		public MedicineProductDataForm(MedicineProduct? mp = null)
		{
			InitializeComponent();
			_viewModel = new();
			_viewModel.General.SetDefaultSettingsToDGV(dgvComponents);
			SetDataSourceToComboBoxes();
			SubscribeTable();
			SetMedicineProductData(mp);
			dgvComponents.Rows[0].Cells[0].Value = "Амоксициллин";
			dgvComponents.Rows[0].Cells[1].Value = "200";
			dgvComponents.Rows[0].Cells[2].Value = "мг.";
		}

		private void SetDataSourceToComboBoxes()
		{
			cbMedicine.DataSource = _viewModel.General.Medicines
				.Select(m => new ComboBoxItem { Name = m.Name, Id = m.IdMedicine })
				.OrderBy(cbi => cbi.Name).ToList();
			cbMedicine.DisplayMember = "Name";
			cbMedicine.ValueMember = "Id";

			cbMedicineForm.DataSource = _viewModel.General.MedicineForms
				.Select(mf => mf.Form)
				.OrderBy(name => name).ToList();

			cbPackagingForm.DataSource = _viewModel.General.MedicinePackagingForms
				.Select(mpf => mpf.PackagingForm)
				.OrderBy(name => name).ToList();

			cbProducer.DataSource = _viewModel.General.MedicineProducers
				.Select(mp => mp.Producer)
				.OrderBy(name => name).ToList();

			cbWayEnter.DataSource = _viewModel.General.MedicineWayEnters
				.Select(mp => mp.WayEnter)
				.OrderBy(name => name).ToList();

			DataGridViewComboBoxColumn cbMeasure = dgvComponents.Columns[2] as DataGridViewComboBoxColumn
				?? new();
			cbMeasure.DataSource = _viewModel.General.MeasureMeasurabilities
							.Select(mm => mm.Measure).ToList();
		}

		private void SubscribeTable()
		{
			_viewModel.General.DatabaseNotificationService.Subscribe<MedicineProductDataForm>("medicine_product",
				data =>
				{
					RefreshData<MedicineProduct>(_viewModel.General.MedicineProducts,
					value => _viewModel.General.MedicineProducts = value, data);

				});

			_viewModel.General.DatabaseNotificationService.Subscribe<MedicineProductDataForm>("medicine_cost",
				data =>
				{
					RefreshData<MedicineCost>(_viewModel.General.MedicineCosts,
					value => _viewModel.General.MedicineCosts = value, data);

				});
		}

		private void SetMedicineProductData(MedicineProduct? mp)
		{
			if (mp == null) return;
			NewMedicineProduct = mp;

			cbMedicine.SelectedValue = mp.IdMedicine;
			tbSerialNumber.Text = mp.SerialNumber;
			cbMedicineForm.SelectedText = mp.Form;
			cbWayEnter.SelectedText = mp.WayEnter;
			cbPackagingForm.SelectedText = mp.PackagingForm;
			cbProducer.SelectedText = mp.Producer;
			rtbConditionStorage.Text = mp.StorageCondition;
			rtbDosageMode.Text = mp.DosageMode;
			dtpDateRelease.Value = new(mp.DateRelease, new());
			dtpDateExpiration.Value = new(mp.DateExpiration, new());
			tbAmount.Text = mp.Amount.ToString();

			JArray components = JToken.Parse(mp.Components) as JArray ?? [];

			foreach (JObject item in components)
			{
				string measure = item.Value<string>("Мера") ?? "";
				float amount = float.Parse(measure[..measure.IndexOf(' ')]);
				string msr = measure[measure.IndexOf(' ')..];
				dgvComponents.Rows.Add(item.Value<string>("Вещество"), amount, msr);
			}
		}

		private void dgv_KeyDown(object sender, KeyEventArgs e)
		{
			DataGridViewSelectedRowCollection row = dgvComponents.SelectedRows;
			if (e.KeyCode == Keys.Delete && row.Count != 0 && !row[0].IsNewRow)
			{
				// Подтверждение удаления (опционально)
				if (MessageBox.Show("Удалить выбранную строку?", "Подтверждение",
					MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					dgvComponents.Rows.Remove(row[0]);
				}
				e.Handled = true;
			}
		}

		private void tbNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Разрешаем:
			// - цифры (0-9)
			// - Backspace (удаление)
			// - точку и запятую (но только одну)
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

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (tbAmount.Text.Trim() == "")
			{
				MessageBox.Show("Ошибка! Отсутствует количество содержимого препарата!", "Данные ЛП",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				DialogResult = DialogResult.None;
				return;
			}

			MedicineProduct medicineProduct = new()
			{
				IdMedicineProduct = NewMedicineProduct.IdMedicineProduct,
				IdMedicine = int.Parse(cbMedicine.SelectedValue.ToString() ?? "-1"),
				SerialNumber = tbSerialNumber.Text,
				Form = cbMedicineForm.Text,
				Amount = int.Parse(tbAmount.Text),
				WayEnter = cbWayEnter.Text,
				DosageMode = rtbDosageMode.Text,
				PackagingForm = cbPackagingForm.Text,
				Producer = cbProducer.Text,
				DateRelease = DateOnly.FromDateTime(dtpDateRelease.Value),
				StorageCondition = rtbConditionStorage.Text,
				DateExpiration = DateOnly.FromDateTime(dtpDateExpiration.Value),
				Name = ""
			};

			string json = DgvComponentsToJsonString();
			if (json == "[]")
			{
				MessageBox.Show("Ошибка! Пустые поля в составе!", "Данные состава",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				DialogResult = DialogResult.None;
				return;
			}

			medicineProduct.Components = json;

			if (!_viewModel.UpsertMedicineProduct(medicineProduct))
			{
				DialogResult = DialogResult.None;
				return;
			}

			NewMedicineProduct = medicineProduct;
			if (!IsMedicineCostExist(medicineProduct.IdMedicine, medicineProduct.PackagingForm))
				AddDataCost(medicineProduct.IdMedicine);
		}

		private bool IsMedicineCostExist(int idMedicine, string packagingForm)
		{
			List<MedicineCost> costs = _viewModel.General.MedicineCosts
				.Where(mc => mc.IdMedicine == idMedicine && mc.PackagingForm == packagingForm)
				.ToList();

			if (costs.Count == 0) return false;

			return true;
		}

		private void AddDataCost(int idMedicine)
		{
			MedicineCostDataForm mcdf = new();

			mcdf.cbPackagingForm.DataSource = _viewModel.General.MedicinePackagingForms
				.Select(mpf => mpf.PackagingForm)
				.ToList();

			if (mcdf.ShowDialog() == DialogResult.OK)
			{
				_viewModel.InsertMedicineCost(idMedicine,
					mcdf.cbPackagingForm.Text, float.Parse(mcdf.tbCost.Text));
			}
		}

		private string DgvComponentsToJsonString()
		{
			DataGridViewRowCollection rows = dgvComponents.Rows;
			List<Dictionary<string, object>> data = [];

			foreach (DataGridViewRow row in rows)
			{
				if (row.IsNewRow) continue;

				Dictionary<string, object> rowData = [];
				for (int i = 0; i < row.Cells.Count; i++)
				{
					DataGridViewCell cell = row.Cells[i];
					if (i == 0)
					{
						if (cell.Value.ToString().Trim() == "") return "[]";
						rowData["Вещество"] = cell.Value;
					}
					else
					{
						string measure = row.Cells[++i].Value.ToString() ?? "";
						if (cell.Value.ToString().Trim() == "" || measure.Trim() == "")
							return "[]";

						rowData["Мера"]
							= string.Concat(cell.Value, " ", measure);

					}
				}
				data.Add(rowData);
			}

			return JsonConvert.SerializeObject(data);
		}

		private void dgvComponents_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (dgvComponents.CurrentCell.ColumnIndex == 0)
			{
				TextBox textBox = e.Control as TextBox;
				if (textBox != null)
				{
					textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
					textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

					textBox.AutoCompleteCustomSource.AddRange(_viewModel.General.MedicineProducts
						.Select(mp => JArray.Parse(mp.Components))
						.SelectMany(ja => ja)
						.Where(item => item["Вещество"] != null)
						.Select(item => item["Вещество"].ToString())
						.OrderBy(name => name)
						.Distinct().ToArray());
				}
			}
			else if (dgvComponents.CurrentCell.ColumnIndex == 1)
			{
				TextBox textBox = e.Control as TextBox;
				textBox.KeyPress += tbNumber_KeyPress;
			}
		}
	}
}
