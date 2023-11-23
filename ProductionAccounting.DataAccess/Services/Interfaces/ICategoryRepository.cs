using ProductionAccounting.Core.Aggregations;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface ICategoryRepository : IBaseRepository<Category>
	{
		Task<IEnumerable<Category>> GetAllAsync(bool trackChanges);
	}
}
