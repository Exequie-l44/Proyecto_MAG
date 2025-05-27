using System;
using System.Collections.Generic;

namespace API_MAG_Ingenenieria.Models
{
    public partial class Area
    {
        public Area()
        {
            Maquinas = new HashSet<Maquina>();
        }

        public int IdArea { get; set; }
        public string NombreArea { get; set; } = null!;
        public int? IdCliente { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual ICollection<Maquina> Maquinas { get; set; }
    }
}
