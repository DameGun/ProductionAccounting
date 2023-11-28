using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.Core.Shared.RequestFeatures;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(AppDbContext appDbContext) : base(appDbContext) { }

		public async Task<PagedList<Product>> GetAllAsync(RequestParameters requestParameters, bool trackChanges)
		{
			var products = await FindAll(trackChanges).ToListAsync();

			return PagedList<Product>.ToPagingResponse(products, requestParameters.PageNumber, requestParameters.PageSize);
		}

		public async Task<PagedList<Product>> GetProductsByCategoryAsync(int categoryId, RequestParameters requestParameters, bool trackChanges)
		{
			var products = await FindByCondition(p => p.CategoryId == categoryId, trackChanges).ToListAsync();

			return PagedList<Product>.ToPagingResponse(products, requestParameters.PageNumber, requestParameters.PageSize);
		}
	}
}
