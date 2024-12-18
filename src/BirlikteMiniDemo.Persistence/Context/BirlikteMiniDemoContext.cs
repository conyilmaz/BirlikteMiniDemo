using BirlikteMiniDemo.Domain.Entities;
using BirlikteMiniDemo.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

public class BirlikteMiniDemoContext : DbContext
{
    public BirlikteMiniDemoContext(DbContextOptions<BirlikteMiniDemoContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Basket> Baskets { get; set; } = null!;
    public DbSet<BasketItem> BasketItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new BasketConfiguration());
        modelBuilder.ApplyConfiguration(new BasketItemConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
