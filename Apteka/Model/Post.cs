namespace Apteka.Model;

public partial class Post
{
	public int IdPost { get; set; } = -1;

	public string Name { get; set; } = null!;

	public float Salary { get; set; }

	public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

	public virtual ICollection<OrderAssign> OrderAssignIdNewPostNavigations { get; set; } = new List<OrderAssign>();

	public virtual ICollection<OrderAssign> OrderAssignIdOldPostNavigations { get; set; } = new List<OrderAssign>();
}
