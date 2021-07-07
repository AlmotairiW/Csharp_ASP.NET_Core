using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}

        public DbSet<User> Users {set;get;}
        public DbSet<Wedding> Weddings {set;get;}
        public DbSet<UserWedding> UserWeddings {set;get;}
    }
}