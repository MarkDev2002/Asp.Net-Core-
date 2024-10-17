using Microsoft.EntityFrameworkCore;
namespace EntityDemo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<BookCatalogue> BookCatalogues { get; set; }
        public DbSet<BookImages> BookImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Fiction", IsActive = true },
                new Genre { Id = 2, Name = "Non-Fiction", IsActive = true },
                new Genre { Id = 3, Name = "Science Fiction", IsActive = true },
                new Genre { Id = 4, Name = "Biography", IsActive = true }
            );

            // Seed data for Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Code = "B001",
                    Title = "The Great Gatsby",
                    Available = 10,
                    Cost = 10.99m,
                    Publisher = "Scribner",
                    Author = "F. Scott Fitzgerald",
                    CreatedOn = DateTime.Now,
                    GenreId = 1,
                    IsActive = true,
                    Description = "A novel about the American dream."
                },
                new Book
                {
                    Id = 2,
                    Code = "B002",
                    Title = "Becoming",
                    Available = 5,
                    Cost = 12.99m,
                    Publisher = "Crown Publishing Group",
                    Author = "Michelle Obama",
                    CreatedOn = DateTime.Now,
                    GenreId = 4,
                    IsActive = true,
                    Description = "A memoir by the former First Lady of the United States."
                }
            );

            // Seed data for BookImages
            modelBuilder.Entity<BookImages>().HasData(
                new BookImages { Id = 1, Name = "great_gatsby.jpg", BookId = 1 },
                new BookImages { Id = 2, Name = "becoming.jpg", BookId = 2 }
            );
        }
    }

}

