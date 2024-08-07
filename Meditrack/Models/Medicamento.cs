using Meditrack.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meditrack.Models
{
    public partial class Medicamento
    {
        [Required(ErrorMessage = "El nombre del medicamento es requerido")]
        public string NombreMedicamento { get; set; } = null!;

        [ClassNumber(ErrorMessage = "El tipo de medicamento no puede contener números")]
        [Required(ErrorMessage = "El tipo de medicamento es requerido")]
        public string? TipoMedicamento { get; set; }

        public int? CantidadDisponibleMedicamentos { get; set; }
        public int? Movimiento { get; set; }

        [Required(ErrorMessage = "La cantidad disponible de medicamentos es requerida")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad disponible de medicamentos debe ser un valor positivo")]
        public int? CantidadDisponible { get; set; }

        [FechaVencimiento]
        [Required(ErrorMessage = "La fecha de vencimiento es requerida")]
        public DateTime? FechaVencimiento { get; set; }

        [Required(ErrorMessage = "El distribuidor es requerido")]
        public string? Distribuidor { get; set; }

        [Required(ErrorMessage = "El punto de reorden es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El punto de reorden debe ser un valor positivo")]
        public int? PuntosReorden { get; set; }
        public int IdMedicamento { get; set; }

        public bool PorDebajoDePuntoReorden
        {
            get
            {
                return CantidadDisponible.HasValue && PuntosReorden.HasValue && CantidadDisponible < PuntosReorden;
            }
        }
    }
}
