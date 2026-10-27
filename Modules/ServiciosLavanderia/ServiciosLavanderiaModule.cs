

using LavanderiaAPI.Modules.ServiciosLavanderia.Services;
using LavanderiaAPI.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LavanderiaAPI.Modules.ServiciosLavanderia;

public static class ServiciosLavanderiaModule
{
    public static IServiceCollection AddServiciosLavanderia(
        this IServiceCollection services)
    {
        services.AddScoped<ServicioLavanderiaRepository>();
        services.AddScoped<ServicioLavanderiaService>();

        return services;
    }
}
