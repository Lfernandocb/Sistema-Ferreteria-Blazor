using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaWeb.Data
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        [Column("id_producto")]
        public int id_producto { get; set; }

        [Column("nombre")]
        public string nombre { get; set; } = string.Empty;

        [Column("categoria_id")]
        public int categoria_id { get; set; } = 1;

        [Column("unidad_id")]
        public int unidad_id { get; set; } = 1;

        [Column("precio_compra")]
        public decimal precio_compra { get; set; } = 0;

        [Column("precio_venta")]
        public decimal precio_venta { get; set; }

        [Column("stock_real")]
        public decimal stock_real { get; set; }

        [Column("stock_minimo")]
        public decimal stock_minimo { get; set; } = 1;
    }
}