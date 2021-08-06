using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Week4.Academy.Test.Core.Models;

namespace Week4.Academy.Test.EF.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order").HasKey(o => o.ID_Order);
            builder.Property(o => o.OrderCode).IsRequired();
            builder.Property(o => o.ProductCode).IsRequired();
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.ID_Customer).IsRequired();
            builder.Property(o => o.Import).IsRequired();
            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ID_Customer);
        }
    }
}
