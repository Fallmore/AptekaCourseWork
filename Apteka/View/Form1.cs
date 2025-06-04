namespace Apteka
{
	public partial class Form1 : Form
	{
		private String[][] med = [["������� 100 ��", "3", "129", "�������", "23.03.23", "93241230322", "�������"],
		["��������� ����� �� 150��", "1", "399", "������", "12.05.26", "32454230622", ""],
		["��������� ���. �����. 100�� �30", "3", "259", "�������", "03.12.23", "12343230312", "�������"],
		["�������-1 ��� ������ 350/400� ��� �-�� �/� � ����", "2", "499", "�����", "06.01.28", "7643230421", ""]];

		private String[][] pers = [["������", "����", "��������", "������������ ���., �. �������, ��. �������, �.34", "07.02.2004", "���������", "25000"],
		["�������", "������", "���������", "������������ ���., �. ���������, ��. �������, �.43", "02.07.2004", "�����������", "45000"]];

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

		private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//EmployeesDataForm f = new();
			//f.Show();
		}

		private void �����������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//����������� f = new();
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
