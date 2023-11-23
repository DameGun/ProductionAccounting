using ProductionAccounting.Core.Aggregations;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		Task<IEnumerable<Product>> GetAllAsync(bool trackChanges);
		Task<IEnumerable<Product>?> GetProductsByCategoryAsync(int categoryId, bool trackChanges);
	}
}
