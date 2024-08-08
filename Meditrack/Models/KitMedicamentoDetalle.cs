using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class KitMedicamentoDetalle
    {
        public int KitMedicamentoId { get; set; }
        public int IdMedicamento { get; set; }
        public int IdKitsMedicamento { get; set; }
        public string? NotasMedicMedicamento { get; set; }
        public int CantidadMedicamento { get; set; }

        public virtual KitsMedicamento IdKitsMedicamentoNavigation { get; set; } = null!;
        public virtual Medicamento IdMedicamentoNavigation { get; set; } = null!;
    }
}
