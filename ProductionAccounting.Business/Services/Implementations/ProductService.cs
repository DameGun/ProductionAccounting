using AutoMapper;
using ProductionAccounting.Application.Models.Product;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.Core.Exceptions;
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

		public async Task<ProductDTO> CreateProductAsync(CreateProductDTO productDTO)
		{
			var category = await _repository.CategoryRepository.GetByIdAsync(productDTO.CategoryId);
			if (category == null) throw new NotFoundException();

			var productEntity = _mapper.Map<Product>(productDTO);
			var dbResponse = await _repository.ProductRepository.CreateAsync(productEntity);

			var productResponse = _mapper.Map<ProductDTO>(dbResponse);

			return productResponse;
		}

		public async Task<IEnumerable<ProductDTO>> GetAllAsync()
		{
			var products = await _repository.ProductRepository.GetAllAsync();
			var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);

			return productsDTO;
		}

		public async Task<ProductDTO> GetProductAsync(int productId)
		{
			var product = await _repository.ProductRepository.GetByIdAsync(productId);
			if (product == null) throw new NotFoundException();

			var productDTO = _mapper.Map<ProductDTO>(product);

			return productDTO;
		}

		public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryId(int categoryId)
		{

			var category = await _repository.CategoryRepository.GetByIdAsync(categoryId);
			if(category == null) throw new NotFoundException();

			var products = await _repository.ProductRepository.GetAllByConditionAsync(p => p.CategoryId == categoryId);

			var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);

			return productsDTO;
		}
	}
}
