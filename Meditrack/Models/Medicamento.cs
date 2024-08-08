using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class Medicamento
    {
        public Medicamento()
        {
            KitMedicamentoDetalles = new HashSet<KitMedicamentoDetalle>();
        }

        public int IdMedicamento { get; set; }
        public string NombreMedicamento { get; set; } = null!;
        public int? IdTipoMedicamento { get; set; }
        public int? CantidadDisponibleMedicamentos { get; set; }
        public int? IdMovimiento { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string? Distribuidor { get; set; }
        public int? PuntosReorden { get; set; }
        public string Lote { get; set; } = null!;
        public DateTime? FechaFabricacion { get; set; }

        public virtual MovimientoInventario? IdMovimientoNavigation { get; set; }
        public virtual TiposdeMedicamento? IdTipoMedicamentoNavigation { get; set; }
        public virtual ICollection<KitMedicamentoDetalle> KitMedicamentoDetalles { get; set; }
    }
}
