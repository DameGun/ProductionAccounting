using ProductionAccounting.Application.Models.Category;

namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface ICategoryService
	{
		Task<CategoryDTO> CreateCategoryAsync(CreateCategoryDTO categoryDTO);
		Task<IEnumerable<CategoryDTO>> GetAllAsync();
		Task<CategoryDTO> GetCategoryAsync(int id);
	}
}
