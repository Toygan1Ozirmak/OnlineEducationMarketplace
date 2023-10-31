using OnlineEducationMarketplace.Data.NewFolder;
using OnlineEducationMarketplace.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using OnlineEducationMarketplace.Services.Contracts;
using OnlineEducationMarketplace.Services.Managers;
using OnlineEducationMarketplace.Services;
using OnlineEducationMarketplace.Data.Repositories;
using OnlineEducationMarketplace.Data.Contracts;

namespace OEMAP.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) => services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();



        //log
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();

    }
}