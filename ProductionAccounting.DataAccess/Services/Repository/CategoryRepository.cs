using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.Core.Shared.RequestFeatures;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(AppDbContext dbContext) : base(dbContext) { }

		public async Task<PagedList<Category>> GetAllAsync(RequestParameters requestParameters, bool trackChanges)
		{
			var categories = await FindAll(trackChanges).ToListAsync();

			return PagedList<Category>.ToPagingResponse(categories, requestParameters.PageNumber, requestParameters.PageSize);
		}
	}
}
