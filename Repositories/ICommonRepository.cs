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
        Task<List<Company>> GetAllCompaniesAsync();
        Task<List<Country>> GetAllCountriesAsync();

        Task<Address> GetAddressByIdAsync(int id);
        Task<Address> GetAddressByUserIdAsync(int userId);
        Task<string> AddAddressAsync(Address address);
        Task<string> UpdateAddressAsync(Address address);
        Task<string> DeleteAddressAsync(int id);


    }
}
