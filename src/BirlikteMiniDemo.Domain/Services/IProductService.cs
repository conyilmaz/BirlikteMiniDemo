using BirlikteMiniDemo.Domain.Entities;

namespace BirlikteMiniDemo.Domain.Services
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Guid id);
        Task<Product?> GetProductByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
