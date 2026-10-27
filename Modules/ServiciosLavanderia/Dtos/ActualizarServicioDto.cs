

using System.ComponentModel.DataAnnotations;

namespace LavanderiaAPI.Modules.ServiciosLavanderia.Dtos;

public class ActualizarServicioDto
{
    [MinLength(2)]
    public string? Cliente { get; set; }

    [MinLength(7)]
    public string? Telefono { get; set; }

    [MinLength(2)]
    public string? TipoServicio { get; set; }

    [Range(1, 1000)]
    public int? CantidadPrendas { get; set; }

    [Range(typeof(decimal), "0.01", "1000000")]
    public decimal? Precio { get; set; }

    [RegularExpression("^(Pagado|Debe)$")]
    public string? EstadoPago { get; set; }

    [RegularExpression("^(Recibido|En proceso|Listo|Entregado)$")]
    public string? EstadoServicio { get; set; }
}
