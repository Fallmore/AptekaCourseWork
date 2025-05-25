
namespace Apteka.Registration.Model
{
	internal class RegModel
	{
		/// <summary>
		/// Словарь логинов и паролей
		/// </summary>
		public Dictionary<string, string> Users { get; init; }

		public RegModel()
		{
			Users = new();
		}
	}
}
