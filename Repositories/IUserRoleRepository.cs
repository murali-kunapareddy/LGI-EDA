using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories
{
    public interface IUserRoleRepository
    {
        Task<UserRole> GetByIdAsync(int id);
        Task<List<UserRole>> GetAllAsync();
        Task<UserRole> GetByUserIdAsync(int userId);
        Task<UserRole> GetByUserEmailAsync(string email);
        Task AddAsync(UserRole userRole);
        Task UpdateAsync(UserRole userRole);
        Task DeleteAsync(int id);
    }
}
