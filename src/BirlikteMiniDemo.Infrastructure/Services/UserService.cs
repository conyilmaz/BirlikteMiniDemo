using BirlikteMiniDemo.Domain.Entities;
using BirlikteMiniDemo.Domain.Repositories;
using BirlikteMiniDemo.Domain.Services;

namespace BirlikteMiniDemo.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> RegisterUserAsync(string email, string password)
        {
            var user = new User
            {
                Email = email,
                Password = password
            };

            var basket = new Basket
            {
                Id = Guid.NewGuid(),
                BasketItems = new List<BasketItem>()
            };

            user.Basket = basket;

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return user.Id;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id, u => u.Basket);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {id} not found.");

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task UpdateUserAsync(Guid id, string email, string password)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {id} not found.");

            user.Email = email;
            user.Password = password;
            _unitOfWork.Users.Update(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user != null)
            {
                _unitOfWork.Users.Delete(user);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
