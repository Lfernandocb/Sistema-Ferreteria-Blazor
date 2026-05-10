using System.ComponentModel.DataAnnotations;

namespace FerreteriaWeb.Data
{
    public class Cliente
    {
        [Key]
        public int id_cliente { get; set; } // Identificador único [cite: 619]
        public string nombre_cliente { get; set; } // Nombre completo o negocio [cite: 620]
        public string ruc_cedula { get; set; } // Identificación fiscal [cite: 620]
        public bool es_mayorista { get; set; } // Para compras al crédito [cite: 621]
    }
}