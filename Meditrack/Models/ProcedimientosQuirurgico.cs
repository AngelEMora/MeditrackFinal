using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class ProcedimientosQuirurgico
    {
        public ProcedimientosQuirurgico()
        {
            CalendarioCirugia = new HashSet<CalendarioCirugia>();
        }

        public int IdProcedimiento { get; set; }
        public string NombreProcedimiento { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? RiesgosComplicaciones { get; set; }
        public TimeSpan? DuracionEstimada { get; set; }

        public virtual ICollection<CalendarioCirugia> CalendarioCirugia { get; set; }
    }
}
