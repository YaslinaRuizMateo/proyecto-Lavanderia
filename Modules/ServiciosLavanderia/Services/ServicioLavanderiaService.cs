

using LavanderiaAPI.Modules.ServiciosLavanderia.Dtos;
using LavanderiaAPI.Modules.ServiciosLavanderia.Entities;
using LavanderiaAPI.Repositories;

namespace LavanderiaAPI.Modules.ServiciosLavanderia.Services;

public class ServicioLavanderiaService
{
    private readonly ServicioLavanderiaRepository _repository;

    public ServicioLavanderiaService(
        ServicioLavanderiaRepository repository)
    {
        _repository = repository;
    }

    public List<ServicioLavanderia> ObtenerTodos()
    {
        return _repository.ObtenerTodos();
    }

    public ServicioLavanderia? ObtenerPorUuid(Guid uuid)
    {
        return _repository.ObtenerPorUuid(uuid);
    }

    public ServicioLavanderia Crear(CrearServicioDto dto)
    {
        var servicio = new ServicioLavanderia
        {
            Uuid = Guid.NewGuid(),
            Cliente = dto.Cliente.Trim(),
            Telefono = dto.Telefono.Trim(),
            TipoServicio = dto.TipoServicio.Trim(),
            CantidadPrendas = dto.CantidadPrendas,
            Precio = dto.Precio,
            EstadoPago = dto.EstadoPago,
            EstadoServicio = dto.EstadoServicio
        };

        return _repository.Crear(servicio);
    }

    public ServicioLavanderia? Actualizar(
        Guid uuid,
        ActualizarServicioDto dto)
    {
        var servicio = _repository.ObtenerPorUuid(uuid);

        if (servicio is null)
            return null;

        if (dto.Cliente is not null)
            servicio.Cliente = dto.Cliente.Trim();

        if (dto.Telefono is not null)
            servicio.Telefono = dto.Telefono.Trim();

        if (dto.TipoServicio is not null)
            servicio.TipoServicio = dto.TipoServicio.Trim();

        if (dto.CantidadPrendas.HasValue)
            servicio.CantidadPrendas = dto.CantidadPrendas.Value;

        if (dto.Precio.HasValue)
            servicio.Precio = dto.Precio.Value;

        if (dto.EstadoPago is not null)
            servicio.EstadoPago = dto.EstadoPago.Trim();

        if (dto.EstadoServicio is not null)
            servicio.EstadoServicio = dto.EstadoServicio.Trim();

        return _repository.Actualizar(servicio);
    }

    public bool Eliminar(Guid uuid)
    {
        return _repository.Eliminar(uuid);
    }
}
