using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WISSEN.EDA.Repositories.Implementations
{
    public class CommonRepository : ICommonRepository
    {
        private readonly AppDBContext _dbContext;
        public CommonRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region ========== MASTERS ==========
        public List<SelectListItem> GetDDLMasters()
        {
            var list = _dbContext.ConfigurationItems.Where(m => m.Name == "Masters")
                .Select(m => new SelectListItem
                {
                    Text = m.Key,
                    Value = m.Value
                }).ToList();

            return list;
        }
        public List<SelectListItem> GetDDLSelectedMasters(string masterName)
        {
            var list = _dbContext.MasterItems.Where(m => m.Name == masterName && m.IsActive && !m.IsDeleted)
                .Select(m => new SelectListItem
                {
                    Text = m.Key,
                    Value = m.Id.ToString()
                }).ToList();

            return list;
        }

        #endregion

        #region ========== COUNTRIES ==========
        public List<SelectListItem> GetDDLCountries()
        {
            var list = _dbContext.Countries.Where(m => m.IsActive && !m.IsDeleted)
                .Select(m => new SelectListItem
                {
                    Text = m.Code,
                    Value = m.Name
                }).ToList();

            return list;
        }
        public async Task<List<Country>> GetCountriesAsync()
        {
            return await _dbContext.Countries.Where(c => c.IsActive && !c.IsDeleted).ToListAsync();
        }
        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _dbContext.Countries
                .Where(c => c.IsActive && !c.IsDeleted)
                .ToListAsync();
        }

        #endregion

        #region ========== COMPANIES ==========
        public List<SelectListItem> GetDDLCompanies()
        {
            var list = _dbContext.Companies.Where(m => m.IsActive && !m.IsDeleted)
                .Select(m => new SelectListItem
                {
                    Text = m.Code.ToString(),
                    Value = m.Name
                }).ToList();

            return list;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _dbContext.Companies
                 .Where(c => c.IsActive && !c.IsDeleted)
                 .ToListAsync();
        }

        #endregion

        #region ========== ADDRESS ==========

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            var address = await _dbContext.Addresses
                .Where(a => a.Id == id && a.IsActive && !a.IsDeleted)
                .FirstOrDefaultAsync();

            if (address == null)
            {
                throw new InvalidOperationException($"Address with ID {id} not found.");
            }

            return address;
        }

        public async Task<Address> GetAddressByUserIdAsync(int userId)
        {
            // Get user profile by user ID
            var userProfile = await _dbContext.UserProfiles
                .Where(up => up.UserId == userId && up.IsActive && !up.IsDeleted)
                .FirstOrDefaultAsync();

            // Check if userProfile is null
            if (userProfile == null)
            {
                throw new InvalidOperationException($"UserProfile with UserId {userId} not found.");
            }

            // Check if AddressId is null
            if (!userProfile.AddressId.HasValue)
            {
                throw new InvalidOperationException($"AddressId for UserId {userId} is null.");
            }

            // Safely pass AddressId to GetAddressByIdAsync
            return await GetAddressByIdAsync(userProfile.AddressId.Value);
        }

        public async Task<string> AddAddressAsync(Address address)
        {
            try
            {
                await _dbContext.Addresses.AddAsync(address);
                await _dbContext.SaveChangesAsync();
                return "success";
            }
            catch (Exception ex)
            {
                return $"error:{ex.Message}";
            }
        }

        public async Task<string> UpdateAddressAsync(Address address)
        {
            try
            {
                _dbContext.Entry(address).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return "success";
            }
            catch (Exception ex)
            {
                return $"error:{ex.Message}";
            }
        }

        public async Task<string> DeleteAddressAsync(int id)
        {
            try
            {
                var address = await _dbContext.Addresses.FindAsync(id, false);
                if (address != null)
                {
                    _dbContext.Addresses.Remove(address);
                    await _dbContext.SaveChangesAsync();
                    return "success";
                }
                return "notfound";
            }
            catch (Exception ex)
            {
                return $"error:{ex.Message}";
            }
        }

        #endregion
    }
}
