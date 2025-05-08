using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories
{
    public interface IRolePrivilegeRepository
    {
        Task<RolePrivilege> GetByIdAsync(int id);
        Task<List<RolePrivilege>> GetAllAsync();
        Task AddAsync(RolePrivilege rolePrivilege);
        Task UpdateAsync(RolePrivilege rolePrivilege);
        Task DeleteAsync(int id);
    }
}
