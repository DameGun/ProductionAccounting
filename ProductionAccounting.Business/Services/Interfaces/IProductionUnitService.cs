using ProductionAccounting.Application.Models;

namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface IProductionUnitService
	{
		public Task<ActiveProductionResponse> CreateProductionUnitAsync(ActiveProductionRequest request);
	}
}
