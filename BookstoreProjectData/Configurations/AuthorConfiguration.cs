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
    }
}
