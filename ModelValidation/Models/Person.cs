using ModelValidation.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class Person : IValidatableObject
    {
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public int? Age { get; set; }
        public double? Price { get; set; }
        [MinimumYearValidatorAtrribute(MinimumYear = 1900)]
        public DateTime? BirthDate { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Phone: {Phone}, Password: {Password}, ConfirmPassword: {ConfirmPassword}, Price: {Price}, BirthDate: {BirthDate}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
             if(Password != ConfirmPassword)
            {
                validationResults.Add(new ValidationResult("Password and Confirm Password must match.", new[] { nameof(Password), nameof(ConfirmPassword) }));
            }
            if (BirthDate.HasValue == false && Age.HasValue == false)
            {
                validationResults.Add(new ValidationResult("Either BirthDate or Age must be provided.", new[] { nameof(BirthDate), nameof(Age) }));
            }
            return validationResults;
        }
    }
}
