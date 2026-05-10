using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaWeb.Data
{
    [Table("Ventas")]
    public class Venta
    {
        [Key]
        [Column("id_venta")]
        public int Id { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Column("cliente_id")]
        public int cliente_id { get; set; }

        [Column("usuario_id")]
        public int usuario_id { get; set; }

        [Column("tipo_venta")]
        public string tipo_venta { get; set; } = "";

        [Column("total_venta")]
        public decimal Total { get; set; }

        [NotMapped]
        public string ClienteNombre => $"Cliente #{cliente_id}";
    }
}