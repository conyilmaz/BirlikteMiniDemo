using BirlikteMiniDemo.Domain.Entities;

namespace BirlikteMiniDemo.Domain.Services
{
    public interface IBasketService
    {
        Task AddProductToBasketAsync(Guid basketId, Guid productId, int quantity);
        Task RemoveProductFromBasketAsync(Guid basketId, Guid productId);
        Task<Basket> GetBasketByIdAsync(Guid basketId);
    }
}
