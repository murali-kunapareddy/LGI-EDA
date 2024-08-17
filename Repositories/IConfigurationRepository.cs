using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Models.ViewModels;
namespace WISSEN.EDA.Repositories
{
    public interface IConfigurationRepository
    {
        Task<ConfigurationItem> GetByIdAsync(int id);
        Task<List<ConfigurationItem>> GetAllAsync(string ciName);
        Task<List<ConfigurationItem>> GetAllAsync();
        Task<List<DdlViewModel>> GetAllDdlAsync(string ciName);
        Task AddAsync(ConfigurationItem configurationItem);
        Task UpdateAsync(ConfigurationItem configurationItem);
        Task DeleteAsync(int id);
    }
}
