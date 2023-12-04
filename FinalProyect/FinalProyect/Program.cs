using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProyect.Services;
var builder = WebApplication.CreateBuilder(args);

// Configuración de Entity Framework y conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Configuración del servicio IParticipanteService
builder.Services.AddScoped<IParticipanteService, ParticipanteServiceSQL>();
builder.Services.AddScoped<IConferenciaService, ConferenciaServiceSQL>();
builder.Services.AddScoped<IAsistenciaService, AsistenciaServiceSQL>();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

// Configuración de migraciones y creación de la base de datos al iniciar la aplicación
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate(); // Aplica migraciones pendientes
        // Puedes agregar más lógica de inicialización de la base de datos aquí si es necesario
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error al aplicar migraciones y/o inicializar la base de datos.");
    }
}

app.Run();
