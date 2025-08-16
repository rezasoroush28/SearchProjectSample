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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(p => p.Description)
                   .HasMaxLength(1000);

            builder.Property(p => p.IsDeleted);

            builder.HasMany(p => p.Variants)
                   .WithOne()
                   .HasForeignKey("ProductId") // Shadow FK
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
