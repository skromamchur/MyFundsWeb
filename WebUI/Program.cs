using Application.Configuration;
using Domain.Configuration;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

// Add services to the container.
builder.Services
    .AddInfrastructure(configuration)
    .AddApplication()
    .AddDomain()
    .AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Auth";
    options.LogoutPath = "/Auth";
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.Redirect("/Auth");
        return Task.CompletedTask;
    };
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
