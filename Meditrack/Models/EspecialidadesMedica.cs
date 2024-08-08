using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class EspecialidadesMedica
    {
        public EspecialidadesMedica()
        {
            Doctores = new HashSet<Doctore>();
        }

        public int IdEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; } = null!;

        public virtual ICollection<Doctore> Doctores { get; set; }
    }
}
