using Apteka.View.EmployeeV;
using Apteka.ViewModel;

namespace Apteka
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			GeneralViewModel.Instance.Initialize();
			Application.Run(new EmployeesForm());
		}
	}
}