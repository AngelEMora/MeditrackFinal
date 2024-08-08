using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class CasaComercial
    {
        public CasaComercial()
        {
            Distribuidors = new HashSet<Distribuidor>();
        }

        public int IdCasaComercial { get; set; }
        public string NombreCasaComercial { get; set; } = null!;
        public string? DireccionCasaComercial { get; set; }
        public string? TelefonoCasaComercial { get; set; }
        public string? CorreoCasaComercial { get; set; }
        public string? WebCasaComercial { get; set; }

        public virtual ICollection<Distribuidor> Distribuidors { get; set; }
    }
}
