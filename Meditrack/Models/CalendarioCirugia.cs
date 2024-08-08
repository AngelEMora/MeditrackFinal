using System;
using System.Collections.Generic;

namespace Meditrack.Models
{
    public partial class CalendarioCirugia
    {
        public CalendarioCirugia()
        {
            InventarioMaterialesCirugia = new HashSet<InventarioMaterialesCirugium>();
            InventarioMedicamentosCirugia = new HashSet<InventarioMedicamentosCirugium>();
        }

        public int IdCirugia { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdProcedimiento { get; set; }
        public int? IdDoctor { get; set; }
        public int? IdQuirofano { get; set; }
        public DateTime? FechaHoraCirugia { get; set; }
        public int? IdEstadoCirugias { get; set; }
        public string? Observaciones { get; set; }

        public virtual Doctore? IdDoctorNavigation { get; set; }
        public virtual EstadosCirugia? IdEstadoCirugiasNavigation { get; set; }
        public virtual Paciente? IdPacienteNavigation { get; set; }
        public virtual ProcedimientosQuirurgico? IdProcedimientoNavigation { get; set; }
        public virtual Quirofano? IdQuirofanoNavigation { get; set; }
        public virtual ICollection<InventarioMaterialesCirugium> InventarioMaterialesCirugia { get; set; }
        public virtual ICollection<InventarioMedicamentosCirugium> InventarioMedicamentosCirugia { get; set; }
    }
}
