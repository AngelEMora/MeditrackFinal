using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class KitsMedicamento
    {
        public KitsMedicamento()
        {
            InventarioMedicamentosCirugia = new HashSet<InventarioMedicamentosCirugium>();
            KitMedicamentoDetalles = new HashSet<KitMedicamentoDetalle>();
        }

        public int IdKitsMedicamentos { get; set; }
        public string NombreKit { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int? CantidadKits { get; set; }

        public virtual ICollection<InventarioMedicamentosCirugium> InventarioMedicamentosCirugia { get; set; }
        public virtual ICollection<KitMedicamentoDetalle> KitMedicamentoDetalles { get; set; }
    }
}
