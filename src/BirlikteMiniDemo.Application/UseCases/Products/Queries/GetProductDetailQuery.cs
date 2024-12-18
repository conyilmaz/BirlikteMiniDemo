using MediatR;
using BirlikteMiniDemo.Application.UseCases.Products.DTOs;
using BirlikteMiniDemo.Domain.Entities;

namespace BirlikteMiniDemo.Application.UseCases.Products.Queries
{
    public class GetProductDetailQuery : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
