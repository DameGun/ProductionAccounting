using ProductionAccounting.Core.Entities;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class ProductionApplicationRepository : GenericRepository<ProductionApplication, Guid>, IProductionApplication
	{
		public ProductionApplicationRepository(AppDbContext appDbContext) : base(appDbContext) { }

		public async Task<IEnumerable<ProductionApplication>?> GetApplicationsByProductId(int productId)
		{
			return await GetAllByConditionAsync(a => a.ProductId == productId);
		}
	}
}
