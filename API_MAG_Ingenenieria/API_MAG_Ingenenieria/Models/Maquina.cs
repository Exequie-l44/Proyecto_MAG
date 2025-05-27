using System;
using System.Collections.Generic;

namespace API_MAG_Ingenenieria.Models
{
    public partial class Maquina
    {
        public Maquina()
        {
            Trabajos = new HashSet<Trabajo>();
        }

        public int IdMaquina { get; set; }
        public string NombreMaquina { get; set; } = null!;
        public string? ArregloDescripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? IdArea { get; set; }

        public virtual Area? IdAreaNavigation { get; set; }
        public virtual ICollection<Trabajo> Trabajos { get; set; }
    }
}
