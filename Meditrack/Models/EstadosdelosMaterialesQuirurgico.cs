using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class EstadosdelosMaterialesQuirurgico
    {
        public EstadosdelosMaterialesQuirurgico()
        {
            TipodeMaterialQuirurgicos = new HashSet<TipodeMaterialQuirurgico>();
        }

        public int IdEstadoMaterialQuirurico { get; set; }
        public string? NombreEstadoMaterialQuirurgico { get; set; }

        public virtual ICollection<TipodeMaterialQuirurgico> TipodeMaterialQuirurgicos { get; set; }
    }
}
