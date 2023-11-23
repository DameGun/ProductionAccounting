using ProductionAccounting.Application.Models.ProductionApplication;

namespace ProductionAccounting.Application.Services.Interfaces
{
    public interface IProductionApplicationService 
	{
		Task<ProductionApplicationDTO> CreateAsync(CreateProductionApplicationDTO createProductionApplicationDTO, bool trackChanges);
		Task<ProductionApplicationDTO> UpdateAsync(Guid id, UpdateProductionApplicationDTO entity, bool trackChanges);
		Task<ProductionApplicationDTO> DeleteAsync(Guid id, bool trackChanges);
		Task<ProductionApplicationDTO?> GetByIdAsync(Guid id, bool trackChanges);
		Task<IEnumerable<ProductionApplicationDTO>?> GetAllAsync(bool trackChanges);
		Task<IEnumerable<ProductionApplicationDTO>> GetApplicationsByProductIdAsync(int productId, bool trackChanges);
		Task<ProductionApplicationDTO> SetApplicationActiveAsync(Guid applicationId, bool trackChanges);
	}
}
