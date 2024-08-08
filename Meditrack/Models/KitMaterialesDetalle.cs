using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class KitMaterialesDetalle
    {
        public int KitDetalleId { get; set; }
        public int IdMaterial { get; set; }
        public int IdKitsCirugias { get; set; }
        public string? Notas { get; set; }
        public int Cantidad { get; set; }

        public virtual KitsMaterialesQuirurgico IdKitsCirugiasNavigation { get; set; } = null!;
        public virtual MaterialesQuirurgico IdMaterialNavigation { get; set; } = null!;
    }
}
