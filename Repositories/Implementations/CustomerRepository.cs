using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Models.ViewModels;

namespace WISSEN.EDA.Repositories.Implementations
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly AppDBContext _dbContext;

		public CustomerRepository(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<string> AddAsync(Customer customer)
		{
			try
			{
				await _dbContext.Customers.AddAsync(customer);
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
			var customer = await _dbContext.Customers.FindAsync(id, false);
			if (customer != null)
			{
				_dbContext.Customers.Remove(customer);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<List<CustomerListViewModel>> GetAllAsync()
		{
			try
			{
				var customers = await _dbContext.Customers.ToListAsync();
				var companies = await _dbContext.Companies.ToListAsync();
				//TODO return required fields for list page only
				var customerListViewModel = (from cust in customers
											 join comp in companies on cust.CompanyCode equals comp.Code
											 select new CustomerListViewModel
											 {
												 Id = cust.Id,
												 BillToNo = cust.BillToNo,
												 BillToName = cust.BillToName,
												 ShipToNo = cust.ShipToNo,
												 ShipToName = cust.ShipToName,
												 CompanyCode = cust.CompanyCode,
												 CompanyName = comp.Name
											 }).ToList();
				return customerListViewModel!;
			}
			catch (Exception ex)
			{
				return new List<CustomerListViewModel>();
			}
		}

		public async Task<Customer> GetByIdAsync(int id)
		{
			var customer = await _dbContext.Customers.FindAsync(id);
			return customer!;
		}

		public async Task UpdateAsync(Customer customer)
		{
			_dbContext.Entry(customer).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
