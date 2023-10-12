using OnlineEducationMarketplace.Data.NewFolder;
using OnlineEducationMarketplace.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace OEMAP.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, 
            IConfiguration configuration) => services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }
    }
}
