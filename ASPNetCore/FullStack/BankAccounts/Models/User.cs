using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccounts.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "First Name must be at least 2 characters long!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters long!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        [Compare("Password", ErrorMessage = "Passwords does not match!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string Confirm { get; set; }

        // Navigation property
        public List<Transaction> TransactionsMade {set;get;}
        
    }
}