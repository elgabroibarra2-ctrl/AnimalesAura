using Aplicacion.Interfaces;
using Aplicacion.Services;
using Dominio.Interfaces;
using Infraestructura.Data;
using Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);


// ============================================================
// 1. MVC
// ============================================================

// Agrega soporte para controladores MVC y vistas Razor.
builder.Services.AddControllersWithViews();


// ============================================================
// 2. OPEN API
// ============================================================

// Genera la documentación OpenAPI de nuestros endpoints.
// Scalar utilizará esta información para construir su interfaz.
builder.Services.AddOpenApi();


// ============================================================
// 3. BASE DE DATOS
// ============================================================

// Recuperamos la cadena de conexión llamada "DefaultConnection"
// desde appsettings.json.
builder.Services.AddDbContext<TravelPlaningDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


// ============================================================
// 4. REPOSITORIOS
// ============================================================

// Cuando alguna clase solicite IViajeRepository,
// Dependency Injection entregará ViajeRepository.
builder.Services.AddScoped<IViajeRepository, ViajeRepository>();

builder.Services.AddScoped<IActividadRepository, ActividadRepository>();

builder.Services.AddScoped<IGastoRepository, GastoRepository>();


// ============================================================
// 5. SERVICIOS DE APLICACIÓN
// ============================================================

// Aplicamos la misma idea:
// el controlador conoce la interfaz,
// no la implementación concreta.
builder.Services.AddScoped<IViajeService, ViajeService>();

builder.Services.AddScoped<IActividadService, ActividadService>();

builder.Services.AddScoped<IGastoService, GastoService>();


// ============================================================
// CONSTRUCCIÓN DE LA APLICACIÓN
// ============================================================

var app = builder.Build();

// Habilita la lectura de archivos en wwwroot (CSS, JS, imágenes)
app.UseStaticFiles();

app.UseRouting();

// ============================================================
// 6. CONFIGURACIÓN HTTP
// ============================================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();


// ============================================================
// 7. OPEN API + SCALAR
// ============================================================

// Por ahora lo dejamos disponible durante desarrollo.
if (app.Environment.IsDevelopment())
{
    // Documento OpenAPI.
    app.MapOpenApi();

    // Interfaz gráfica para probar nuestra API.
    app.MapScalarApiReference();
}


// ============================================================
// 8. CONTROLADORES API
// ============================================================

// Permite encontrar controladores que utilizan rutas por atributos:
//
// [ApiController]
// [Route("api/[controller]")]
//
app.MapControllers();


// ============================================================
// 9. RUTA MVC
// ============================================================

// Esta será utilizada posteriormente por nuestros
// controladores MVC y las Views.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// ============================================================
// 10. EJECUTAR APLICACIÓN
// ============================================================

app.Run();