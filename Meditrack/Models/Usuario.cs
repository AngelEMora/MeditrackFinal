using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contrasena { get; set; }
        public string? NombreCompleto { get; set; }
        public int? RolId { get; set; }
        public DateTime? FechaDeRegistro { get; set; }
        public int? IdEstadoUsuario { get; set; }
        public string? NombreRol { get; set; }

        public virtual EstadoUsuario? IdEstadoUsuarioNavigation { get; set; }
        public virtual Role? NombreRolNavigation { get; set; }
        public virtual Role? Rol { get; set; }
    }
}
