using BirlikteMiniDemo.Domain.Entities;

namespace BirlikteMiniDemo.Domain.Services
{
    public interface IBasketItemService
    {
        Task<BasketItem?> GetByIdAsync(Guid id);
        Task<IEnumerable<BasketItem>> GetAllAsync();
        Task<BasketItem> CreateAsync(BasketItem item);
        Task<BasketItem> UpdateAsync(BasketItem item);
        Task DeleteAsync(Guid id);
    }
}
