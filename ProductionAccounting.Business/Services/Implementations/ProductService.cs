using AutoMapper;
using ProductionAccounting.Application.Models;
using ProductionAccounting.Application.Models.Product;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.Application.Services.Implementations
{
    public class ProductService : IProductService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;
		
		public ProductService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<ProductDTO> CreateAsync(CreateProductDTO productDTO)
		{
			var category = await _repository.CategoryRepository.FindById(c => c.Id == productDTO.CategoryId, trackChanges: false);

			var productEntity = _mapper.Map<Product>(productDTO);

			_repository.ProductRepository.Create(productEntity);
			await _repository.SaveAsync();

			var productResponse = _mapper.Map<ProductDTO>(productEntity);

			return productResponse;
		}

		public async Task<ProductDTO> DeleteAsync(int id, bool trackChanges)
		{
			var product = await _repository.ProductRepository.FindById(p => p.Id == id, trackChanges);

			_repository.ProductRepository.Delete(product);
			await _repository.SaveAsync();

			var productResponse = _mapper.Map<ProductDTO>(product);

			return productResponse;
		}

		public async Task<PagedResponse<ProductDTO>> GetAllAsync(RequestParameters requestParameters, bool trackChanges)
		{
			var productsWithMetaData = await _repository.ProductRepository.GetAllAsync(requestParameters, trackChanges);
			var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(productsWithMetaData);

			return new PagedResponse<ProductDTO>
			{
				Data = productsDTO,
				MetaData = productsWithMetaData.MetaData
			};
		}

		public async Task<ProductDTO> GetByIdAsync(int productId, bool trackChanges)
		{
			var product = await _repository.ProductRepository.FindById(p => p.Id == productId, trackChanges);

			var productDTO = _mapper.Map<ProductDTO>(product);

			return productDTO;
		}

		public async Task<PagedResponse<ProductDTO>> GetProductsByCategoryId(int categoryId, 
			RequestParameters requestParameters, bool categoryTrackChanges, bool productsTrackChanges)
		{

			var category = await _repository.CategoryRepository.FindById(c => c.Id == categoryId, categoryTrackChanges);

			var productsWithMetaData = await _repository.ProductRepository.GetProductsByCategoryAsync(categoryId, requestParameters, productsTrackChanges);

			var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(productsWithMetaData);

			return new PagedResponse<ProductDTO>
			{
				Data = productsDTO,
				MetaData = productsWithMetaData.MetaData
			};
		}

		public async Task<ProductDTO> UpdateAsync(int id, UpdateProductDTO entity, bool trackChanges)
		{
			var product = await _repository.ProductRepository.FindById(p => p.Id == id, trackChanges);

			var productEntity = _mapper.Map<Product>(product);

			_repository.ProductRepository.Update(productEntity);
			await _repository.SaveAsync();

			var productResponse = _mapper.Map<ProductDTO>(product);

			return productResponse;
		}
	}
}
