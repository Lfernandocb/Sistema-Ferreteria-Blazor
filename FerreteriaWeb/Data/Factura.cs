using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaWeb.Data
{
    [Table("Ventas")]
    public class Factura
    {
        [Key]
        [Column("id_venta")]
        public int id_factura { get; set; }

        [Column("fecha")]
        public DateTime fecha { get; set; } = DateTime.Now;

        [Column("cliente_id")]
        public int cliente_id { get; set; } = 1;

        [Column("usuario_id")]
        public int usuario_id { get; set; }

        [Column("tipo_venta")]
        public string tipo_venta { get; set; } = "CONTADO";

        [Column("total_venta")]
        public decimal total { get; set; }

        [NotMapped]
        public string cliente { get; set; } = "Consumidor Final";

        [NotMapped]
        public string estado { get; set; } = "Pagada";

        [NotMapped]
        public List<FacturaDetalle> Detalles { get; set; } = new();
    }
}