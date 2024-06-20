using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class Medicamento
    {
        public string NombreMedicamento { get; set; } = null!;
        public string? TipoMedicamento { get; set; }
        public int? CantidadDisponibleMedicamentos { get; set; }
        public int? Movimiento { get; set; }
        public int? CantidadDisponible { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string? Distribuidor { get; set; }
        public int? PuntosReorden { get; set; }
        public int IdMedicamento { get; set; }
    }
}
