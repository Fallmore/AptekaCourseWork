namespace Apteka
{
	internal static class RoleManager
	{
		internal static bool IsRoleCorrect(Roles havingRole, Roles[] neededRoles)
		{
			return neededRoles.Contains(havingRole);
		}
	}

	internal enum Roles
	{
		Сотрудник = 1,
		Кассир = 2,
		УправляющийОтдела = 3,
		Директор = 4
	}
}
