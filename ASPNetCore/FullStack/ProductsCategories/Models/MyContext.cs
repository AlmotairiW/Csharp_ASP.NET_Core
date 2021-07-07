using Microsoft.EntityFrameworkCore;

namespace ProductsCategories.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}

        public DbSet<Product> Products {set;get;}
        public DbSet<Category> Categories {set;get;}
        public DbSet<Association> Associations {set;get;}
    }
}