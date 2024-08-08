using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class Doctore
    {
        public Doctore()
        {
            CalendarioCirugia = new HashSet<CalendarioCirugia>();
        }

        public int IdDoctor { get; set; }
        public string NombreDoctor { get; set; } = null!;
        public string? TelefonoDoctor { get; set; }
        public int? EdadDoctor { get; set; }
        public string? NacionalidadDoctor { get; set; }
        public string IdentificacionDoctor { get; set; } = null!;
        public string? SexoDoctor { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdEspecialidad { get; set; }
        public int? IdOcupacion { get; set; }

        public virtual EspecialidadesMedica? IdEspecialidadNavigation { get; set; }
        public virtual OcupacionMedica? IdOcupacionNavigation { get; set; }
        public virtual ICollection<CalendarioCirugia> CalendarioCirugia { get; set; }
    }
}
