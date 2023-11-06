using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class ProductRepository : GenericRepository<Product, int>, IProductRepository
	{
		public ProductRepository(AppDbContext appDbContext) : base(appDbContext) { }

		public async Task<IEnumerable<Product>?> GetProductsByCategory(int categoryId)
		{
			return await GetAllByConditionAsync(p => p.CategoryId == categoryId);
		}
	}
}
