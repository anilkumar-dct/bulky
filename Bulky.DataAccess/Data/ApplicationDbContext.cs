using Bulky.Models;
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

        public DbSet<Products> products { get; set; }
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

            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    imageUrl=""
                },
                new Products
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1,
                    imageUrl = ""
                },
                new Products
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 1,
                    imageUrl = ""

                },
                new Products
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 2,
                    imageUrl = ""
                },
                new Products
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 2,
                    imageUrl = ""
                },
                new Products
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 3,
                    imageUrl = ""
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
