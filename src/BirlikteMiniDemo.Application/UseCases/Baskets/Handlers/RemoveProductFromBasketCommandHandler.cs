using MediatR;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Baskets.Commands;

namespace BirlikteMiniDemo.Application.UseCases.Baskets.Handlers
{
    public class RemoveProductFromBasketCommandHandler : IRequestHandler<RemoveProductFromBasketCommand, Unit>
    {
        private readonly IBasketService _basketService;

        public RemoveProductFromBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<Unit> Handle(RemoveProductFromBasketCommand request, CancellationToken cancellationToken)
        {
            await _basketService.RemoveProductFromBasketAsync(request.BasketId, request.ProductId);
            return Unit.Value;
        }
    }
}
