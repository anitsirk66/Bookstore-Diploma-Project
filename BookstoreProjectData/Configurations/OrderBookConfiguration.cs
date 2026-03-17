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
    public class OrderBookConfiguration:IEntityTypeConfiguration<Order_Book>
    {
        public void Configure(EntityTypeBuilder<Order_Book> builder)
        {
            builder.HasKey(ob => new { ob.OrderId, ob.BookId });

            builder.HasOne(ob => ob.Order)
                  .WithMany(o => o.Orders_Books)
                  .HasForeignKey(ob => ob.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ob => ob.Book)
                  .WithMany(b => b.Orders_Books)
                  .HasForeignKey(ob => ob.BookId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
