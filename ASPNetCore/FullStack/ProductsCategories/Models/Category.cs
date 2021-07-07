using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {set;get;}

        [Required]
        public string Name {set;get;}
        
        public DateTime CreatedAt{set;get;} = DateTime.Now;
        public DateTime UpdateddAt{set;get;} = DateTime.Now;

        public List<Association> AllProducts {set;get;}
    }
}