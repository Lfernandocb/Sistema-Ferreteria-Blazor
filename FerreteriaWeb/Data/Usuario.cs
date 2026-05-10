using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaWeb.Data
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int id_usuario { get; set; }

        [Column("usuario")]
        public string nombre_login { get; set; } = string.Empty;

        [Column("clave")]
        public string password { get; set; } = string.Empty;

        [Column("rol")]
        public string rol { get; set; } = string.Empty;
    }
}