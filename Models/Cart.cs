using BookApp.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Models
{
    public class Cart
    {
        // A list for each line in the cart
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Book b, int qty)
        {
            CartLine line = Lines
                .Where(item => item.Book.BookId == b.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = b,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Book b) =>
            Lines.RemoveAll(item => item.Book.BookId == b.BookId);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => Lines.Sum(item => item.Book.Price * item.Quantity);

        // Line item information
        public class CartLine
        {
            public int CartLineId { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
