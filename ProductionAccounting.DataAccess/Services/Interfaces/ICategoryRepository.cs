using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.Core.Shared.RequestFeatures;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface ICategoryRepository : IBaseRepository<Category>
	{
		Task<PagedList<Category>> GetAllAsync(RequestParameters requestParameters, bool trackChanges);
	}
}
