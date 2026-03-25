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
    public class AuthorConfiguration : IEntityTypeConfiguration <Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
			builder.HasKey(a => a.Id);

<<<<<<< HEAD
            builder.Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Biography)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(a => a.Nationality)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.CoverImageUrl)
                .IsRequired();
        }
=======
			builder.Property(a => a.FullName)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(a => a.Biography)
				.IsRequired()
				.HasMaxLength(1000);

			builder.Property(a => a.Nationality)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(a => a.CoverImageUrl)
				.IsRequired();
		}
>>>>>>> 2e8c9ef4dc2c8dfbbaeb6450faaa5f967d37f6d4
    }
}
