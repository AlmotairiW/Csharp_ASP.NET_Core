using System.ComponentModel.DataAnnotations;

namespace ProductsCategories.Models
{
    public class Association
    {
        [Key]
        public int AssociationId {set;get;}

        public int ProductId {set;get;}
        public int CategoryId {set;get;}

        public Product ProductOnCategory {set;get;}
        public Category CategoryOfProduct {set;get;}
    }
}