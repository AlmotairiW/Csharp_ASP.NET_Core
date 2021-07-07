using System;
using System.ComponentModel.DataAnnotations;

namespace DateValidator.Validatitors
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(((DateTime)value) < DateTime.Now)
                return new ValidationResult("Date Entered Must be in the Future");
            return ValidationResult.Success;
        }
    }


}