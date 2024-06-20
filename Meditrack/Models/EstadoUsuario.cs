using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class EstadoUsuario
    {
        public EstadoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdEstadoUsuario { get; set; }
        public string NombreEstadoUsuario { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
