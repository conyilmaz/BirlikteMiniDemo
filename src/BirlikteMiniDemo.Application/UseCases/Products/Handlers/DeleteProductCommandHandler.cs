using MediatR;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Products.Commands;

namespace BirlikteMiniDemo.Application.UseCases.Products.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductAsync(request.Id);
            return Unit.Value; 
        }
    }
}
