using MediatR;

namespace BirlikteMiniDemo.Application.UseCases.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
