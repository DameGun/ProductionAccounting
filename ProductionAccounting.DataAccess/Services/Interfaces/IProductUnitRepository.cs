using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IProductUnitRepository : IBaseRepository<ProductUnit>
	{
		Task<IEnumerable<ProductUnit>> GetUnitsByBoxBarcode(Guid boxBarcode, bool trackChanges);
	}
}
