using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories.Implementations
{
	public class UserProfileRepository : IUserProfileRepository
	{
		private readonly AppDBContext _dbContext;

		public UserProfileRepository(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(UserProfile userProfile)
		{
			await _dbContext.UserProfiles.AddAsync(userProfile);
			await _dbContext.SaveChangesAsync();
		}

        public async Task DeleteAsync(int id)
		{
			var userProfile = await _dbContext.UserProfiles.FindAsync(id, false);
			if (userProfile != null)
			{
				_dbContext.UserProfiles.Remove(userProfile);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<List<UserProfile>> GetAllAsync()
		{
			var userProfiles = await _dbContext.UserProfiles.ToListAsync();
			return userProfiles;
		}

		public async Task<UserProfile> GetByIdAsync(int id)
		{
			var userProfiles = await _dbContext.UserProfiles.FindAsync(id);
			return userProfiles!;
		}

		public async Task UpdateAsync(UserProfile userProfile)
		{
			_dbContext.Entry(userProfile).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
    }
}
