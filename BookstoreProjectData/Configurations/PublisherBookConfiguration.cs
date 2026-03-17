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
    public class PublisherBookConfiguration : IEntityTypeConfiguration<Publisher_Book>
    {
        public void Configure (EntityTypeBuilder<Publisher_Book> builder)
        {
            builder.HasKey(pb => new { pb.PublisherId, pb.BookId });

            builder.HasOne(pb => pb.Publisher)
                  .WithMany(p => p.Publishers_Books)
                  .HasForeignKey(pb => pb.PublisherId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pb => pb.Book)
                  .WithMany(b => b.Publishers_Books)
                  .HasForeignKey(pb => pb.BookId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
