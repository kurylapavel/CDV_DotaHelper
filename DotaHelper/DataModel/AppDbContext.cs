using Common.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection;
using DataModel.Contracts;

namespace DataModel
{
    public  class AppDbContext : DbContext
    {
        private readonly ConnectionString _config;

        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<ConnectionString> config) : base(options)
        {
            _config = config.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = $"Host={_config.Host};Port={_config.Port};Database=DotaHelper;" +
                $"Username={_config.UserName};Password={_config.Password};";

            //var connection = $"Host=185.233.200.171;Port=5432;Database=DotaHelper;" +
            //    $"Username=postgres;Password=dotoproj1;";

            optionsBuilder.UseNpgsql(connection);

            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var entityTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass && typeof(IEntity).IsAssignableFrom(x));

            foreach (var entityType in entityTypes)
            {
                var entity = (IEntity)Activator.CreateInstance(entityType);
                entity.Configure(builder);
            }
        }
    }
}
