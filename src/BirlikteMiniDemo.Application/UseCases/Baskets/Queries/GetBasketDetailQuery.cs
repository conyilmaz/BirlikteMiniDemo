using MediatR;
using BirlikteMiniDemo.Application.UseCases.Baskets.DTOs;

namespace BirlikteMiniDemo.Application.UseCases.Baskets.Queries
{
    public class GetBasketDetailQuery : IRequest<BasketDto>
    {
        public Guid BasketId { get; set; }
    }
}
