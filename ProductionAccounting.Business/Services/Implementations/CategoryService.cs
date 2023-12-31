﻿using AutoMapper;
using ProductionAccounting.Application.Models;
using ProductionAccounting.Application.Models.Category;
using ProductionAccounting.Application.Models.Product;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.Core.Shared;
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

		public async Task<PagedResponse<CategoryDTO>> GetAllAsync(RequestParameters requestParameters, bool trackChanges)
		{
			var categoriesWithMetaData = await _repository.CategoryRepository.GetAllAsync(requestParameters, trackChanges);
			var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categoriesWithMetaData);

			return new PagedResponse<CategoryDTO> { 
				Data = categoriesDTO,
				MetaData = categoriesWithMetaData.MetaData
			} ;
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

			var categoryEntity = _mapper.Map<Category>(updateCategoryDTO);

			_repository.CategoryRepository.Update(categoryEntity);
			await _repository.SaveAsync();

			var categoryResponse = _mapper.Map<CategoryDTO>(category);

			return categoryResponse;
		}
	}
}
