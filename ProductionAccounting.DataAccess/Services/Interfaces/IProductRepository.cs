using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.Core.Shared.RequestFeatures;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		Task<PagedList<Product>> GetAllAsync(RequestParameters requestParameters, bool trackChanges);
		Task<PagedList<Product>> GetProductsByCategoryAsync(int categoryId, RequestParameters requestParameters,bool trackChanges);
	}
}
