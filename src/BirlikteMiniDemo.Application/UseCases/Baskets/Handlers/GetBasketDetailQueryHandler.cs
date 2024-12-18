using MediatR;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Baskets.DTOs;
using BirlikteMiniDemo.Application.UseCases.Baskets.Queries;

namespace BirlikteMiniDemo.Application.UseCases.Baskets.Handlers
{
    public class GetBasketDetailQueryHandler : IRequestHandler<GetBasketDetailQuery, BasketDto>
    {
        private readonly IBasketService _basketService;

        public GetBasketDetailQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<BasketDto> Handle(GetBasketDetailQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasketByIdAsync(request.BasketId);

            return new BasketDto
            {
                BasketId = basket.Id,
                Items = basket.BasketItems.Select(bi => new BasketItemDto
                {
                    ProductId = bi.ProductId,
                    ProductTitle = bi.Product?.Title ?? "Unknown",
                    Quantity = bi.Quantity,
                    Price = bi.Product?.Price ?? 0
                }).ToList(),
                TotalPrice = basket.BasketItems.Sum(bi => bi.Quantity * (bi.Product?.Price ?? 0))
            };
        }

    }
}
