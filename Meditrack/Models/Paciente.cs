using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class Paciente
    {
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }
        public string? SexoPaciente { get; set; }
        public int? EdadPaciente { get; set; }
        public string? IdentificacionPaciente { get; set; }
        public string? NacionalidadPaciente { get; set; }
        public string? TelefonoPaciente { get; set; }
        public string? TipoSanguineo { get; set; }
        public int? SeguroMedico { get; set; }
        public string? HistorialMedico { get; set; }
    }
}
