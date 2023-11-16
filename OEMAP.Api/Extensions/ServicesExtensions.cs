using OnlineEducationMarketplace.Data.NewFolder;
using OnlineEducationMarketplace.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using OnlineEducationMarketplace.Services.Contracts;
using OnlineEducationMarketplace.Services.Managers;
using OnlineEducationMarketplace.Services;
using OnlineEducationMarketplace.Data.Repositories;
using OnlineEducationMarketplace.Data.Contracts;
using Microsoft.AspNetCore.Identity;
using OEMAP.Api.ActionFilters;

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

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequiredLength = 10;  
                opts.User.RequireUniqueEmail = true;
            })

                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }



        //log
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();


        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddSingleton<LogFilterAttribute>();
        }
    }
}