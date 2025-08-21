using Bigbasket_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Bigbasket_Ecommerce.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options  ):base(options)
        {
            
        }


       
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get;set;}
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Customers> Customers { get;set;}
        public DbSet<Orders> Orders { get;set;}
        public DbSet<Employees> Employees { get;set;}
        public DbSet<Shippers> Shippers { get;set;}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.HasMany(u => u.RefreshTokens).WithOne(u => u.User)
                .HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.SetNull);
               
            });


            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(u => new { u.UserId, u.RoleId });//compsoit key
                entity.HasOne(u => u.User).WithMany(u => u.UserRole)
                .HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade) ;
                entity.HasOne(r => r.Role).WithMany(u => u.UserRole)
                .HasForeignKey(u => u.RoleId).OnDelete(DeleteBehavior.Cascade);
              
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.HasOne(p => p.Category).WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);
                entity.HasMany(e => e.Orders).WithOne(e => e.Employees)
                .HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Shippers>(entity =>
            {
                entity.HasKey(s => s.ShipperId);
                entity.HasMany(s => s.Orders).WithOne(s => s.Shippers)
                .HasForeignKey(p => p.ShipperId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(c => c.CustomerId);
                entity.HasMany(c => c.Orders).WithOne(c => c.Customers)
                .HasForeignKey(c => c.CustomerId).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Role>().Property(e => e.RoleId).UseIdentityColumn(seed: 101, increment: 1);
            modelBuilder.Entity<Category>().Property(e => e.CategoryId).UseIdentityColumn(seed: 101,increment: 1);
            modelBuilder.Entity<Shippers>().Property(e => e.ShipperId).UseIdentityColumn(seed: 101,increment: 1);
           


            base.OnModelCreating(modelBuilder);
        }







    }
}
