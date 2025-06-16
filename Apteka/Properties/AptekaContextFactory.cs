using Apteka.Properties.DataSources;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Apteka.Properties
{
	internal class AptekaContextFactory
	{
		internal static bool CanConnect = false;
		internal static AptekaContext Create(string username, string password)
		{
			var builder = new NpgsqlConnectionStringBuilder()
			{
				Host = Settings.Default.Host,
				Database = Settings.Default.Database,
				Username = username,
				Password = password
			};

			var optionsBuilder = new DbContextOptionsBuilder<AptekaContext>();
			optionsBuilder.UseNpgsql(builder.ToString());

			AptekaContext dbContext = new(optionsBuilder.Options);
			CanConnect = dbContext.Database.CanConnect();

			return dbContext;
		}
	}
}
