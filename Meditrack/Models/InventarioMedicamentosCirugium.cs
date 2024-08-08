using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class InventarioMedicamentosCirugium
    {
        public int IdInventarioMedicamento { get; set; }
        public int? IdCirugia { get; set; }
        public int? CantidadUtilizadaMedicamentoCirugia { get; set; }
        public int? IdKitsMedicamentos { get; set; }

        public virtual CalendarioCirugia? IdCirugiaNavigation { get; set; }
        public virtual KitsMedicamento? IdKitsMedicamentosNavigation { get; set; }
    }
}
