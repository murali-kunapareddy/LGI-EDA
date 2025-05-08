using Microsoft.EntityFrameworkCore;

using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;
using WISSEN.EDA.Models.ViewModels;

namespace WISSEN.EDA.Repositories.Implementations
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDBContext _context;

		public OrderRepository(AppDBContext Context)
		{
			_context = Context;
		}

        public async Task<string> AddAsync(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return "success";
            }
            catch (Exception ex)
            {
                return $"error:{ex.Message}";
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderListViewModel>> GetAllAsync()
        {
            try
            {
                return await _context.Orders
                    .Include(c => c.Customer)
                    .Select(o => new OrderListViewModel
                    {
                        Id = o.Id,
                        CustomerPONo = o.CustomerPONo,
                        ContractNo = o.ContractNo,
                        ShipToName = o.Customer != null ? o.Customer.ShipToName : string.Empty,
                        BillToName = o.Customer != null ? o.Customer.BillToName : string.Empty,
                        OrderDate = o.OrderDate != default(DateTime) ? DateOnly.FromDateTime(o.OrderDate) : default(DateOnly),
                        SubmitDate = o.CreatedOn != default(DateTime) ? DateOnly.FromDateTime(o.CreatedOn) : default(DateOnly), // Fixed issue here
                        Status = "STATUS",
                        IsActive = o.IsActive
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<OrderListViewModel>();
            }
        }

        public Task<Order> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
