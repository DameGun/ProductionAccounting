using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class ProductRepository : GenericRepository<Product, int>, IProductRepository
	{
		private AppDbContext _appDbContext;

		public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<IEnumerable<Product>?> GetAllAsync()
		{
			var products = await _appDbContext.Products.ToListAsync();
			return products;
		}
	}
}
