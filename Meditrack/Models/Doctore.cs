using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class Doctore
    {
        public int IdDoctor { get; set; }
        public string NombreDoctor { get; set; } = null!;
        public string? TelefonoDoctor { get; set; }
        public int? EdadDoctor { get; set; }
        public string? NacionalidadDoctor { get; set; }
        public string IdentificacionDoctor { get; set; } = null!;
        public string? SexoDoctor { get; set; }
        public string Especialidad { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }
    }
}
