using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class ProductUnitRepository : GenericRepository<ProductUnit>, IProductUnitRepository
	{
		public ProductUnitRepository(AppDbContext dbContext) : base(dbContext) { }

		public async Task<IEnumerable<ProductUnit>> GetUnitsByBoxBarcode(Guid boxBarcode, bool trackChanges)
		{
			return await FindByCondition(u => u.BoxBarcode == boxBarcode, trackChanges).ToListAsync();
		}
	}
}
