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
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Percent)
                  .HasPrecision(3, 0);

            builder.HasMany(p => p.Books)
                .WithOne(b => b.Promotion)
                .HasForeignKey(b => b.PromotionId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
