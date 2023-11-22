using ProductionAccounting.Application.Models.ProductionApplication;

namespace ProductionAccounting.Application.Services.Interfaces
{
    public interface IProductionApplicationService
	{
		Task<ProductionApplicationDTO> CreateProductionApplicationAsync(CreateProductionApplicationDTO productionApplicationDTO);
		Task<IEnumerable<ProductionApplicationDTO>> GetAllAsync();
		Task<IEnumerable<ProductionApplicationDTO>> GetApplicationsByProductIdAsync(int productId);
		Task<ProductionApplicationDTO> GetApplicationAsync(Guid applicationId);
		Task<ProductionApplicationDTO> SetApplicationActiveAsync(Guid applicationId);
	}
}
