using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Meditrack.Validation;

namespace Meditrack.Models
{
    public partial class Doctore
    {
        public int IdDoctor { get; set; }

        [Required(ErrorMessage = "El nombre del doctor es requerido")]
        public string NombreDoctor { get; set; } = null!;

        [Required(ErrorMessage = "El telefono del doctor es requerido")]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "El formato del número de teléfono es incorrecto. Debe ser (xxx) xxx-xxxx")]
        public string? TelefonoDoctor { get; set; }
        public int? EdadDoctor { get; set; }

        [Required(ErrorMessage = "La nacionalidad del doctor es requerida")]
        public string? NacionalidadDoctor { get; set; }

        [Required(ErrorMessage = "La identificacion del doctor es requerida")]
        public string IdentificacionDoctor { get; set; } = null!;

        [Required(ErrorMessage = "El sexo del doctor es requerido")]
        public string? SexoDoctor { get; set; }

        [Required(ErrorMessage = "La especialidad del doctor es requerida")]
        public string Especialidad { get; set; } = null!;

        [ValidacionFechaNacimiento(ErrorMessage = "La fecha de nacimiento no puede ser superior a la actual")]
        [Required(ErrorMessage = "La fecha de nacimiento del doctor es requerida")]
        public DateTime? FechaNacimiento { get; set; }
    }
}
