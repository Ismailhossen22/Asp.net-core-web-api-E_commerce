using Bigbasket_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Bigbasket_Ecommerce.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options  ):base(options)
        {
            
        }


        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get;set;}
        public DbSet<Role> Role { get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           
            modelBuilder.Entity<Products>().HasKey("ProductId");
            modelBuilder.Entity<Category>().HasKey("CategoryId");
            modelBuilder.Entity<Category>().Property(e => e.CategoryId).UseIdentityColumn(seed: 101,increment: 1);

           


        }







    }
}
