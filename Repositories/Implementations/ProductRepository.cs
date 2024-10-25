using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Repositories.Implementations
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDBContext _dbContext;

		public ProductRepository(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(Product product)
		{
			await _dbContext.Products.AddAsync(product);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var product = await _dbContext.Products.FindAsync(id, false);
			if (product != null)
			{
				_dbContext.Products.Remove(product);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<List<Product>> GetAllAsync()
		{
			var products = await _dbContext.Products.ToListAsync();
			return products;
		}

		public async Task<Product> GetByIdAsync(int id)
		{
			var products = await _dbContext.Products.FindAsync(id);
			return products!;
		}

		public async Task UpdateAsync(Product product)
		{
			_dbContext.Entry(product).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
