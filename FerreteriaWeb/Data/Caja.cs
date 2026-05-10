using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaWeb.Data
{
    [Table("Caja")]
    public class Caja
    {
        [Key]
        [Column("id_caja")]
        public int id_caja { get; set; }

        [Column("usuario_id")]
        public int usuario_id { get; set; }

        [Column("monto_apertura")]
        public decimal monto_apertura { get; set; }

        [Column("monto_cierre")]
        public decimal monto_cierre { get; set; }

        [Column("estado")]
        public string estado { get; set; } = "ABIERTA";

        [Column("fecha_apertura")]
        public DateTime? fecha_apertura { get; set; }

        [Column("fecha_cierre")]
        public DateTime? fecha_cierre { get; set; }

        [Column("diferencia")]
        public decimal? diferencia { get; set; }
    }
}