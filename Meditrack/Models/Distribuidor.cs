using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class Distribuidor
    {
        public int IdDistribuidor { get; set; }
        public string? NombreDistribuidor { get; set; }
        public string? DireccionDistribuidor { get; set; }
        public string? TelefonoDistribuidor { get; set; }
        public string? Correo { get; set; }
        public string? TipoDistribuidor { get; set; }
        public int? IdCasaComercial { get; set; }

        public virtual CasaComercial? IdCasaComercialNavigation { get; set; }
    }
}
