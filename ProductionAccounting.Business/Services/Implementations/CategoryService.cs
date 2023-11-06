using AutoMapper;
using ProductionAccounting.Application.Models.Category;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.Core.Exceptions;
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

		public async Task<CategoryDTO> CreateCategoryAsync(CreateCategoryDTO categoryDTO)
		{
			var categoryEntity = _mapper.Map<Category>(categoryDTO);

			var dbResponse = await _repository.CategoryRepository.CreateAsync(categoryEntity);

			var productResponse = _mapper.Map<CategoryDTO>(dbResponse);

			return productResponse;
		}

		public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
		{
			var categories = await _repository.CategoryRepository.GetAllAsync();
			var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

			return categoriesDTO;
		}

		public async Task<CategoryDTO> GetCategoryAsync(int id)
		{
			var category = await _repository.CategoryRepository.GetByIdAsync(id);
			if (category == null) throw new NotFoundException();

			var categoryDTO = _mapper.Map<CategoryDTO>(category);
			
			return categoryDTO;
		}
	}
}
