namespace Apteka.View.MedicineV
{
	public partial class MedicineCostDataForm : Form
	{
		public MedicineCostDataForm()
		{
			InitializeComponent();
		}

		private void tbCost_KeyPress(object sender, KeyPressEventArgs e)
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
	}
}
