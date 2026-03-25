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
    public class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
			builder.HasKey(o => o.Id);

<<<<<<< HEAD
            builder.Property(o => o.DateAndTime)
                .IsRequired();

            builder.Property(o => o.Address)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o => o.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o => o.UserId)
                .IsRequired();

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
=======
			builder.Property(o => o.DateAndTime)
				.IsRequired();

			builder.Property(o => o.Address)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(o => o.Status)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(o => o.UserId)
				.IsRequired();

			builder.HasOne(o => o.User)
				.WithMany(u => u.Orders)
				.HasForeignKey(o => o.UserId)
				.OnDelete(DeleteBehavior.Restrict);

		}
>>>>>>> 2e8c9ef4dc2c8dfbbaeb6450faaa5f967d37f6d4
    }
}
