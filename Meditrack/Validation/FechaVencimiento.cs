using System;
using System.ComponentModel.DataAnnotations;


namespace Meditrack.Validation
{
    public class FechaVencimiento: ValidationAttribute
    {
        public FechaVencimiento() {
            ErrorMessage = "La fecha de vencimiento debe ser una fecha futura.";
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            var fechaVencimiento = (DateTime)value;
            return fechaVencimiento >= DateTime.Today;
        }
    }
}
