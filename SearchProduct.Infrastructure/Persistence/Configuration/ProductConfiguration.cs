using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SearchProject.Domain.Entities;

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

        
        builder.HasMany<ProductVariant>()
               .WithOne()
               .HasForeignKey("ProductId")
               .OnDelete(DeleteBehavior.Cascade);

        // ✅ Optional: tell EF to use the field
        builder.Navigation(p => p.Variants)
               .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
