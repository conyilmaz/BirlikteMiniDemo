using MediatR;
using BirlikteMiniDemo.Domain.Entities;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Categories.Commands;

namespace BirlikteMiniDemo.Application.UseCases.Categories.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name
            };

            return await _categoryService.CreateCategoryAsync(category);
        }
    }
}
