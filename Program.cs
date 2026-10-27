

using LavanderiaAPI.Data;
using LavanderiaAPI.Modules.ServiciosLavanderia;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("postgresConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "No se encontró la cadena de conexión 'postgresConnection' en appsettings.json."
    );
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString)
);

builder.Services.AddServiciosLavanderia();

var app = builder.Build();

app.MapGet("/", () => "API de Lavandería funcionando correctamente");

app.MapControllers();

app.Run();
