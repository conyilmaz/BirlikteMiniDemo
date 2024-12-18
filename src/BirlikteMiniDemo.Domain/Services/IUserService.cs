using BirlikteMiniDemo.Domain.Entities;

namespace BirlikteMiniDemo.Domain.Services
{
    public interface IUserService
    {
        Task<Guid> RegisterUserAsync(string email, string password);
        Task UpdateUserAsync(Guid id, string email,string password);
        Task DeleteUserAsync(Guid id);
        Task<User> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
