using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class Paciente
    {
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; } = null!;

        [ValidacionFechaNacimiento(ErrorMessage = "La fecha de nacimiento no puede ser superior a la actual")]
        public DateTime? FechaNacimiento { get; set; } = null!;

        [Required(ErrorMessage = "El sexo del paciente es requerido")]
        public string? SexoPaciente { get; set; } = null!;

        public int? EdadPaciente { get; set; } = null!;

        [Required(ErrorMessage = "La identificacion es requerida")]
        [RegularExpression(@"^\d{3}-\d{7}-\d{1}$", ErrorMessage = "La identificación debe tener el formato xxx-xxxxxxx-x.")]
        public string? IdentificacionPaciente { get; set; }

        [Required(ErrorMessage = "La nacionalidad del paciente es requerida")]
        public string? NacionalidadPaciente { get; set; } = null!;

        [Required(ErrorMessage = "El telefono del paciente es requerido")]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "El formato del número de teléfono es incorrecto. Debe ser de 10 dígitos.")]
        public string? TelefonoPaciente { get; set; }
        public string? TipoSanguineo { get; set; }
        public string? SeguroMedico { get; set; }
        public string? HistorialMedico { get; set; }
    }
}
