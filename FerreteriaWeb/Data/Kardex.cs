using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaWeb.Data
{
    [Table("Kardex")]
    public class Kardex
    {
        [Key]
        [Column("id_kardex")]
        public int id_kardex { get; set; }

        [Column("producto_id")]
        public int producto_id { get; set; }

        [Column("tipo_movimiento")]
        public string tipo_movimiento { get; set; } = "";

        [Column("cantidad")]
        public decimal cantidad { get; set; }

        [Column("saldo_post_mov")]
        public decimal saldo_post_mov { get; set; }

        [Column("fecha_registro")]
        public DateTime fecha { get; set; } = DateTime.Now;
    }
}