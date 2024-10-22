using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories.Implementations
{
    public class CommonRepository : ICommonRepository
    {
        private readonly AppDBContext _dbContext;

        public CommonRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

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
    }
}
