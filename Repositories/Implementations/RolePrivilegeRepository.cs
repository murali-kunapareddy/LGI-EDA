using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories.Implementations
{
	public class RolePrivilegeRepository : IRolePrivilegeRepository
	{
		private readonly AppDBContext _dbContext;

		public RolePrivilegeRepository(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(RolePrivilege rolePrivilege)
		{
			await _dbContext.RolePrivileges.AddAsync(rolePrivilege);
			await _dbContext.SaveChangesAsync();
		}

        public async Task DeleteAsync(int id)
		{
			var rolePrivilege = await _dbContext.RolePrivileges.FindAsync(id, false);
			if (rolePrivilege != null)
			{
				_dbContext.RolePrivileges.Remove(rolePrivilege);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<List<RolePrivilege>> GetAllAsync()
		{
			var rolePrivileges = await _dbContext.RolePrivileges.ToListAsync();
			return rolePrivileges;
		}

		public async Task<RolePrivilege> GetByIdAsync(int id)
		{
			var privilege = await _dbContext.RolePrivileges.FindAsync(id);
			return privilege!;
		}

		public async Task UpdateAsync(RolePrivilege privilege)
		{
			_dbContext.Entry(privilege).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
    }
}
