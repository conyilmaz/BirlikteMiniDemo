using MediatR;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Baskets.Commands;

namespace BirlikteMiniDemo.Application.UseCases.Baskets.Handlers
{
    public class AddProductToBasketCommandHandler : IRequestHandler<AddProductToBasketCommand, Unit>
    {
        private readonly IBasketService _basketService;

        public AddProductToBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<Unit> Handle(AddProductToBasketCommand request, CancellationToken cancellationToken)
        {
            await _basketService.AddProductToBasketAsync(request.BasketId, request.ProductId, request.Quantity);
            return Unit.Value;
        }
    }
}
