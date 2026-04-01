using BookstoreProjectData.Configurations;
using BookstoreProjectData.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookstoreProjectData
{
    public class BookstoreContext : IdentityDbContext<User>
    {

        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Book> Orders_Books { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Publisher_Book> Publishers_Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<MonthlyBookSelection> MonthlyBookSelections { get; set; }
        public DbSet<MonthlyBook> MonthlyBooks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderBookConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherBookConfiguration());
            modelBuilder.ApplyConfiguration(new MonthlyBookConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
    
}
