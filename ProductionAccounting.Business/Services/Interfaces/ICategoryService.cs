using ProductionAccounting.Application.Models;
using ProductionAccounting.Application.Models.Category;
using ProductionAccounting.Core.Shared;

namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface ICategoryService
	{
		Task<CategoryDTO> CreateAsync(CreateCategoryDTO createCategoryDTO);
		Task<CategoryDTO> UpdateAsync(int id, UpdateCategoryDTO updateCategoryDTO, bool trackChanges);
		Task<CategoryDTO> DeleteAsync(int id, bool trackChanges);
		Task<CategoryDTO?> GetByIdAsync(int id, bool trackChanges);
		Task<PagedResponse<CategoryDTO>> GetAllAsync(RequestParameters requestParameters, bool trackChanges);
	}
}
