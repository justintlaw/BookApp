using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Models
{
    // create a repository to store the data
    public class EFBookAppRepository : IBookAppRepository
    {
        private BookAppDbContext _context;

        public EFBookAppRepository (BookAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
