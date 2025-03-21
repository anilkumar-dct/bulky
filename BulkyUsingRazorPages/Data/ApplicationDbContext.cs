using BulkyUsingRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyUsingRazorPages.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) // Passes database configuration options to the DbContext base class
        {
            // Constructor for ApplicationDbContext
            // options contain database settings like connection string and provider
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Anil",
                    DisplayOrder = 1,
                }
                );
        }
    }
}
