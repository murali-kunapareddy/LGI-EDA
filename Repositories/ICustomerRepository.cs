using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Models.ViewModels;
namespace WISSEN.EDA.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
        Task<List<CustomerListViewModel>> GetAllAsync();
        Task<string> AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);

        Task<Address> GetAddressByIdAsync(int id);
        Task<int> AddAddressAsync(Address address);
        Task UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(int id);

        Task AddPaperworkAsync(CustomerPaperwork paperwork);
    }
}
