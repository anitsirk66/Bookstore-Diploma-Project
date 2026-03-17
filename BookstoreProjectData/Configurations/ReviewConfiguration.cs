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
    public class ReviewConfiguration:IEntityTypeConfiguration<Review>
    {
        public void Configure (EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Text)
                  .HasMaxLength(2000);

            builder.HasOne(r => r.Book)
                  .WithMany(b => b.Reviews)
                  .HasForeignKey(r => r.BookId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.User)
                  .WithMany(u => u.Reviews)
                  .HasForeignKey(r => r.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
