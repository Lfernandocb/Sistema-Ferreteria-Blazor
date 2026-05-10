using Microsoft.EntityFrameworkCore;

namespace FerreteriaWeb.Data
{
    public class ProductoService
    {
        private readonly AppDbContext _context;

        public string UltimoError { get; private set; } = "";

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetProductosAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<bool> InsertarProductoAsync(Producto producto)
        {
            UltimoError = "";

            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                UltimoError = ex.InnerException?.Message ?? ex.Message;
                return false;
            }
        }

        public async Task<bool> ActualizarProductoAsync(Producto producto)
        {
            UltimoError = "";

            try
            {
                _context.Productos.Update(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                UltimoError = ex.InnerException?.Message ?? ex.Message;
                return false;
            }
        }

        public async Task<bool> EliminarProductoAsync(int id)
        {
            UltimoError = "";

            try
            {
                var producto = await _context.Productos.FindAsync(id);

                if (producto == null)
                    return false;

                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                UltimoError = ex.InnerException?.Message ?? ex.Message;
                return false;
            }
        }
    }
}