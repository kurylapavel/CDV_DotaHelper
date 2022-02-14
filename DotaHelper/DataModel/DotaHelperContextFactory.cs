using Common.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;

namespace DataModel
{
    public class DotaHelperContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Building config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API.Service"))
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            ConnectionString connectionString = new ConnectionString();
            config.GetSection("ConnectionString").Bind(connectionString);

            var connection = $"Server={connectionString.Host};Port={connectionString.Port};Database=DotaHelper;" +
                $"User Id={connectionString.UserName};Password{connectionString.Password};";

            optionsBuilder.UseNpgsql(connection, x => x.MigrationsAssembly("DataModel"));

            return new AppDbContext(optionsBuilder.Options, Options.Create(connectionString));
        }
    }
}
