using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.Core.Shared.RequestFeatures;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IProductionApplication : IBaseRepository<ProductionApplication>
	{
		Task<PagedList<ProductionApplication>> GetAllAsync(RequestParameters requestParameters, bool trackChanges);
		Task<PagedList<ProductionApplication>?> GetApplicationsByProductId(int productId, RequestParameters requestParameters, bool trackChanges);
	}
}
