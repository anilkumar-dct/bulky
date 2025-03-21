using Bulky.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options) // Passes database configuration options to the DbContext base class
        {
            // Constructor for ApplicationDbContext
            // options contain database settings like connection string and provider
        }
        public DbSet<Category>   categories { get; set; }//this single line is used to create table using entity framework.

        //below built in method used for adding data into our database 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data into the Category table when the database is created or updated.
            // This ensures that the database always has some initial values.

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,          // Unique ID for the category
                    Name = "Anil",   // Name of the category
                    DisplayOrder = 1 // Order in which it should be displayed
                },
                new Category
                {
                    Id = 2,
                    Name = "Rahul",
                    DisplayOrder = 2
                },
                new Category
                {
                    Id = 3,
                    Name = "Vijay",
                    DisplayOrder = 3
                }
            );

            // NOTE:
            // - This method is used in Entity Framework Core to configure the database schema.
            // - The HasData() method is specifically for seeding data into the database.
            // - The data added here is inserted only **if the database is newly created**.
            // - If you change seeded data later, you must create and apply a **new migration** for changes to reflect.

            // Example command to add a migration for seeded data:
            // dotnet ef migrations add SeedCategoryData

            // Example command to apply migration:
            // dotnet ef database update
        }

    }
}
