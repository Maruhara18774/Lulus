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
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Product_ID);

            builder.Property(x => x.Product_Price).HasDefaultValue<double>(0);

            builder.Property(x => x.Product_SalePrice).HasDefaultValue<double>(0);

            builder.Property(x => x.Status).HasDefaultValue(ProductStatus.Stocking);

            builder.HasOne(x => x.SubCategory).WithMany(x => x.Products).HasForeignKey(x => x.SubCategory_ID);
        }
    }
}
