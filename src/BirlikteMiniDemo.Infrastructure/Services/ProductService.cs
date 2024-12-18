using BirlikteMiniDemo.Domain.Entities;
using BirlikteMiniDemo.Domain.Repositories;
using BirlikteMiniDemo.Domain.Services;

namespace BirlikteMiniDemo.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateProductAsync(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return product.Id;
        }

        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(product.Id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {product.Id} not found.");

            existingProduct.Title = product.Title;
            existingProduct.Description = product.Description;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.Price = product.Price;
            existingProduct.CategoryId = product.CategoryId;

            _unitOfWork.Products.Update(existingProduct);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }
    }
}
