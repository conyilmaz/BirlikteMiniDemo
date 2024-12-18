using MediatR;

namespace BirlikteMiniDemo.Application.UseCases.Categories.Queries
{
    public class GetCategoryDetailQuery : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }
    }
}
