using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Models.ViewModels;
namespace WISSEN.EDA.Repositories
{
    public interface ICustomerRepository
    {
        //== customer
        Task<Customer> GetByIdAsync(int id);
        Task<List<CustomerListViewModel>> GetAllAsync();
        Task<string> AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);

        //== address
        Task<Address> GetAddressByIdAsync(int id);
        Task<int> AddAddressAsync(Address address);
        Task UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(int id);

        //== paperwork
        Task AddPaperworkAsync(CustomerPaperwork paperwork);
        Task<List<CustomerPaperwork>> GetPaperworksByCustomerIdAsync(int customerId);
        Task<CustomerPaperwork?> GetPaperworkAsync(int customerId, int paperworkId);
        Task UpdatePaperworkAsync(CustomerPaperwork paperwork);
    }
}
