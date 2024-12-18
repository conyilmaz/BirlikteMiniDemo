using BirlikteMiniDemo.Domain.Entities;

namespace BirlikteMiniDemo.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Basket> Baskets { get; }
        IGenericRepository<BasketItem> BasketItems { get; }

        Task<int> CompleteAsync();
    }
}
