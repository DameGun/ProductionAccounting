using ProductionAccounting.Core.Entities;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class ProductUnitRepository : GenericRepository<ProductUnit, Guid>, IProductUnitRepository
	{
		public ProductUnitRepository(AppDbContext dbContext) : base(dbContext) { }

		public async Task<IEnumerable<ProductUnit>?> GetUnitsByBoxBarcode(Guid boxBarcode)
		{
			return await GetAllByConditionAsync(u => u.BoxBarcode == boxBarcode);
		}
	}
}
