using Microsoft.EntityFrameworkCore;
using AuthSystem.Models;
namespace AuthSystem.Data
{
    public class AppDbContext : DbContext
    {
       public  DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AuthSystemDb;Trusted_Connection=True;");
        }
    }
}
