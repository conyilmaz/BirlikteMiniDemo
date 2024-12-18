using MediatR;

namespace BirlikteMiniDemo.Application.UseCases.Baskets.Commands
{
    public class RemoveProductFromBasketCommand : IRequest<Unit>
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
    }
}
