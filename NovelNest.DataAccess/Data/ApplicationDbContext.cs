using NovelNest.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace NovelNest.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Anna", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Leo", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Shirley", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
              new Product { Id = 2, Title = "ABS", Author = "Ron", Description = "new book", ISBN = "102300", ListPrice = 30, Price = 27, Price50 = 25, Price100 = 20,CategoryId=5,ImageURL=""},
              new Product { Id = 3, Title = "CDS", Author = "Willam", Description = "one book", ISBN = "145300", ListPrice = 30, Price = 27, Price50 = 25, Price100 = 20,CategoryId=3,ImageURL="" }
 );
        }
    }
}
