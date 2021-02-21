using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Models
{
    // Create the book context
    public class BookAppDbContext : DbContext
    {
        public BookAppDbContext (DbContextOptions<BookAppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
