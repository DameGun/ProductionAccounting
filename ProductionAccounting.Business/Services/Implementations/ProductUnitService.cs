using AutoMapper;
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
			var product = await _repositoryManager.ProductRepository.FindById(p => p.Id == createProductUnitDTO.ProductId, trackChanges: false);

			var productUnitEntity = _mapper.Map<ProductUnit>(createProductUnitDTO);

			_repositoryManager.ProductUnitRepository.Create(productUnitEntity);
			await _repositoryManager.SaveAsync();

			var productUnitResponse = _mapper.Map<ProductUnitDTO>(productUnitEntity);

			return productUnitResponse;
		}

		public async Task<ProductUnitDTO> GetByIdAsync(Guid id, bool trackChanges)
		{
			var productUnit = await _repositoryManager.ProductUnitRepository.FindById(p => p.Serial == id, trackChanges);

			var productUnitDTO = _mapper.Map<ProductUnitDTO>(productUnit);

			return productUnitDTO;
		}

		public async Task<IEnumerable<ProductUnitDTO>?> GetProductUnitsByBoxIdAsync(Guid boxId, bool boxTrackChanges, bool unitsTrackChanges)
		{
			var box = await _repositoryManager.BoxRepository.FindById(b => b.Barcode == boxId, boxTrackChanges);

			var productUnits = await _repositoryManager.ProductUnitRepository.GetUnitsByBoxBarcode(boxId, unitsTrackChanges);

			var productUnitsResponse = _mapper.Map<IEnumerable<ProductUnitDTO>>(productUnits);

			return productUnitsResponse;
		}
	}
}
