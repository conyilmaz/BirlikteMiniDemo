using BirlikteMiniDemo.Domain.Entities;
using BirlikteMiniDemo.Domain.Repositories;
using BirlikteMiniDemo.Domain.Services;
using Microsoft.EntityFrameworkCore;



namespace BirlikteMiniDemo.Infrastructure.Services
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddProductToBasketAsync(Guid basketId, Guid productId, int quantity)
        {
            var basket = await _unitOfWork.Baskets.GetByIdAsync(basketId)
                         ?? new Basket { Id = basketId, BasketItems = new List<BasketItem>() };

            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            var basketItem = basket.BasketItems.FirstOrDefault(bi => bi.ProductId == productId);
            if (basketItem != null)
            {
                basketItem.Quantity += quantity;
            }
            else
            {
                basket.BasketItems.Add(new BasketItem
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }

            if (basket.Id == Guid.Empty)
                await _unitOfWork.Baskets.AddAsync(basket);

            await _unitOfWork.CompleteAsync();
        }

        public async Task RemoveProductFromBasketAsync(Guid basketId, Guid productId)
        {
            var basket = await _unitOfWork.Baskets.GetByIdAsync(basketId);
            if (basket == null)
                throw new KeyNotFoundException($"Basket with ID {basketId} not found.");

            var basketItem = basket.BasketItems.FirstOrDefault(bi => bi.ProductId == productId);
            if (basketItem == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found in the basket.");

            basket.BasketItems.Remove(basketItem);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Basket> GetBasketByIdAsync(Guid basketId)
        {
            var basket = await _unitOfWork.Baskets
                .GetAll()
                .Include(b => b.BasketItems)
                .ThenInclude(bi => bi.Product)
                .FirstOrDefaultAsync(b => b.Id == basketId);

            if (basket == null)
                throw new KeyNotFoundException($"Basket with ID {basketId} not found.");

            return basket;
        }


    }
}
