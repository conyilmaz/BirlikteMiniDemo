using BirlikteMiniDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirlikteMiniDemo.Persistence.EntityTypeConfigurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Baskets");

            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.User)
                .WithOne(u => u.Basket)
                .HasForeignKey<Basket>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.BasketItems)
                .WithOne(bi => bi.Basket)
                .HasForeignKey(bi => bi.BasketId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
