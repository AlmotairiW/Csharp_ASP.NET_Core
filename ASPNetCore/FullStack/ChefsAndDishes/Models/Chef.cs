using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChefsAndDishes.Validatitors;

namespace ChefsAndDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {set;get;}

        [Required]
        [Display(Name = "First Name")]
        public string FirstName {set;get;}

        [Required]
        [Display(Name = "Last Name")]
        public string LastName {set;get;}

        [Required]
        [DateValiditor]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB {set; get;}

        public DateTime CreatedAt{set;get;} = DateTime.Now;
        public DateTime UpdateddAt{set;get;} = DateTime.Now;

        // Navigation property
        public List<Dish> DishesMade {set;get;}

        
        
    }
}