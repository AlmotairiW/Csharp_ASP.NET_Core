using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsCategories.Models
{
    public class Product
    {
        [Key] 
        public int ProductId {set;get;}

        [Required]
        public string Name {set;get;}
        
        [Required]
        public string Description {set;get;}

        [Required]
        [Range(0,double.MaxValue, ErrorMessage = "Price Must be > 0")]
        public double Price {set;get;}

        public DateTime CreatedAt{set;get;} = DateTime.Now;
        public DateTime UpdateddAt{set;get;} = DateTime.Now;

        public List<Association> AllCategories {set;get;}
        
    }
}