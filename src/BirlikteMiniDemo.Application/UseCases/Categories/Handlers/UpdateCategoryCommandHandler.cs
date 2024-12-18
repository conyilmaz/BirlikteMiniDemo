using MediatR;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Categories.Commands;

namespace BirlikteMiniDemo.Application.UseCases.Categories.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryService.UpdateCategoryAsync(request.Id, request.Name);
            return Unit.Value; 
        }
    }
}
