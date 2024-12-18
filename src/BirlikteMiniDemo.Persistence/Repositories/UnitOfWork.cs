using BirlikteMiniDemo.Domain.Entities;
using BirlikteMiniDemo.Domain.Repositories;

namespace BirlikteMiniDemo.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BirlikteMiniDemoContext _context;

        public IGenericRepository<User> Users { get; }
        public IGenericRepository<Category> Categories { get; }
        public IGenericRepository<Product> Products { get; }
        public IGenericRepository<Basket> Baskets { get; }
        public IGenericRepository<BasketItem> BasketItems { get; }

        public UnitOfWork(BirlikteMiniDemoContext context)
        {
            _context = context;
            Users = new GenericRepository<User>(context);
            Categories = new GenericRepository<Category>(context);
            Products = new GenericRepository<Product>(context);
            Baskets = new GenericRepository<Basket>(context);
            BasketItems = new GenericRepository<BasketItem>(context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
