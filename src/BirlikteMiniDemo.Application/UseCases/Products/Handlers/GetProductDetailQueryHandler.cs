using MediatR;
using BirlikteMiniDemo.Application.UseCases.Products.DTOs;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Products.Queries;

namespace BirlikteMiniDemo.Application.UseCases.Products.Handlers
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDto>
    {
        private readonly IProductService _productService;

        public GetProductDetailQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDto> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(request.Id);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");

            var productDto = new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            return productDto;
        }
    }
}
