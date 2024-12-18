using BirlikteMiniDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirlikteMiniDemo.Persistence.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .HasMaxLength(2000);

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(500);

            builder.Property(p => p.Price)
                .HasPrecision(18, 2);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.BasketItems)
                .WithOne(bi => bi.Product)
                .HasForeignKey(bi => bi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
