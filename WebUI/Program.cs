using Application.Configuration;
using Domain.Configuration;
using Infrastructure.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

// Add services to the container.
builder.Services
    .AddInfrastructure(configuration)
    .AddApplication()
    .AddDomain()
    .AddControllersWithViews();

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq(configuration.GetSection("Seq:ServerUrl").Value!)
    .CreateLogger();

logger.Information("Logger started!");

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
