using AutoMapper;
using ProductionAccounting.Application.Models.Category;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.Application.Services.Implementations
{
	public class CategoryService : ICategoryService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;

		public CategoryService(IRepositoryManager repository, IMapper mapper)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<CategoryDTO> CreateAsync(CreateCategoryDTO categoryDTO)
		{
			var categoryEntity = _mapper.Map<Category>(categoryDTO);

			_repository.CategoryRepository.Create(categoryEntity);
			await _repository.SaveAsync();

			var productResponse = _mapper.Map<CategoryDTO>(categoryEntity);
			return productResponse;
		}

		public async Task<CategoryDTO> DeleteAsync(int id, bool trackChanges)
		{
			var category = await _repository.CategoryRepository.FindById(c => c.Id == id, trackChanges);

			_repository.CategoryRepository.Delete(category);
			await _repository.SaveAsync();

			var categoryResponse = _mapper.Map<CategoryDTO>(category);

			return categoryResponse;
		}

		public async Task<IEnumerable<CategoryDTO>?> GetAllAsync(bool trackChanges)
		{
			var categories = await _repository.CategoryRepository.GetAllAsync(trackChanges);
			var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

			return categoriesDTO;
		}

		public async Task<CategoryDTO?> GetByIdAsync(int id, bool trackChanges)
		{
			var category = await _repository.CategoryRepository.FindById(c => c.Id == id, trackChanges);

			var categoryDTO = _mapper.Map<CategoryDTO>(category);
			return categoryDTO;
		}

		public async Task<CategoryDTO> UpdateAsync(int id, UpdateCategoryDTO updateCategoryDTO, bool trackChanges)
		{
			var category = await _repository.CategoryRepository.FindById(c => c.Id == id, trackChanges);

			_repository.CategoryRepository.Update(category);
			await _repository.SaveAsync();

			var categoryResponse = _mapper.Map<CategoryDTO>(category);

			return categoryResponse;
		}
	}
}
