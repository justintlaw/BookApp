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
