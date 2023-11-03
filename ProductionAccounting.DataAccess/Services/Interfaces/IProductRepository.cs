using ProductionAccounting.Core.Aggregations;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IProductRepository : IBaseRepository<Product, int>
	{
		Task<IEnumerable<Product>?> GetAllAsync();
	}
}
