using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}

        public DbSet<User> Users {set;get;}
        public DbSet<Transaction> Transactions {set;get;}
    }
}