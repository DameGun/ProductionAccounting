using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.Core.Shared.RequestFeatures;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class ProductUnitRepository : GenericRepository<ProductUnit>, IProductUnitRepository
	{
		public ProductUnitRepository(AppDbContext dbContext) : base(dbContext) { }

		public async Task<PagedList<ProductUnit>> GetUnitsByBoxBarcode(Guid boxBarcode, RequestParameters requestParameters, bool trackChanges)
		{
			var units = await FindByCondition(u => u.BoxBarcode == boxBarcode, trackChanges).ToListAsync();

			return PagedList<ProductUnit>.ToPagingResponse(units, requestParameters.PageNumber, requestParameters.PageSize);
		}
	}
}
