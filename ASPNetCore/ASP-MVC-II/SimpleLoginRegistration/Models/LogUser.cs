using System.ComponentModel.DataAnnotations;

namespace SimpleLoginRegistration.Models
{
    public class LogUser 
    {
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string LogingEmail {set;get;}

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string LogingPassword {set;get;}
    }
}