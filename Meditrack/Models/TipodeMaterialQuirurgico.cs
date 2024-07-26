using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class TipodeMaterialQuirurgico
    {
        public TipodeMaterialQuirurgico()
        {
            MaterialesQuirurgicos = new HashSet<MaterialesQuirurgico>();
        }

        public int IdTipoMaterialQuirurgico { get; set; }
        public string? NombreTipoMaterialQuirurgico { get; set; }
        public string? DescripcionTipoMaterialQuirurgico { get; set; }
        public int? EstadoMaterial { get; set; }

        public virtual EstadosdelosMaterialesQuirurgico? EstadoMaterialNavigation { get; set; }
        public virtual ICollection<MaterialesQuirurgico> MaterialesQuirurgicos { get; set; }
    }
}
