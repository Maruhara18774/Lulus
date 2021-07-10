using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lulus.Data.Entities;
using Lulus.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lulus.Data.Configurations
{
    public class LineQuantityConfiguration: IEntityTypeConfiguration<LineQuantity>
    {
        public void Configure(EntityTypeBuilder<LineQuantity> builder)
        {
            builder.ToTable("LineQuantities");

            builder.HasKey(x => x.LineQuantity_ID);

            builder.HasOne(x => x.ProductLine).WithMany(x => x.LineQuantities).HasForeignKey(x => x.ProductLine_ID);

            builder.HasOne(x => x.Size).WithMany(x => x.LineQuantities).HasForeignKey(x => x.Size);
        }
    }
}
