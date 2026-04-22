using BookstoreProjectData;
using BookstoreProjectData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BookstoreWebApp.Seed
{
   
        public class EntitySeeder
        {
            public static async Task SeedAsync(BookstoreContext context)
            {
                await SeedGenres(context);
                await SeedAuthors(context);
                await SeedPublishers(context);
                await SeedBooks(context);
                await SeedPublisherBooks(context);
                await SeedEvents(context);
            }

            // ---------------- GENRES ----------------
            private static async Task SeedGenres(BookstoreContext context)
            {
                var genres = new List<Genre>
            {
                new Genre { Name = "Children's", Description = "Literary works created for children." },
                new Genre { Name = "Historical", Description = "bla" },
                new Genre { Name = "Comedy", Description = "funny stuff" },
                new Genre { Name = "Classic", Description = "classics" },
                new Genre { Name = "Fantasy", Description = "magic" },
                new Genre { Name = "Thriller", Description = "suspense" },
                new Genre { Name = "Romance", Description = "love stories" }
            };

                foreach (var g in genres)
                {
                    if (!await context.Genres.AnyAsync(x => x.Name == g.Name))
                    {
                        g.Id = Guid.NewGuid();
                        await context.Genres.AddAsync(g);
                    }
                }

                await context.SaveChangesAsync();
            }

            private static async Task SeedAuthors(BookstoreContext context)
            {
                var authors = new List<Author>
            {
                new Author { FullName = "Lewis Carroll", Nationality = "British", Biography="dnoiuhe", ImageUrl="dieuy5" },
                new Author { FullName = "George Orwell", Nationality = "British", Biography= "dnoiuhe", ImageUrl= "dieuy5" },
                new Author { FullName = "E.B. White", Nationality = "American", Biography = "dnoiuhe", ImageUrl = "dieuy5" },
                new Author { FullName = "Markus Zusak", Nationality = "Australian", Biography = "dnoiuhe" , ImageUrl = "dieuy5"},
                new Author { FullName = "Anthony Doerr", Nationality = "American" , Biography = "dnoiuhe", ImageUrl = "dieuy5"},
                new Author { FullName = "Terry Pratchett", Nationality = "British" , Biography = "dnoiuhe", ImageUrl = "dieuy5"},
                new Author { FullName = "Douglas Adams", Nationality = "British" , Biography = "dnoiuhe", ImageUrl = "dieuy5"},
                new Author { FullName = "Jane Austen", Nationality = "British" , Biography = "dnoiuhe", ImageUrl = "dieuy5"},
                new Author { FullName = "J. R. R. Tolkien", Nationality = "British" , Biography = "dnoiuhe", ImageUrl = "dieuy5"},
                new Author { FullName = "George R. R. Martin", Nationality = "American" , Biography = "dnoiuhe", ImageUrl = "dieuy5"},
                new Author { FullName = "Dan Brown", Nationality = "American" , Biography = "dnoiuhe", ImageUrl = "dieuy5"},
                new Author { FullName = "Gillian Flynn", Nationality = "American" , Biography = "dnoiuhe", ImageUrl = "dieuy5"},
                new Author { FullName = "Jojo Moyes", Nationality = "British" , Biography = "dnoiuhe", ImageUrl = "dieuy5"},
                new Author { FullName = "Nicholas Sparks", Nationality = "American" , Biography = "dnoiuhe", ImageUrl = "dieuy5"}
            };

                foreach (var a in authors)
                {
                    if (!await context.Authors.AnyAsync(x => x.FullName == a.FullName))
                    {
                        a.Id = Guid.NewGuid();
                        await context.Authors.AddAsync(a);
                    }
                }

                await context.SaveChangesAsync();
            }

            private static async Task SeedPublishers(BookstoreContext context)
            {
                var publishers = new List<Publisher>
            {
                new Publisher { Name = "Bloomsbury Publishing" },
                new Publisher { Name = "Harper & Brothers" },
                new Publisher { Name = "Workman Publishing" },
                new Publisher { Name = "Bantam Books" }
            };

                foreach (var p in publishers)
                {
                    if (!await context.Publishers.AnyAsync(x => x.Name == p.Name))
                    {
                        p.Id = Guid.NewGuid();
                        await context.Publishers.AddAsync(p);
                    }
                }

                await context.SaveChangesAsync();
            }

            private static async Task SeedBooks(BookstoreContext context)
            {
                var lewis = await context.Authors.FirstOrDefaultAsync(a => a.FullName == "Lewis Carroll");
                var ebwhite = await context.Authors.FirstOrDefaultAsync(a => a.FullName == "E.B. White");
                var zusak = await context.Authors.FirstOrDefaultAsync(a => a.FullName == "Markus Zusak");
                var terry = await context.Authors.FirstOrDefaultAsync(a => a.FullName == "Terry Pratchett");
                var orwell = await context.Authors.FirstOrDefaultAsync(a => a.FullName == "George Orwell");

                var children = await context.Genres.FirstOrDefaultAsync(g => g.Name == "Children's");
                var historical = await context.Genres.FirstOrDefaultAsync(g => g.Name == "Historical");
                var comedy = await context.Genres.FirstOrDefaultAsync(g => g.Name == "Comedy");
                var classic = await context.Genres.FirstOrDefaultAsync(g => g.Name == "Classic");

                if (lewis == null || ebwhite == null || children == null || zusak == null || historical == null || comedy == null || terry == null || orwell == null || classic == null)
                    throw new Exception("Missing required seed data (Authors/Genres)");

                if (!await context.Books.AnyAsync(b => b.Title == "Alice's Adventures in Wonderland"))
                {
                    await context.Books.AddAsync(new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "Charlotte's Web",
                        Price = 20,
                        AuthorId = lewis.Id,
                        GenreId = children.Id
                    });
                    await context.Books.AddAsync(new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "Alice's Adventures in Wonderland",
                        Price = 19,
                        AuthorId = ebwhite.Id,
                        GenreId = children.Id
                    });
                    await context.Books.AddAsync(new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Book Thief",
                        Price = 21,
                        AuthorId = zusak.Id,
                        GenreId = historical.Id
                    });
                    await context.Books.AddAsync(new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "Good Omens",
                        Price = 23,
                        AuthorId = terry.Id,
                        GenreId = comedy.Id
                    });
                    await context.Books.AddAsync(new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "1984",
                        Price = 19,
                        AuthorId = orwell.Id,
                        GenreId = classic.Id
                    });
            }

                await context.SaveChangesAsync();
            }

            private static async Task SeedPublisherBooks(BookstoreContext context)
            {
                var publisher = await context.Publishers
                    .FirstOrDefaultAsync(p => p.Name == "Bloomsbury Publishing");

                var book = await context.Books
                    .FirstOrDefaultAsync(b => b.Title == "Alice's Adventures in Wonderland");

                if (publisher == null || book == null)
                    return;

                if (!await context.Publishers_Books
                    .AnyAsync(x => x.BookId == book.Id && x.PublisherId == publisher.Id))
                {
                    await context.Publishers_Books.AddAsync(new Publisher_Book
                    {
                        PublisherId = publisher.Id,
                        BookId = book.Id,
                        Language = "English"
                    });

                    await context.SaveChangesAsync();
                }
            }

            private static async Task SeedEvents(BookstoreContext context)
            {
                var author = await context.Authors
                    .FirstOrDefaultAsync(a => a.FullName == "Dan Brown");

                if (author == null) return;

                if (!await context.Events.AnyAsync(e => e.Name.Contains("Dan Brown")))
                {
                    await context.Events.AddAsync(new Event
                    {
                        Id = Guid.NewGuid(),
                        Name = "Meet and Greet with Dan Brown",
                        DateAndTime = DateTime.UtcNow,
                        AuthorId = author.Id,
                        Link="https"
                    });

                    await context.SaveChangesAsync();
                }
            }
        }
    
}

