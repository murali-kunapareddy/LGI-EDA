using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> GetByIdAsync(int id);
        Task<List<UserProfile>> GetAllAsync();
        Task AddAsync(UserProfile userProfile);
        Task UpdateAsync(UserProfile userProfile);
        Task DeleteAsync(int id);
    }
}
