using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Domain.Entities;
using BirlikteMiniDemo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlikteMiniDemo.Infrastructure.Services
{
    public class BasketItemService : IBasketItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasketItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasketItem?> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.BasketItems.GetByIdAsync(id);
        }

        public async Task<IEnumerable<BasketItem>> GetAllAsync()
        {
            return await _unitOfWork.BasketItems.GetAllAsync();
        }

        public async Task<BasketItem> CreateAsync(BasketItem item)
        {
            await _unitOfWork.BasketItems.AddAsync(item);
            await _unitOfWork.CompleteAsync();
            return item;
        }

        public async Task<BasketItem> UpdateAsync(BasketItem item)
        {
            _unitOfWork.BasketItems.Update(item);
            await _unitOfWork.CompleteAsync();
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var existing = await _unitOfWork.BasketItems.GetByIdAsync(id);
            if (existing != null)
            {
                _unitOfWork.BasketItems.Delete(existing);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
