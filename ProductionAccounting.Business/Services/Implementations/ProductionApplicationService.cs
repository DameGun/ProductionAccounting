using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using ProductionAccounting.Application.Models.ProductionApplication;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.DataAccess.Services.Interfaces;
using System.Text.Json;

namespace ProductionAccounting.Application.Services.Implementations
{
    public class ProductionApplicationService : IProductionApplicationService
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IDistributedCache _cache;

		public ProductionApplicationService(IRepositoryManager repositoryManager, IMapper mapper, IDistributedCache cache)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_cache = cache;
		}

		public async Task<IEnumerable<ProductionApplicationDTO>> GetApplicationsByProductIdAsync(int productId)
		{
			var product = await _repositoryManager.ProductRepository.GetByIdAsync(productId);

			var applications = await _repositoryManager.ProductionApplication.GetApplicationsByProductId(productId);
			var applicationsDTO = _mapper.Map<IEnumerable<ProductionApplicationDTO>>(applications);

			return applicationsDTO;
		}

		public async Task<IEnumerable<ProductionApplicationDTO>> GetAllAsync()
		{
			var applications = await _repositoryManager.ProductionApplication.GetAllAsync();
			var applicationDTO = _mapper.Map<IEnumerable<ProductionApplicationDTO>>(applications);
			
			return applicationDTO;
		}

		public async Task<ProductionApplicationDTO> GetApplicationAsync(Guid applicationId)
		{
			var application = await _repositoryManager.ProductionApplication.GetByIdAsync(applicationId);

			var applicationDTO = _mapper.Map<ProductionApplicationDTO>(application);

			return applicationDTO;
		}

		public async Task<ProductionApplicationDTO> CreateProductionApplicationAsync(CreateProductionApplicationDTO productionApplicationDTO)
		{
			var product = await _repositoryManager.ProductRepository.GetByIdAsync(productionApplicationDTO.ProductId);

			var applicationEntity = _mapper.Map<ProductionApplication>(productionApplicationDTO);
			var dbResponse = await _repositoryManager.ProductionApplication.CreateAsync(applicationEntity);

			var applicationResponse = _mapper.Map<ProductionApplicationDTO>(dbResponse);

			_cache.SetString("productionApplication", JsonSerializer.Serialize(applicationResponse));

			return applicationResponse;
		}

		public async Task<ProductionApplicationDTO> SetApplicationActiveAsync(Guid applicationId)
		{
			var application= await _repositoryManager.ProductionApplication.GetByIdAsync(applicationId);

			var applicationResponse = _mapper.Map<ProductionApplicationDTO>(application);

			_cache.SetString("productionApplication", JsonSerializer.Serialize(applicationResponse));

			return applicationResponse;
		}
	}
}
