using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProduct.Infrastructure.Persistence.Configuration
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Sku)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(v => v.Quantity)
                   .IsRequired();

            builder.Property(v => v.IsActive)
                   .IsRequired();

            builder.OwnsMany(v => v.Attributes, attr =>
            {
                attr.WithOwner().HasForeignKey("ProductVariantId");

                attr.Property(a => a.Key)
                .IsRequired()
                .HasMaxLength(100);

                attr.Property(a => a.Value)
                .IsRequired()
                .HasMaxLength(255);

                attr.HasKey("ProductVariantId", "Key", "Value"); 
                attr.ToTable("ProductVariantAttributes");
            });
        }
    }
}
