using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class OcupacionMedica
    {
        public OcupacionMedica()
        {
            Doctores = new HashSet<Doctore>();
        }

        public int IdOcupacion { get; set; }
        public string NombreOcupacion { get; set; } = null!;
        public string? DescripcionOcupacion { get; set; }

        public virtual ICollection<Doctore> Doctores { get; set; }
    }
}
