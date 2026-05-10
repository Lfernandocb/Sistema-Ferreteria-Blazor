using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaWeb.Data
{
    [Table("Detalle_Ventas")]
    public class FacturaDetalle
    {
        [Key]
        [Column("id_detalle")]
        public int id_detalle { get; set; }

        [Column("venta_id")]
        public int factura_id { get; set; }

        [Column("producto_id")]
        public int producto_id { get; set; }

        [Column("cantidad")]
        public decimal cantidad { get; set; }

        [Column("precio_unitario")]
        public decimal precio_unitario { get; set; }

        [NotMapped]
        public decimal subtotal => cantidad * precio_unitario;

        [NotMapped]
        public Producto? Producto { get; set; }
    }
}