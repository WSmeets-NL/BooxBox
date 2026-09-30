using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BooxBox.Models;

namespace BooxBox.Data
{
    internal class BooxBoxDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Bookcase> Bookcases { get; set; }
        public DbSet<BookCollection> BookCollections {  get; set; }

        public BooxBoxDbContext(DbContextOptions<BooxBoxDbContext> options)
            : base(options)
        {

        }
    }
}
