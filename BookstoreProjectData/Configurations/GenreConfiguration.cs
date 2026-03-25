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
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
			builder.HasKey(g => g.Id);

<<<<<<< HEAD
            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(g => g.Desciption)
                .IsRequired()
                .HasMaxLength(300);
        }
=======
			builder.Property(g => g.Name)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(g => g.Desciption)
				.IsRequired()
				.HasMaxLength(300);
		}
>>>>>>> 2e8c9ef4dc2c8dfbbaeb6450faaa5f967d37f6d4
    }
}
