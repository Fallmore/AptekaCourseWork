namespace Apteka.View.EmployeeV
{
	public partial class AssignForm : Form
	{
		public AssignForm()
		{
			InitializeComponent();
		}

		private void cbNewPost_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void tbNumberOrder_KeyPress(object sender, KeyPressEventArgs e)
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
