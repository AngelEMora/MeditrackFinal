
using System;
using System.Collections.Generic;
using Meditrack.Validation;
using System.ComponentModel.DataAnnotations;

namespace Meditrack.Models
{
    public partial class Paciente
    {
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "El nombre del paciente es requerido")]
        public string NombrePaciente { get; set; } = null!;

        [ValidacionFechaNacimiento(ErrorMessage = "La fecha de nacimiento no puede ser superior a la actual")]
        public DateTime? FechaNacimiento { get; set; } = null!;

        [Required(ErrorMessage = "El sexo del paciente es requerido")]
        public string? SexoPaciente { get; set; } = null!;

        [Required(ErrorMessage = "La edad del paciente es requerida")]
        public int? EdadPaciente { get; set; } = null!;

        public string? IdentificacionPaciente { get; set; }

        [Required(ErrorMessage = "La nacionalidad del paciente es requerida")]
        public string? NacionalidadPaciente { get; set; } = null!;
        public string? TelefonoPaciente { get; set; }

        [Required(ErrorMessage = "El tipo sanguineo del paciente es requerido")]
        public string? TipoSanguineo { get; set; } = null!;
        public string? SeguroMedico { get; set; } 
        public string? HistorialMedico { get; set; }
    }
}
