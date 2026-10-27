

using System.ComponentModel.DataAnnotations;

namespace LavanderiaAPI.Modules.ServiciosLavanderia.Dtos;

public class CrearServicioDto
{
    [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
    [MinLength(2)]
    public string Cliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [MinLength(7)]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "El tipo de servicio es obligatorio")]
    [MinLength(2)]
    public string TipoServicio { get; set; } = string.Empty;

    [Range(1, 1000, ErrorMessage = "La cantidad de prendas debe ser mayor que cero")]
    public int CantidadPrendas { get; set; }

    [Range(typeof(decimal), "0.01", "1000000", ErrorMessage = "El precio debe ser mayor que cero")]
    public decimal Precio { get; set; }

    [Required]
    [RegularExpression("^(Pagado|Debe)$", ErrorMessage = "El estado de pago debe ser Pagado o Debe")]
    public string EstadoPago { get; set; } = "Debe";

    [Required]
    [RegularExpression("^(Recibido|En proceso|Listo|Entregado)$", ErrorMessage = "El estado del servicio no es válido")]
    public string EstadoServicio { get; set; } = "Recibido";
}
