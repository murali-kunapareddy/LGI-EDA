using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Models.ViewModels;
namespace WISSEN.EDA.Repositories
{
    public interface IOrderRepository
    {
        //== order
        Task<Order> GetByIdAsync(int id);
        Task<List<OrderListViewModel>> GetAllAsync();
        Task<string> AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
    }
}
