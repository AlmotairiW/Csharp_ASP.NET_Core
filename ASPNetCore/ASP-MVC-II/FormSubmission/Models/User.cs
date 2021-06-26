using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4, ErrorMessage = "First Name must be at least 4 characters long")]
        [Display( Name = "First Name")]
        public string FirstName {set; get;}

        [Required]
        [MinLength(4, ErrorMessage = "Last Name must be at least 4 characters long")]
        [Display( Name = "Last Name")]
        public string LastName {set; get;}

        [Required]
        [Range(1, int.MaxValue , ErrorMessage = "Only positive number allowed")]
        public int Age {set; get;}

        [Required]
        [EmailAddress]
        // [DataType(DataType.EmailAddress)]
        [Display( Name = "Email Address")]
        public string Email {set; get; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password{set; get;}

    }
}