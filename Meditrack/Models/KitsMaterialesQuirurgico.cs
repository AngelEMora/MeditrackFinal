using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class KitsMaterialesQuirurgico
    {
        public KitsMaterialesQuirurgico()
        {
            InventarioMaterialesCirugia = new HashSet<InventarioMaterialesCirugium>();
            KitMaterialesDetalles = new HashSet<KitMaterialesDetalle>();
        }

        public int IdKitsCirugias { get; set; }
        public string NombreKit { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int? CantidadKits { get; set; }

        public virtual ICollection<InventarioMaterialesCirugium> InventarioMaterialesCirugia { get; set; }
        public virtual ICollection<KitMaterialesDetalle> KitMaterialesDetalles { get; set; }
    }
}
