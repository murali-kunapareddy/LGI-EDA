using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories.Implementations
{
	public class UserRoleRepository : IUserRoleRepository
	{
		private readonly AppDBContext _dbContext;

		public UserRoleRepository(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(UserRole userRole)
		{
			await _dbContext.UserRoles.AddAsync(userRole);
			await _dbContext.SaveChangesAsync();
		}

        public async Task DeleteAsync(int id)
		{
			var userRole = await _dbContext.UserRoles.FindAsync(id, false);
			if (userRole != null)
			{
				_dbContext.UserRoles.Remove(userRole);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<List<UserRole>> GetAllAsync()
		{
			var userRoles = await _dbContext.UserRoles.ToListAsync();
			return userRoles;
		}

		public async Task<UserRole> GetByIdAsync(int id)
		{
			var userRole = await _dbContext.UserRoles.FindAsync(id);
			return userRole!;
		}

        public async Task<UserRole> GetByUserEmailAsync(string email)
        {
            // get user by email
            var user = await _dbContext.Users.Where(u=>u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return null!; // TODO: handle if user not found
            }
            // Get the user's role from userid
            var userRole = await _dbContext.UserRoles.Where(u=>u.UserId == user.Id).FirstOrDefaultAsync();
            return userRole!;
        }

        public async Task<UserRole> GetByUserIdAsync(int userId)
        {
            // Get the user's role from userid
            var userRole = await _dbContext.UserRoles.Where(ur=>ur.UserId == userId).FirstOrDefaultAsync();
            return userRole!;
        }

        public async Task UpdateAsync(UserRole userRole)
		{
			_dbContext.Entry(userRole).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
    }
}
