using BirlikteMiniDemo.Domain.Entities;

namespace BirlikteMiniDemo.Domain.Services
{
    public interface ICategoryService
    {
        Task<Guid> CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Guid id, string name);
        Task DeleteCategoryAsync(Guid id);
        Task<Category> GetCategoryByIdAsync(Guid id);
    }
}
