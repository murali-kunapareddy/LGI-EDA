using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories.Implementations
{
    public class MasterRepository : IMasterRepository
    {
        private readonly AppDBContext _dbContext;

        public MasterRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(MasterItem masterItem)
        {
            await _dbContext.MasterItems.AddAsync(masterItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var masterItem = await _dbContext.MasterItems.FindAsync(id,false);
            if (masterItem != null)
            {
                _dbContext.MasterItems.Remove(masterItem);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<MasterItem>> GetAllAsync(string masterItemName)
        {
            var masterItems = await _dbContext.MasterItems.Where(mi=>mi.Name == masterItemName).ToListAsync();
            return masterItems;
        }

        public async Task<MasterItem> GetByIdAsync(int id)
        {
            var masterItem = await _dbContext.MasterItems.FindAsync(id);
            return masterItem!;
        }

        public async Task UpdateAsync(MasterItem masterItem)
        {
            _dbContext.Entry(masterItem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
