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
    public class ProductLineConfiguration : IEntityTypeConfiguration<ProductLine>
    {
        public void Configure(EntityTypeBuilder<ProductLine> builder)
        {
            builder.ToTable("ProductLines");
            builder.HasKey(x => x.ProductLine_ID);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductLines).HasForeignKey(x => x.Product_ID);
        }
    }
}
