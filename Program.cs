using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using URLCutter.BLL.Interfaces;
using URLCutter.BLL.Services;
using URLCutter.Data;
using URLCutter.Data.Interfaces;
using URLCutter.Data.Repository;
using URLCutter.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IShortURLRepository, ShortURLRepository>();

builder.Services.AddScoped<IShortUrlService, ShortUrlService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UrlCutterConnection"));
});

builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        await AdminSeed.Initialize(services);
    }
    catch (Exception ex)
    {
        // Логирование ошибок (например, с помощью ILogger)
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ошибка инициализации ролей и пользователей");
    }
}

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
