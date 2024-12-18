using BirlikteMiniDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirlikteMiniDemo.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.ProfilePhotoUrl)
                .HasMaxLength(500);

            builder.HasOne(u => u.Basket)
                .WithOne(b => b.User)
                .HasForeignKey<Basket>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
