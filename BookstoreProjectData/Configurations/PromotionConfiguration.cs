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

<<<<<<< HEAD
            builder.Property(p => p.Percent)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.From)
                .IsRequired();

            builder.Property(p => p.To)
                .IsRequired();
=======
			builder.Property(p => p.Percent)
				.IsRequired();
>>>>>>> 2e8c9ef4dc2c8dfbbaeb6450faaa5f967d37f6d4

			builder.Property(p => p.Description)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(p => p.From)
				.IsRequired();

			builder.Property(p => p.To)
				.IsRequired();

			builder.HasMany(p => p.Books)
				.WithOne(b => b.Promotion)
				.HasForeignKey(b => b.PromotionId)
				.OnDelete(DeleteBehavior.SetNull);
		}
    }
}
