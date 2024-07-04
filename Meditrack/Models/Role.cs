using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class Role
    {
        public Role()
        {
            UsuarioNombreRolNavigations = new HashSet<Usuario>();
            UsuarioRols = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Usuario> UsuarioNombreRolNavigations { get; set; }
        public virtual ICollection<Usuario> UsuarioRols { get; set; }
    }
}
