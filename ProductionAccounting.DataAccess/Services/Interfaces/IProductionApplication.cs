using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IProductionApplication : IBaseRepository<ProductionApplication>
	{
		Task<IEnumerable<ProductionApplication>> GetAllAsync(bool trackChanges);
		Task<IEnumerable<ProductionApplication>?> GetApplicationsByProductId(int productId, bool trackChanges);
	}
}
