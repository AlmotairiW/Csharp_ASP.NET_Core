using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.Validatitors
{
    public class DateValiditorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (((DateTime)value) > DateTime.Now)
                return new ValidationResult("Date Entered Must be in the past");
            
            if (((DateTime)value).AddYears(18) > DateTime.Now)
                return new ValidationResult("Chef must be at least 18 years old");
            
            return ValidationResult.Success;
        }
    }
}