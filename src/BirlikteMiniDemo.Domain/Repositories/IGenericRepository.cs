using System.Linq.Expressions;

namespace BirlikteMiniDemo.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAll();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
