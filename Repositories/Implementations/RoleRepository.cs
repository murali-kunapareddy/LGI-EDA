using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories.Implementations
{
	public class RoleRepository : IRoleRepository
	{
		private readonly AppDBContext _dbContext;

		public RoleRepository(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(Role role)
		{
			await _dbContext.Roles.AddAsync(role);
			await _dbContext.SaveChangesAsync();
		}

        public async Task DeleteAsync(string code)
		{
			var role = await _dbContext.Roles.FindAsync(code, false);
			if (role != null)
			{
				_dbContext.Roles.Remove(role);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<List<Role>> GetAllAsync()
		{
			var roles = await _dbContext.Roles.ToListAsync();
			return roles;
		}

		public async Task<Role> GetByCodeAsync(string code)
		{
			var role = await _dbContext.Roles.FindAsync(code);
			return role!;
		}

		public async Task UpdateAsync(Role role)
		{
			_dbContext.Entry(role).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
    }
}
