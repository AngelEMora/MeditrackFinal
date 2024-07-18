using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Meditrack.Validation
{
    public class ValidacionFechaNacimiento : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime <= DateTime.Now;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"La fecha de {name} no puede ser posterior a la fecha actual.";
        }

    }
}
