using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineEducationMarketplace.Data.NewFolder;

namespace OEMAP.Api.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            //confg
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //dbcontextoptionsbuilder
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                prj => prj.MigrationsAssembly("OEMAP.Api"));

            return new RepositoryContext(builder.Options);
        }
    }
}