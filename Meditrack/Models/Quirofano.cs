using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class Quirofano
    {
        public int IdQuirofano { get; set; }
        public string NombreQuirofano { get; set; } = null!;
        public string? Ubicacion { get; set; }
        public int? EstadoQuirofano { get; set; }
        public string? DescripcionEstado { get; set; }
        public string? DescripcionEstadoQuirofano { get; set; }

        public virtual EstadoQuirofano? EstadoQuirofanoNavigation { get; set; }
    }
}
