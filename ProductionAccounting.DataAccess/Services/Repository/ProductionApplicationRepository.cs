using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.Core.Shared.RequestFeatures;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class ProductionApplicationRepository : GenericRepository<ProductionApplication>, IProductionApplication
	{
		public ProductionApplicationRepository(AppDbContext appDbContext) : base(appDbContext) { }

		public async Task<PagedList<ProductionApplication>> GetAllAsync(RequestParameters requestParameters, bool trackChanges)
		{
			var applications = await FindAll(trackChanges).ToListAsync();

			return PagedList<ProductionApplication>.ToPagingResponse(applications, requestParameters.PageNumber, requestParameters.PageSize);
		}

		public async Task<PagedList<ProductionApplication>> GetApplicationsByProductId(int productId, 
			RequestParameters requestParameters, bool trackChanges)
		{
			var applications = await FindByCondition(a => a.ProductId == productId, trackChanges).ToListAsync();

			return PagedList<ProductionApplication>.ToPagingResponse(applications, requestParameters.PageNumber, requestParameters.PageSize);
		}
	}
}
