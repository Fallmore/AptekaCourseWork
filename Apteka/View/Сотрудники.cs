namespace Apteka
{
	public partial class Сотрудники : Form
	{
		private String[][] pers = [["Иванов", "Иван", "Иванович", "Астраханская обл., г. Камызяк, ул. Пушкина, д.34", "07.02.2004", "Фармацевт", "25000"]];

		public Сотрудники()
		{
			InitializeComponent();
			textBox1.Text = "Иванов";
			textBox2.Text = "Иван";
			textBox3.Text = "Иванович";
			textBox4.Text = "Астраханская обл., г. Камызяк, ул. Пушкина, д.34";
			textBox5.Text = "07.02.2004";
			textBox6.Text = "Фармацевт";
			textBox7.Text = "25000";
		}
	}
}
