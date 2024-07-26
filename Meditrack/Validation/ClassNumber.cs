using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Meditrack.Validation
{
    public class ClassNumber : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                if (stringValue.Any(char.IsDigit))
                {
                    return new ValidationResult("Este campo no puede contener números.");
                }
            }
            return ValidationResult.Success;
        }

    }
}
