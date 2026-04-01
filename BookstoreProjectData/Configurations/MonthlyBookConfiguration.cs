using BookstoreProjectData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectData.Configurations
{
    public class MonthlyBookConfiguration  : IEntityTypeConfiguration<MonthlyBook>
    {
        public void Configure(EntityTypeBuilder<MonthlyBook> builder)
        {
            builder.HasKey(mb => new { mb.MonthlyBookSelectionId, mb.BookId });

            builder
                .HasOne(mb => mb.Book)
                .WithMany()
                .HasForeignKey(mb => mb.BookId);

            builder
                .HasOne(mb => mb.MonthlyBookSelection)
                .WithMany(m => m.MonthlyBooks)
                .HasForeignKey(mb => mb.MonthlyBookSelectionId);
        }
    }
}
