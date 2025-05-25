namespace Apteka
{
	public partial class Касса : Form
	{
		private String[][] med = [["Нурофен 100 мг", "3", "129", "блистер", "23.03.23", "93241230322", "Арбидол"],
		["Мальтофер сироп фл 150мл", "1", "399", "флакон", "12.05.26", "32454230622", ""],
		["Мальтофер таб. жеват. 100мг №30", "3", "259", "блистер", "03.12.23", "12343230312", "Арбидол"],
		["Малютка-1 зам молоко 350/400г нов ф-ла б/в с рожд", "2", "499", "пакет", "06.01.28", "7643230421", ""]];

		public Касса()
		{
			InitializeComponent();
			FillDgvMed();
		}

		private void FillDgvMed()
		{
			dataGridView3.Rows.Add(4);
			for (int i = 0; i < med.Length; i++)
			{
				for (int j = 0; j < med[i].Length; j++)
					dataGridView3.Rows[i].Cells[j].Value = med[i][j];
			}

			dataGridView4.Rows.Add(2);
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < med[i].Length; j++)
					dataGridView4.Rows[i].Cells[j].Value = med[i][j];
			}
		}
	}
}
