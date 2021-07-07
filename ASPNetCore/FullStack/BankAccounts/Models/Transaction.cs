using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId {set;get;}

        [Required]
        [Display(Name = "Deposit/Withdraw:")]
        public double Amount {set;get;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserId {set;get;}

        // Navigation property
        public User MadeBy {get;set;}


    }
}