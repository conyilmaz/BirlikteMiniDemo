using MediatR;

namespace BirlikteMiniDemo.Application.UseCases.Products.Commands
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
