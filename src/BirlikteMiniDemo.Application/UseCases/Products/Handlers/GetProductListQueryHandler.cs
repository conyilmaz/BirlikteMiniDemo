using MediatR;
using BirlikteMiniDemo.Application.UseCases.Products.DTOs;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Products.Queries;

namespace BirlikteMiniDemo.Application.UseCases.Products.Handlers
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductService _productService;

        public GetProductListQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllProductsAsync();
         
            var productDtos = products.Select(product => new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                CategoryId = product.CategoryId
            });

            return productDtos;
        }
    }
}
