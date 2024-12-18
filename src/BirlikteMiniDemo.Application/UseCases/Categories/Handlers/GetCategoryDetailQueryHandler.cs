using MediatR;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Categories.Queries;

namespace BirlikteMiniDemo.Application.UseCases.Categories.Handlers
{
    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDto>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryDetailQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<CategoryDto> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(request.Id);
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
