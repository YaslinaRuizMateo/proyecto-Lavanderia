

using LavanderiaAPI.Modules.ServiciosLavanderia.Entities;
using Microsoft.EntityFrameworkCore;

namespace LavanderiaAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ServicioLavanderia> ServiciosLavanderia =>
        Set<ServicioLavanderia>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ServicioLavanderia>(entity =>
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.Uuid).IsRequired();
            entity.HasIndex(s => s.Uuid).IsUnique();

            entity.Property(s => s.Cliente).IsRequired();
            entity.Property(s => s.Telefono).IsRequired();
            entity.Property(s => s.TipoServicio).IsRequired();
            entity.Property(s => s.EstadoPago).IsRequired();
            entity.Property(s => s.EstadoServicio).IsRequired();

            entity.Property(s => s.Precio).HasPrecision(10, 2);
        });
    }
}
