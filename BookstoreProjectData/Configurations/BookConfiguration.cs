using BookstoreProjectData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectData.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(b => b.Price)
                  .HasPrecision(10, 2);

            builder.HasOne(b => b.Author)
                  .WithMany(a => a.Books)
                  .HasForeignKey(b => b.AuthorId)
                  .OnDelete(DeleteBehavior.Restrict); //cascade?

            builder.HasOne(b => b.Genre)
                  .WithMany(g => g.Books)
                  .HasForeignKey(b => b.GenreId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.Property(b => b.CoverImageUrl)
                    .IsRequired();

            builder.Property(b => b.Synopsis)
                  .IsRequired()
                  .HasMaxLength(1000);
			builder.Property(b => b.CoverImageUrl)
	                .IsRequired();

			builder.Property(b => b.Synopsis)
				  .IsRequired()
				  .HasMaxLength(1000);
		}
    }
}
