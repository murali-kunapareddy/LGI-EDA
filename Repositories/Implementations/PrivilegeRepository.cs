using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories.Implementations
{
	public class PrivilegeRepository : IPrivilegeRepository
	{
		private readonly AppDBContext _dbContext;

		public PrivilegeRepository(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(Privilege privilege)
		{
			await _dbContext.Privileges.AddAsync(privilege);
			await _dbContext.SaveChangesAsync();
		}

        public async Task DeleteAsync(int id)
		{
			var privilege = await _dbContext.Privileges.FindAsync(id, false);
			if (privilege != null)
			{
				_dbContext.Privileges.Remove(privilege);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<List<Privilege>> GetAllAsync()
		{
			var privileges = await _dbContext.Privileges.ToListAsync();
			return privileges;
		}

		public async Task<Privilege> GetByIdAsync(int id)
		{
			var privileges = await _dbContext.Privileges.FindAsync(id);
			return privileges!;
		}

		public async Task UpdateAsync(Privilege privilege)
		{
			_dbContext.Entry(privilege).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
    }
}
