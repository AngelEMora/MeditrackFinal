using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class MovimientoInventario
    {
        public MovimientoInventario()
        {
            MaterialesQuirurgicos = new HashSet<MaterialesQuirurgico>();
            Medicamentos = new HashSet<Medicamento>();
        }

        public int IdMovimiento { get; set; }
        public string? NombreMovimiento { get; set; }

        public virtual ICollection<MaterialesQuirurgico> MaterialesQuirurgicos { get; set; }
        public virtual ICollection<Medicamento> Medicamentos { get; set; }
    }
}
