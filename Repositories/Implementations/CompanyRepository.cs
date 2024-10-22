using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories.Implementations
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDBContext _dbContext;

        public CompanyRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddAsync(Company company)
        {
            try
            {
                await _dbContext.Companies.AddAsync(company);
                await _dbContext.SaveChangesAsync();
                return "success";
            }
            catch (Exception ex)
            {
                return $"error:{ex.Message}";
            }
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _dbContext.Companies.FindAsync(id, false);
            if (company != null)
            {
                _dbContext.Companies.Remove(company);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Company>> GetAllAsync()
        {
            var companies = await _dbContext.Companies.ToListAsync();
            return companies;
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            return company!;
        }

        public async Task UpdateAsync(Company company)
        {
            _dbContext.Entry(company).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
