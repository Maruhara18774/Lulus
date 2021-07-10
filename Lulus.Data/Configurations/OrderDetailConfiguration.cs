using Lulus.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");

            builder.HasKey(x => x.OrderDetail_ID);
            builder.Property(x => x.OrderDetail_Quantity).HasDefaultValue<int>(1);
            builder.Property(x => x.OrderDetail_Total).HasDefaultValue<double>(0);

            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.Order_ID);
            builder.HasOne(x => x.ProductLine).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductLine_ID);
        }
    }
}
