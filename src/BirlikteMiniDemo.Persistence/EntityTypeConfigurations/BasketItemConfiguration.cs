using BirlikteMiniDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirlikteMiniDemo.Persistence.EntityTypeConfigurations
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.ToTable("BasketItems");

            builder.HasKey(bi => bi.Id);

            builder.Property(bi => bi.Quantity)
                .IsRequired()
                .HasDefaultValue(1);

            builder.HasOne(bi => bi.Basket)
                .WithMany(b => b.BasketItems)
                .HasForeignKey(bi => bi.BasketId);

            builder.HasOne(bi => bi.Product)
                .WithMany(p => p.BasketItems)
                .HasForeignKey(bi => bi.ProductId);
        }
    }
}
