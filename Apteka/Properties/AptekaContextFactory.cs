using Apteka.Properties.DataSources;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Apteka.Properties
{
	internal class AptekaContextFactory
	{
		internal static AptekaContext Create(string username, string password)
		{
			var originalConnectionString = "Host=localhost;Database=Apteka;";
			var builder = new NpgsqlConnectionStringBuilder(originalConnectionString)
			{
				Username = username,
				Password = password
			};

			var optionsBuilder = new DbContextOptionsBuilder<AptekaContext>();
			optionsBuilder.UseNpgsql(builder.ToString());

			return new AptekaContext(optionsBuilder.Options);
		}
	}
}
