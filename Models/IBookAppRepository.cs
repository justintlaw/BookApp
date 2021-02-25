using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Models
{
    // Make the book repository queryable
    public interface IBookAppRepository
    {
        IQueryable<Book> Books { get; }
    }
}
