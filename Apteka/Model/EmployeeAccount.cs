namespace Apteka.Model;

public partial class EmployeeAccount
{
	public Guid IdEmployee { get; set; }

	public string Login { get; set; } = null!;

	public string Password { get; set; } = null!;

	public List<int> Roles { get; set; } = null!;

	public bool Online { get; set; }

	public virtual Employee IdEmployeeNavigation { get; set; } = null!;
}
