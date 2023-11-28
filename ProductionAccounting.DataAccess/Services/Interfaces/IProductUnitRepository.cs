using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.Core.Shared.RequestFeatures;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IProductUnitRepository : IBaseRepository<ProductUnit>
	{
		Task<PagedList<ProductUnit>> GetUnitsByBoxBarcode(Guid boxBarcode, RequestParameters requestParameters, bool trackChanges);
	}
}
