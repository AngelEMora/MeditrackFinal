using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class MaterialesQuirurgico
    {
        public MaterialesQuirurgico()
        {
            KitMaterialesDetalles = new HashSet<KitMaterialesDetalle>();
        }

        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int? CantidadDisponibleMaterialQuirurgico { get; set; }
        public int? IdTipoMaterialQuirurgico { get; set; }
        public int? IdMovimiento { get; set; }

        public virtual MovimientoInventario? IdMovimientoNavigation { get; set; }
        public virtual TipodeMaterialQuirurgico? IdTipoMaterialQuirurgicoNavigation { get; set; }
        public virtual ICollection<KitMaterialesDetalle> KitMaterialesDetalles { get; set; }
    }
}
