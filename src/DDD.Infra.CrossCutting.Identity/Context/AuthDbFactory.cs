using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DDD.Infra.CrossCutting.Identity.Data
{
    public class AuthDbFactory : IDesignTimeDbContextFactory<AuthDbContext>
    {
        public AuthDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .AddEnvironmentVariables()
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<AuthDbContext>();

            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new AuthDbContext(dbContextBuilder.Options);
        }
    }
}
