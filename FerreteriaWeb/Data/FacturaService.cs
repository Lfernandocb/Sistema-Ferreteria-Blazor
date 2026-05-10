using Microsoft.EntityFrameworkCore;

namespace FerreteriaWeb.Data
{
    public class FacturaService
    {
        private readonly AppDbContext _context;

        public string UltimoError { get; private set; } = "";

        public FacturaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearFacturaAsync(Factura factura, List<FacturaDetalle> detalles)
        {
            UltimoError = "";

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                factura.fecha = DateTime.Now;

                factura.total = detalles.Sum(d => d.subtotal) * 1.15m;

                _context.Facturas.Add(factura);

                await _context.SaveChangesAsync();

                foreach (var detalle in detalles)
                {
                    var producto = await _context.Productos
                        .FirstOrDefaultAsync(p => p.id_producto == detalle.producto_id);

                    if (producto == null)
                    {
                        throw new Exception("Producto no encontrado.");
                    }

                    if (producto.stock_real < detalle.cantidad)
                    {
                        throw new Exception($"Stock insuficiente para {producto.nombre}");
                    }

                    producto.stock_real -= detalle.cantidad;

                    detalle.factura_id = factura.id_factura;
                    detalle.precio_unitario = producto.precio_venta;

                    _context.FacturaDetalles.Add(detalle);

                    _context.Kardex.Add(new Kardex
                    {
                        producto_id = producto.id_producto,
                        tipo_movimiento = "SALIDA",
                        cantidad = detalle.cantidad,
                        saldo_post_mov = producto.stock_real,
                        fecha = DateTime.Now
                    });
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                UltimoError = ex.InnerException?.Message ?? ex.Message;

                return false;
            }
        }

        public async Task<List<Factura>> GetFacturasAsync()
        {
            return await _context.Facturas
                .OrderByDescending(f => f.fecha)
                .ToListAsync();
        }
    }
}