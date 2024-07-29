using WISSEN.EDA.Models.Entities;
namespace WISSEN.EDA.Repositories
{
    public interface IMasterRepository
    {
        Task<MasterItem> GetByIdAsync(int id);
        Task<List<MasterItem>> GetAllAsync(string masterItemName);
        Task AddAsync(MasterItem masterItemViewModel);
        Task UpdateAsync(MasterItem masterItemViewModel);
        Task DeleteAsync(int id);
    }
}
