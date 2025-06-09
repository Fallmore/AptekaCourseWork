using Apteka.ViewModel.EmployeeVM;

namespace Apteka.View.LoginV
{
	public partial class ChooseRoleForm : Form
	{
		internal int ChoosedRole = -1;

		public ChooseRoleForm()
		{
			InitializeComponent();
			CreateRoleButtons();
		}

		private void CreateRoleButtons()
		{
			const int buttonWidth = 200;
			const int buttonHeight = 40;
			const int margin = 10;

			int yPosition = margin;

			foreach (var role in EmployeeAccountViewModel.GetRoles(EmployeeAccountViewModel.GetCurrentEmployee()))
			{
				var btn = new Button
				{
					Text = $"Войти как {role.Name}",
					Tag = role.IdRole, // Сохраняем данные роли в Tag
					Size = new Size(buttonWidth, buttonHeight),
					Location = new Point(margin, yPosition),
					Font = new Font("Arial", 10, FontStyle.Bold)
				};

				btn.Click += RoleButton_Click;
				Controls.Add(btn);

				yPosition += buttonHeight + margin;
			}

			// Настраиваем размер формы
			ClientSize = new Size(
				buttonWidth + margin * 2,
				yPosition);
		}

		private void RoleButton_Click(object sender, EventArgs e)
		{
			var button = (Button)sender;
			ChoosedRole = int.Parse(button.Tag?.ToString() ?? "-1");
			DialogResult = DialogResult.OK;
		}
	}
}
