using MediatR;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Categories.Commands;

namespace BirlikteMiniDemo.Application.UseCases.Categories.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryService.DeleteCategoryAsync(request.Id);
            return Unit.Value; 
        }
    }
}
