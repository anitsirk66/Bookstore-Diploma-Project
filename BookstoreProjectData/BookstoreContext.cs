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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(b => b.Title)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(b => b.Price)
                      .HasPrecision(10, 2);

                entity.HasOne(b => b.Author)
                      .WithMany(a => a.Books)
                      .HasForeignKey(b => b.AuthorId)
                      .OnDelete(DeleteBehavior.Restrict); //cascade

                entity.HasOne(b => b.Genre)
                      .WithMany(g => g.Books)
                      .HasForeignKey(b => b.GenreId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.FullName)
                      .IsRequired()
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(g => g.Id);

                entity.Property(g => g.Name)
                      .IsRequired()
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.Description)
                     .IsRequired()
                     .HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.Property(o => o.DateAndTime)
                      .IsRequired();

                entity.HasOne(o => o.User)
                      .WithMany(u => u.Orders)
                      .HasForeignKey(o => o.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Order_Book>(entity =>
            {
                entity.HasKey(ob => new { ob.OrderId, ob.BookId });

                entity.HasOne(ob => ob.Order)
                      .WithMany(o => o.Orders_Books)
                      .HasForeignKey(ob => ob.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ob => ob.Book)
                      .WithMany(b => b.Orders_Books)
                      .HasForeignKey(ob => ob.BookId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Publisher_Book>(entity =>
            {
                entity.HasKey(pb => new { pb.PublisherId, pb.BookId });

                entity.HasOne(pb => pb.Publisher)
                      .WithMany(p => p.Publishers_Books)
                      .HasForeignKey(pb => pb.PublisherId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pb => pb.Book)
                      .WithMany(b => b.Publishers_Books)
                      .HasForeignKey(pb => pb.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Text)
                      .HasMaxLength(2000);

                entity.HasOne(r => r.Book)
                      .WithMany(b => b.Reviews)
                      .HasForeignKey(r => r.BookId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.User)
                      .WithMany(u => u.Reviews)
                      .HasForeignKey(r => r.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.DateAndTime)
                      .IsRequired();

                entity.HasOne(e => e.Author)
                      .WithMany(a => a.Events)
                      .HasForeignKey(e => e.AuthorId)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Percent)
                      .HasPrecision(3, 0);

                entity.HasMany(p => p.Books)
                    .WithOne(b => b.Promotion)
                    .HasForeignKey(b => b.PromotionId)
                    .OnDelete(DeleteBehavior.SetNull);


            });


           
            
        }

    }
    
}
