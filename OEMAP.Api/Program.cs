using DocumentFormat.OpenXml.Presentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLog;
using OEMAP.Api.ActionFilters;
using OEMAP.Api.Extensions;
using OnlineEducationMarketplace.Data.NewFolder;
using OnlineEducationMarketplace.Data.Repositories;
using OnlineEducationMarketplace.Services.Contracts;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
})
    
    .AddXmlDataContractSerializerFormatters()
    .AddNewtonsoftJson();

builder.Services.AddScoped<ValidationFilterAttribute>();//IoC 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<RepositoryContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));





builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureActionFilters();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();