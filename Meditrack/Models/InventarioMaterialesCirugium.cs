using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class InventarioMaterialesCirugium
    {
        public int IdInventario { get; set; }
        public int? IdCirugia { get; set; }
        public int? CantidadUtilizadaMaterialCirugia { get; set; }
        public int? IdKitsCirugias { get; set; }

        public virtual CalendarioCirugia? IdCirugiaNavigation { get; set; }
        public virtual KitsMaterialesQuirurgico? IdKitsCirugiasNavigation { get; set; }
    }
}
