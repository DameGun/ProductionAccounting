using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class ProductionApplicationRepository : GenericRepository<ProductionApplication>, IProductionApplication
	{
		public ProductionApplicationRepository(AppDbContext appDbContext) : base(appDbContext) { }

		public async Task<IEnumerable<ProductionApplication>> GetAllAsync(bool trackChanges)
		{
			return await FindAll(trackChanges).ToListAsync();
		}

		public async Task<IEnumerable<ProductionApplication>?> GetApplicationsByProductId(int productId, bool trackChanges)
		{
			return await FindByCondition(a => a.ProductId == productId, trackChanges).ToListAsync();
		}
	}
}
