using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class EstadosCirugia
    {
        public EstadosCirugia()
        {
            CalendarioCirugia = new HashSet<CalendarioCirugia>();
        }

        public int IdEstadoCirugias { get; set; }
        public string NombreEstadosCirugia { get; set; } = null!;

        public virtual ICollection<CalendarioCirugia> CalendarioCirugia { get; set; }
    }
}
