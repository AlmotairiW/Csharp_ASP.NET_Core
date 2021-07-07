using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DateValidator.Validatitors;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {set;get;}
        
        [Required]
        [Display(Name = "Wedder One")]
        public string WedderOne {set;get;}

        [Required]
        [Display(Name = "Wedder Tow")]
        public string WedderTow {set;get;}

        [Required]
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime Date {set;get;}
        
        [Required]
        [Display ( Name = "Wedding Address")]
        public string Address {set;get;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public int UserId { get; set; }
        public User PlannedBy {set;get;}

        public List<UserWedding> AllGuests {set; get;}

    }
}