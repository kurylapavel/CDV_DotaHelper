using Common.Settings;
using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHelpet_Tests.Common
{
    public class DotaHelperTestsContextFactory
    {
        public static AppDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var config = Options.Create<ConnectionString>(new ConnectionString()
            {
                Host = "185.233.200.171",
                Port = 5432,
                UserName = "postgres",
                Password = "dotoproj1",
                DatabaseName = "DotaHelper_Tests",
            });

            var context = new AppDbContext(options, config);

            return context;
        }

        public static AppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            ConnectionString connectionString = new ConnectionString()
            {
                Host = "185.233.200.171",
                Port = 5432,
                UserName = "postgres",
                Password = "dotoproj1",
                DatabaseName = "DotaHelper_Tests",
            };

            var connection = $"Server={connectionString.Host};Port={connectionString.Port};Database={connectionString.DatabaseName};" +
                $"User Id={connectionString.UserName};Password{connectionString.Password};";

            optionsBuilder.UseNpgsql(connection, x => x.MigrationsAssembly("DataModel"));

            return new AppDbContext(optionsBuilder.Options, Options.Create(connectionString));
        }
    }
}
