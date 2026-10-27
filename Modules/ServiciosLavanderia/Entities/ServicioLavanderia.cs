

namespace LavanderiaAPI.Modules.ServiciosLavanderia.Entities;

public class ServicioLavanderia
{
    public int Id { get; set; }

    public Guid Uuid { get; set; } = Guid.NewGuid();

    public string Cliente { get; set; } = string.Empty;

    public string Telefono { get; set; } = string.Empty;

    public string TipoServicio { get; set; } = string.Empty;

    public int CantidadPrendas { get; set; }

    public decimal Precio { get; set; }

    public string EstadoPago { get; set; } = "Debe";

    public string EstadoServicio { get; set; } = "Recibido";
}
