using WISSEN.EDA.Models.Entities;
namespace WISSEN.EDA.Repositories
{
    public interface IMasterRepository
    {
        Task<MasterItem> GetByIdAsync(int id);
        Task<List<MasterItem>> GetAllAsync(string masterItemName);
        Task<List<MasterItem>> GetAllAsync();
        Task AddAsync(MasterItem masterItem);
        Task UpdateAsync(MasterItem masterItem);
        Task DeleteAsync(int id);
    }
}
