using Apteka.BaseClasses;

namespace Apteka.Model;

public partial class EmployeeRole : UnionId
{
	public override object GetId() => IdRole;
	public int IdRole { get; set; }

	public string Name { get; set; } = null!;
}
