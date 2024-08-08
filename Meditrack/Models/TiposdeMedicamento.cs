using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class TiposdeMedicamento
    {
        public TiposdeMedicamento()
        {
            Medicamentos = new HashSet<Medicamento>();
        }

        public int IdTipoMedicamento { get; set; }
        public string? NombreTipoMedicamento { get; set; }
        public string? DescripcionTipoMedicamento { get; set; }
        public string? Restricciones { get; set; }

        public virtual ICollection<Medicamento> Medicamentos { get; set; }
    }
}
