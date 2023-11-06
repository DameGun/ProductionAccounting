using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IProductionApplication : IBaseRepository<ProductionApplication, Guid>
	{
		Task<IEnumerable<ProductionApplication>?> GetApplicationsByProductId(int productId);
	}
}
