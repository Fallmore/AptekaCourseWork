namespace Apteka
{
	public partial class Form1 : Form
	{
		private String[][] med = [["Нурофен 100 мг", "3", "129", "блистер", "23.03.23", "93241230322", "Арбидол"],
		["Мальтофер сироп фл 150мл", "1", "399", "флакон", "12.05.26", "32454230622", ""],
		["Мальтофер таб. жеват. 100мг №30", "3", "259", "блистер", "03.12.23", "12343230312", "Арбидол"],
		["Малютка-1 зам молоко 350/400г нов ф-ла б/в с рожд", "2", "499", "пакет", "06.01.28", "7643230421", ""]];

		private String[][] pers = [["Иванов", "Иван", "Иванович", "Астраханская обл., г. Камызяк, ул. Пушкина, д.34", "07.02.2004", "Фармацевт", "25000"],
		["Сергеев", "Сергей", "Сергеевич", "Астраханская обл., г. Астрахань, ул. Дантеса, д.43", "02.07.2004", "Управляющий", "45000"]];

		public Form1()
		{
			InitializeComponent();
			FillDgvMed();
			FillDgvPers();
		}

		private void FillDgvMed()
		{
			dataGridView1.Rows.Add(4);
			for (int i = 0; i < med.Length; i++)
			{
				for (int j = 0; j < med[i].Length; j++)
					dataGridView1.Rows[i].Cells[j].Value = med[i][j];
			}
		}

		private void FillDgvPers()
		{
			dataGridView2.Rows.Add(2);
			for (int i = 0; i < pers.Length; i++)
			{
				for (int j = 0; j < pers[i].Length; j++)
					dataGridView2.Rows[i].Cells[j].Value = pers[i][j];
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//EmployeesDataForm f = new();
			//f.Show();
		}

		private void управляющиеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Управляющие f = new();
			//f.Show();
		}

		private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
