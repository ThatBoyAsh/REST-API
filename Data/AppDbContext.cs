using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using REST_API_TEMPLATE.Models;

namespace REST_API_TEMPLATE.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationship between books and authors

            modelBuilder.Entity<Book>().HasOne(a => a.Author).WithMany(b => b.Books);

            new DbInitializer(modelBuilder).Seed();
        }


    }   
}
