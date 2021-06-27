using System.ComponentModel.DataAnnotations;

namespace SimpleLoginRegistration.Models
{
    public class RegUser
    {
        [Required]
        [Display(Name = "First Name")]
        [MinLength(2)]
        public string FirstName {set;get;}

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2)]
        public string LastName {set;get;}

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email {set;get;}

        [Required]
        [MinLength(8,  ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]

        public string Password {set;get;}

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConPassword {set;get;}

    }
}