using BooxBox.Models;
using Microsoft.EntityFrameworkCore;

namespace BooxBox.Data
{
    public class BooxBoxDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Bookcase> Bookcases { get; set; }
        public DbSet<BookCollection> BookCollections {  get; set; }

        public BooxBoxDbContext(DbContextOptions<BooxBoxDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(c => c.InBookcase)
                .WithMany(b => b.ContainedBooks)
                .HasForeignKey(c =>c.BookcaseId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.InCollections)
                .WithMany(c => c.BooksInCollection);
        }
    }
}
