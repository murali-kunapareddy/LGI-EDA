using Microsoft.AspNetCore.Mvc.Rendering;
using WISSEN.EDA.Models.Entities;
namespace WISSEN.EDA.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
