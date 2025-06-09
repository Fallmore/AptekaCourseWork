using Apteka.ViewModel.EmployeeVM;
using System.Data;

namespace Apteka.View.EmployeeV
{
	public partial class EmployeeRolesForm : Form
	{
		private EmployeeViewModel _viewModel;

		public EmployeeRolesForm()
		{
			InitializeComponent();
			_viewModel = new();
			SetItemRoles();
		}

		private void SetItemRoles()
		{
			string[] roles = _viewModel.General.EmployeeRoles
				.OrderBy(er => er.IdRole)
				.Select(er => er.Name)
				.Where(name => name != "Директор")
			.ToArray();

			if (_viewModel.General.ChoosedRole == (int)Roles.УправляющийОтдела)
				roles = roles.Where(r => r != "Управляющий отдела").ToArray();

			clbRoles.Items.AddRange(roles);
		}
	}
}
