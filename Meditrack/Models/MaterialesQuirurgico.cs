using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class MaterialesQuirurgico
    {
        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int? Movimiento { get; set; }
        public int? CantidadDisponibleMaterialQuirurgico { get; set; }
        public int? IdTipoMaterialQuirurgico { get; set; }

        public virtual TipodeMaterialQuirurgico? IdTipoMaterialQuirurgicoNavigation { get; set; }
    }
}
