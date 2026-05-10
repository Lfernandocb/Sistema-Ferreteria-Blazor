using Microsoft.EntityFrameworkCore;
using FerreteriaWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración básica
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Conexión a la Base de Datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de Servicios (Solo los que estamos seguros que existen)
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<FacturaService>();

// Si estos te dan error, los dejamos "comentados" con // para que el proyecto corra
// builder.Services.AddScoped<ClienteService>();
// builder.Services.AddScoped<CajaService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();