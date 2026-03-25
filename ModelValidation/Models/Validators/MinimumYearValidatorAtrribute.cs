using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models.Validators
{
    public class MinimumYearValidatorAtrribute () : ValidationAttribute
    {
        public int MinimumYear { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if( value != null)
            {
                DateTime date = (DateTime) value;
                if (date.Year < 1900)
                {
                    return new ValidationResult("Year must be greater than or equal to 1900.");
                }
                return ValidationResult.Success;
            }

            return ValidationResult.Success;
        }
    }
}
