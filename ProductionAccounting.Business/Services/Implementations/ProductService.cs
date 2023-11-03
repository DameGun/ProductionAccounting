using AutoMapper;
using ProductionAccounting.Application.Models;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.Application.Services.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;
		
		public ProductService(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<ProductDTO> CreateAsync(ProductDTO entity)
		{
			var product = _mapper.Map<Product>(entity);
			var dbResponse = await _productRepository.CreateAsync(product);
			var productDTO = _mapper.Map<ProductDTO>(dbResponse);
			return productDTO;
		}

		public async Task<ProductDTO> DeleteAsync(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null)
			{
				throw new ArgumentNullException("Product not found");
			}
			var dbResponse = await _productRepository.DeleteAsync(id);
			var productDTO = _mapper.Map<ProductDTO>(dbResponse);
			return productDTO;
		}

		public async Task<IEnumerable<ProductDTO>> GetAllAsync()
		{
			var products = await _productRepository.GetAllAsync();
			if (products == null)
			{
				throw new ArgumentNullException("Product not found");
			}
			var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
			return productsDTO;
		}

		public async Task<ProductDTO> GetByIdAsync(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null)
			{
				throw new ArgumentNullException("Product not found");
			}
			var productDTO = _mapper.Map<ProductDTO>(product);
			return productDTO;
		}

		public async Task<ProductDTO> UpdateAsync(ProductDTO entity)
		{
			var product = await _productRepository.GetByIdAsync(entity.Id);
			if (product == null)
			{
				throw new ArgumentNullException("Product not found");
			}
			product.Name = entity.Name;
			product.Cost = entity.Cost;
			product.Weight = entity.Weight;

			var dbResponse = _productRepository.UpdateAsync(product);
			var productDTO = _mapper.Map<ProductDTO>(dbResponse);
			return productDTO;
		}
	}
}
