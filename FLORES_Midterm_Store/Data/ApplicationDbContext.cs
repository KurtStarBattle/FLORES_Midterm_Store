using Microsoft.EntityFrameworkCore;
using FLORES_Midterm_Store.Models;

namespace FLORES_Midterm_Store.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> Items { get; set; }
    }
}