using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories
{
    public interface IPrivilegeRepository
    {
        Task<Privilege> GetByIdAsync(int id);
        Task<List<Privilege>> GetAllAsync();
        Task AddAsync(Privilege privilege);
        Task UpdateAsync(Privilege privilege);
        Task DeleteAsync(int id);
    }
}
