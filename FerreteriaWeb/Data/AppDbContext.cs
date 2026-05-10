using Microsoft.EntityFrameworkCore;

namespace FerreteriaWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Kardex> Kardex { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Caja> Caja { get; set; }
        // public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Venta>();

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.Property(e => e.nombre_login).HasColumnName("usuario");
                entity.Property(e => e.password).HasColumnName("clave");
                entity.Property(e => e.rol).HasColumnName("rol");
            });
        }
    }
}