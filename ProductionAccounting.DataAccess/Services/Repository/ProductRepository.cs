using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(AppDbContext appDbContext) : base(appDbContext) { }

		public async Task<IEnumerable<Product>> GetAllAsync(bool trackChanges)
		{
			return await FindAll(trackChanges).ToListAsync();
		}

		public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId, bool trackChanges)
		{
			return await FindByCondition(p => p.CategoryId == categoryId, trackChanges).ToListAsync();
		}
	}
}
