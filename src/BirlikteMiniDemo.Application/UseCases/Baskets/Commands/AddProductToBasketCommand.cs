using MediatR;

namespace BirlikteMiniDemo.Application.UseCases.Baskets.Commands
{
    public class AddProductToBasketCommand : IRequest<Unit>
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
