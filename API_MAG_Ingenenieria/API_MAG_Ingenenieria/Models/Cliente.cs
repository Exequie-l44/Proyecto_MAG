using System;
using System.Collections.Generic;

namespace API_MAG_Ingenenieria.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Areas = new HashSet<Area>();
        }

        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}
