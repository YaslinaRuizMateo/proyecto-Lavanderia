

using LavanderiaAPI.Data;
using LavanderiaAPI.Modules.ServiciosLavanderia.Entities;
using Microsoft.EntityFrameworkCore;

namespace LavanderiaAPI.Repositories;

public class ServicioLavanderiaRepository
{
    private readonly AppDbContext _dbContext;

    public ServicioLavanderiaRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<ServicioLavanderia> ObtenerTodos()
    {
        return _dbContext.ServiciosLavanderia
            .AsNoTracking()
            .OrderBy(s => s.Id)
            .ToList();
    }

    public ServicioLavanderia? ObtenerPorUuid(Guid uuid)
    {
        return _dbContext.ServiciosLavanderia
            .FirstOrDefault(s => s.Uuid == uuid);
    }

    public ServicioLavanderia Crear(ServicioLavanderia servicio)
    {
        _dbContext.ServiciosLavanderia.Add(servicio);
        _dbContext.SaveChanges();

        return servicio;
    }

    public ServicioLavanderia? Actualizar(ServicioLavanderia servicio)
    {
        var existente = ObtenerPorUuid(servicio.Uuid);

        if (existente is null)
            return null;

        existente.Cliente = servicio.Cliente;
        existente.Telefono = servicio.Telefono;
        existente.TipoServicio = servicio.TipoServicio;
        existente.CantidadPrendas = servicio.CantidadPrendas;
        existente.Precio = servicio.Precio;
        existente.EstadoPago = servicio.EstadoPago;
        existente.EstadoServicio = servicio.EstadoServicio;

        _dbContext.SaveChanges();

        return existente;
    }

    public bool Eliminar(Guid uuid)
    {
        var servicio = ObtenerPorUuid(uuid);

        if (servicio is null)
            return false;

        _dbContext.ServiciosLavanderia.Remove(servicio);
        _dbContext.SaveChanges();

        return true;
    }
}
