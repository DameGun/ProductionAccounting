using ProductionAccounting.Application.Models;
using ProductionAccounting.Application.Models.ProductionApplication;
using ProductionAccounting.Core.Shared;

namespace ProductionAccounting.Application.Services.Interfaces
{
    public interface IProductionApplicationService 
	{
		Task<ProductionApplicationDTO> CreateAsync(CreateProductionApplicationDTO createProductionApplicationDTO, bool trackChanges);
		Task<ProductionApplicationDTO> UpdateAsync(Guid id, UpdateProductionApplicationDTO entity, bool trackChanges);
		Task<ProductionApplicationDTO> DeleteAsync(Guid id, bool trackChanges);
		Task<ProductionApplicationDTO?> GetByIdAsync(Guid id, bool trackChanges);
		Task<PagedResponse<ProductionApplicationDTO>> GetAllAsync(RequestParameters requestParameters, bool trackChanges);
		Task<PagedResponse<ProductionApplicationDTO>> GetApplicationsByProductIdAsync(int productId, 
			RequestParameters requestParameters, bool trackChanges);
		Task<ProductionApplicationDTO> SetApplicationActiveAsync(Guid applicationId, bool trackChanges);
	}
}
