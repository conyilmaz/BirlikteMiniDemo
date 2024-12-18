using BirlikteMiniDemo.Domain.Entities;
using BirlikteMiniDemo.Domain.Repositories;
using BirlikteMiniDemo.Domain.Services;

namespace BirlikteMiniDemo.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateCategoryAsync(Category category)
        {
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.CompleteAsync();
            return category.Id;
        }

        public async Task UpdateCategoryAsync(Guid id, string name)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {id} not found.");

            category.Name = name;

            _unitOfWork.Categories.Update(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {id} not found.");

            _unitOfWork.Categories.Delete(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {id} not found.");

            return category;
        }
    }
}
