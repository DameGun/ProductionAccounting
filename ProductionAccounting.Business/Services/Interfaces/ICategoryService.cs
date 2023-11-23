using ProductionAccounting.Application.Models.Category;

namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface ICategoryService
	{
		Task<CategoryDTO> CreateAsync(CreateCategoryDTO createCategoryDTO);
		Task<CategoryDTO> UpdateAsync(int id, UpdateCategoryDTO updateCategoryDTO, bool trackChanges);
		Task<CategoryDTO> DeleteAsync(int id, bool trackChanges);
		Task<CategoryDTO?> GetByIdAsync(int id, bool trackChanges);
		Task<IEnumerable<CategoryDTO>?> GetAllAsync(bool trackChanges);
	}
}
