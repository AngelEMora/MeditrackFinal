using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class EstadoQuirofano
    {
        public EstadoQuirofano()
        {
            Quirofanos = new HashSet<Quirofano>();
        }

        public int IdEstado { get; set; }
        public string DescripcionEstado { get; set; } = null!;
        public DateTime? FechaCreacion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Quirofano> Quirofanos { get; set; }
    }
}
