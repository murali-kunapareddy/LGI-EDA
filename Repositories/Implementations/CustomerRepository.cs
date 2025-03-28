using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Models.ViewModels;

namespace WISSEN.EDA.Repositories.Implementations
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly AppDBContext _context;

		public CustomerRepository(AppDBContext Context)
		{
			_context = Context;
		}

        #region ================== Customer ==================
        public async Task<string> AddAsync(Customer customer)
		{
			try
			{
				await _context.Customers.AddAsync(customer);
				await _context.SaveChangesAsync();
				return "success";
			}
			catch (Exception ex)
			{
				return $"error:{ex.Message}";
			}
		}

		public async Task DeleteAsync(int id)
		{
			var customer = await _context.Customers.FindAsync(id, false);
			if (customer != null)
			{
				_context.Customers.Remove(customer);
				await _context.SaveChangesAsync();
			}
		}

        public async Task<List<CustomerListViewModel>> GetAllAsync()
        {
            try
            {
                return await _context.Customers
                    .Include(c => c.Company)
                    .Select(c => new CustomerListViewModel
                    {
                        Id = c.Id,
                        BillToNo = c.BillToNo,
                        BillToName = c.BillToName,
                        ShipToNo = c.ShipToNo,
                        ShipToName = c.ShipToName,
                        CompanyCode = c.CompanyCode,
                        CompanyName = c.Company != null ? c.Company.Name : string.Empty,
                        IsActive = c.IsActive
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<CustomerListViewModel>();
            }
        }

		public async Task<Customer> GetByIdAsync(int id)
		{
			var customer = await _context.Customers.FindAsync(id);
			return customer!;
		}

		public async Task UpdateAsync(Customer customer)
		{
			_context.Entry(customer).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

        #endregion

        #region ================== Address ==================

        public async Task<int> AddAddressAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address.Id;
        }

        public async Task DeleteAddressAsync(int id)
        {
            var address = await GetAddressByIdAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task UpdateAddressAsync(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region ================== CustomerPaperwork ==================

        public async Task AddPaperworkAsync(CustomerPaperwork paperwork)
        {
            await _context.CustomerPaperworks.AddAsync(paperwork);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CustomerPaperwork>> GetPaperworksByCustomerIdAsync(int customerId)
        {
            return await _context.CustomerPaperworks
                .Include(p => p.Paperwork) // Include the related MasterItem
                .Where(p => p.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<CustomerPaperwork?> GetPaperworkAsync(int customerId, int paperworkId)
        {
            return await _context.CustomerPaperworks
                .FirstOrDefaultAsync(p => p.CustomerId == customerId && p.PaperworkId == paperworkId);
        }

        public async Task UpdatePaperworkAsync(CustomerPaperwork paperwork)
        {
            _context.CustomerPaperworks.Update(paperwork);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
