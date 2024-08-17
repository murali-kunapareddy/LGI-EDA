using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Models.ViewModels;

namespace WISSEN.EDA.Repositories.Implementations
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly AppDBContext _context;

        public ConfigurationRepository(AppDBContext appDBContext)
        {
            _context = appDBContext;
        }

        public Task AddAsync(ConfigurationItem configurationItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ConfigurationItem>> GetAllAsync(string ciName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ConfigurationItem>> GetAllAsync()
        {
            var configurationItems = await _context.ConfigurationItems.ToListAsync();
            return configurationItems;
        }

        public Task<ConfigurationItem> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<DdlViewModel>> IConfigurationRepository.GetAllDdlAsync(string ciName)
        {
            var ddl = _context.ConfigurationItems.Where(
                c => c.Name == "Masters" && c.IsActive && !c.IsDeleted)
                .Select(c => new DdlViewModel { Key = c.Key, Value = c.Value} ).ToListAsync();
            return ddl;
        }

        public Task UpdateAsync(ConfigurationItem configurationItem)
        {
            throw new NotImplementedException();
        }
    }
}
