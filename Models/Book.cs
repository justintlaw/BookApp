using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Models
{
    // Book object
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorFirstName { get; set; }

        [Required]
        public string AuthorLastName { get; set; }

        public string AuthorMiddleInitial { get; set; }

        [Required]
        public string Publisher { get; set; }

        // Only accept valid ISBN numbers
        [Required]
        [RegularExpression(@"^\d{3}[-]\d{10}$")]
        public string ISBN { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int NumberOfPages { get; set; }
    }
}
