using E_comerce_Videogame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar soporte para sesiones
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Agregar servicios de autenticación y autorización
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.Cookie.Name = "AuthCookie";
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Home/Error";
    });

builder.Services.AddAuthorization();

// Agregar soporte para Newtonsoft.Json
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson();

var app = builder.Build();

// Configurar el pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Debe ir antes de UseAuthentication y UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();