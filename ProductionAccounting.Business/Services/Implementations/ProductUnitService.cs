using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using ProductionAccounting.Application.Models.ProductUnit;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.Application.Services.Implementations
{
	public class ProductUnitService : IProductUnitService
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public ProductUnitService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<ProductUnitDTO> CreateAsync(CreateProductUnitDTO createProductUnitDTO)
		{
			var product = await _repositoryManager.ProductRepository.GetByIdAsync(createProductUnitDTO.ProductId);

			var productUnitEntity = _mapper.Map<ProductUnit>(createProductUnitDTO);

			var dbResponse = await _repositoryManager.ProductUnitRepository.CreateAsync(productUnitEntity);

			var productUnitResponse = _mapper.Map<ProductUnitDTO>(dbResponse);

			return productUnitResponse;
		}

		public Task<ProductUnitDTO> DeleteAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ProductUnitDTO>?> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<ProductUnitDTO?> GetByIdAsync(Guid id)
		{
			var productUnit = await _repositoryManager.ProductUnitRepository.GetByIdAsync(id);

			var productUnitDTO = _mapper.Map<ProductUnitDTO>(productUnit);

			return productUnitDTO;
		}

		public Task<ProductUnitDTO> UpdateAsync(ProductUnitDTO entity)
		{
			throw new NotImplementedException();
		}
	}
}
