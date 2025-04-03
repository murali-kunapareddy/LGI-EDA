using Microsoft.AspNetCore.Mvc.Rendering;
using WISSEN.EDA.Models.Entities;
namespace WISSEN.EDA.Repositories
{
    public interface ICommonRepository
    {
        List<SelectListItem> GetDDLMasters();
        List<SelectListItem> GetDDLSelectedMasters(string masterName);
        List<SelectListItem> GetDDLCountries();
        List<SelectListItem> GetDDLCompanies();

        Task<List<Country>> GetCountriesAsync();
    }
}
