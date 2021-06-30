using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        [Required]
        public int DishId{get;set;}

        [Required]
        [Display( Name = "Name of Dish")]
        public string Name {set;get;}
        [Required]
        [Display( Name = "Chef's Name")]
        public string Chef {get;set;}
        [Required]
        [Range(1,5)]
        public int Tastines {get;set;}
        [Required]
        [Display( Name = "# of Calories")]
        [Range(1, int.MaxValue , ErrorMessage = "Calories must be > 0")]
        public int Calories {get; set;}
        [Required]
        public string Description{set;get;}
        public DateTime CreatedAt{set;get;} = DateTime.Now;
        public DateTime UpdateddAt{set;get;} = DateTime.Now;


    }
}