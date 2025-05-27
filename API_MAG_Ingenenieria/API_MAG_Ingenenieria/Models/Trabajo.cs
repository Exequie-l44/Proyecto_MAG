using System;
using System.Collections.Generic;

namespace API_MAG_Ingenenieria.Models
{
    public partial class Trabajo
    {
        public int IdTrabajo { get; set; }
        public int? IdMaquina { get; set; }
        public string? Descripcion { get; set; }
        public string? PagoTrabajo { get; set; }
        public DateTime? FechaTrabajo { get; set; }

        public virtual Maquina? IdMaquinaNavigation { get; set; }
    }
}
