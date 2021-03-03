using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            // set up the context
            BookAppDbContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<BookAppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            // add books to database if none exist
            if (!context.Books.Any())
            {
                context.AddRange(
                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95M,
                        NumberOfPages = 1488
                    },
                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorMiddleInitial = "K",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58M,
                        NumberOfPages = 944
                    },
                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54M,
                        NumberOfPages = 832
                    },
                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald",
                        AuthorMiddleInitial = "C",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61M,
                        NumberOfPages = 864
                    },
                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33M,
                        NumberOfPages = 528
                    },
                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95M,
                        NumberOfPages = 288
                    },
                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-help",
                        Price = 14.99M,
                        NumberOfPages = 304
                    },
                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-help",
                        Price = 21.66M,
                        NumberOfPages = 240
                    },
                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorLastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16M,
                        NumberOfPages = 400
                    },
                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03M,
                        NumberOfPages = 642
                    },
                    new Book
                    {
                        Title = "1984",
                        AuthorFirstName = "George",
                        AuthorLastName = "Orwell",
                        Publisher = "Books Inc.",
                        ISBN = "675-2195468123",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 19.99M,
                        NumberOfPages = 344
                    },
                    new Book
                    {
                        Title = "Animal Farm",
                        AuthorFirstName = "George",
                        AuthorLastName = "Orwell",
                        Publisher = "Books Inc.",
                        ISBN = "195-2125438123",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 19.99M,
                        NumberOfPages = 343
                    },
                    new Book
                    {
                        Title = "Communist Manifesto",
                        AuthorFirstName = "Karl",
                        AuthorLastName = "Marx",
                        Publisher = "Commie Publishing",
                        ISBN = "975-2195368123",
                        Classification = "Fiction",
                        Category = "Garbage",
                        Price = 25.49M,
                        NumberOfPages = 53
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
