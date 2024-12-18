using MediatR;

namespace BirlikteMiniDemo.Application.UseCases.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
