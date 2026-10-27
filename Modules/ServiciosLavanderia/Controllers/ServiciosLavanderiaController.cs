
using Microsoft.AspNetCore.Mvc;
using LavanderiaAPI.Modules.ServiciosLavanderia.Dtos;
using LavanderiaAPI.Modules.ServiciosLavanderia.Services;
using LavanderiaAPI.Modules.ServiciosLavanderia.Entities;

namespace LavanderiaAPI.Modules.ServiciosLavanderia.Controllers;

[ApiController]
[Route("api/servicios")]
public class ServiciosLavanderiaController : ControllerBase
{
    private readonly ServicioLavanderiaService _service;

    public ServiciosLavanderiaController(ServicioLavanderiaService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        return Ok(_service.ObtenerTodos());
    }

    [HttpGet("{uuid:guid}")]
    public IActionResult ObtenerPorUuid(Guid uuid)
    {
        var servicio = _service.ObtenerPorUuid(uuid);

        if (servicio is null)
            return NotFound(new { mensaje = "Servicio no encontrado" });

        return Ok(servicio);
    }

    [HttpPost]
    public IActionResult Crear(CrearServicioDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var servicio = _service.Crear(dto);

        return CreatedAtAction(
            nameof(ObtenerPorUuid),
            new { uuid = servicio.Uuid },
            servicio
        );
    }

    [HttpPatch("{uuid:guid}")]
    public IActionResult Actualizar(Guid uuid, ActualizarServicioDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (dto.CantidadPrendas.HasValue && dto.CantidadPrendas.Value <= 0)
            return BadRequest(new { mensaje = "La cantidad de prendas debe ser mayor que cero" });

        if (dto.Precio.HasValue && dto.Precio.Value <= 0)
            return BadRequest(new { mensaje = "El precio debe ser mayor que cero" });

        var servicio = _service.Actualizar(uuid, dto);

        if (servicio is null)
            return NotFound(new { mensaje = "Servicio no encontrado" });

        return Ok(servicio);
    }

    [HttpDelete("{uuid:guid}")]
    public IActionResult Eliminar(Guid uuid)
    {
        var eliminado = _service.Eliminar(uuid);

        if (!eliminado)
            return NotFound(new { mensaje = "Servicio no encontrado" });

        return Ok(new { mensaje = "Servicio eliminado correctamente" });
    }
}
