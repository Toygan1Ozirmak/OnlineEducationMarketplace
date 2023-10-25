using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLog;
using OEMAP.Api.Extensions;
using OnlineEducationMarketplace.Data.NewFolder;
using OnlineEducationMarketplace.Data.Repositories;
using OnlineEducationMarketplace.Services.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<RepositoryContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

//options.UseSqlServer(connection, b => b.MigrationsAssembly("OnlineEducationMarketplace.Data"));



builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
