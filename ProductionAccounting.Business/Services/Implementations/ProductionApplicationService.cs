using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using ProductionAccounting.Application.Models.ProductionApplication;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Exceptions;
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

		public async Task<IEnumerable<ProductionApplicationDTO>> GetApplicationsByProductIdAsync(int productId, bool trackChanges)
		{
			var product = await _repositoryManager.ProductRepository.FindById(p => p.Id == productId, trackChanges: false);

			var applications = await _repositoryManager.ProductionApplication.GetApplicationsByProductId(productId, trackChanges);
			var applicationsDTO = _mapper.Map<IEnumerable<ProductionApplicationDTO>>(applications);

			return applicationsDTO;
		}

		public async Task<IEnumerable<ProductionApplicationDTO>?> GetAllAsync(bool trackChanges)
		{
			var applications = await _repositoryManager.ProductionApplication.GetAllAsync(trackChanges);
			var applicationDTO = _mapper.Map<IEnumerable<ProductionApplicationDTO>>(applications);
			
			return applicationDTO;
		}

		public async Task<ProductionApplicationDTO?> GetByIdAsync(Guid applicationId, bool trackChanges)
		{
			var application = await _repositoryManager.ProductionApplication.FindById(a => a.Id == applicationId, trackChanges);

			var applicationDTO = _mapper.Map<ProductionApplicationDTO>(application);

			return applicationDTO;
		}

		public async Task<ProductionApplicationDTO> CreateAsync(CreateProductionApplicationDTO productionApplicationDTO, bool trackChanges)
		{
			var product = await _repositoryManager.ProductRepository.FindById(p => p.Id == productionApplicationDTO.ProductId, trackChanges: false);

			var applicationEntity = _mapper.Map<ProductionApplication>(productionApplicationDTO);

			_repositoryManager.ProductionApplication.Create(applicationEntity);
			await _repositoryManager.SaveAsync();

			var applicationResponse = _mapper.Map<ProductionApplicationDTO>(applicationEntity);

			SetApplicationToCache(applicationResponse);

			return applicationResponse;
		}

		private void SetApplicationToCache(ProductionApplicationDTO productionApplicationDTO)
		{
			_cache.SetString("productionApplication", JsonSerializer.Serialize(productionApplicationDTO));
		}

		public async Task<ProductionApplicationDTO> SetApplicationActiveAsync(Guid applicationId, bool trackChanges)
		{
			var application = await _repositoryManager.ProductionApplication.FindById(a => a.Id == applicationId, trackChanges);

			var applicationResponse = _mapper.Map<ProductionApplicationDTO>(application);

			SetApplicationToCache(applicationResponse);

			return applicationResponse;
		}

		public async Task<ProductionApplicationDTO> UpdateAsync(Guid id, UpdateProductionApplicationDTO updateProductionApplicationDTO, bool trackChanges)
		{
			var productionApllication = await _repositoryManager.ProductionApplication.FindById(p => p.Id == id, trackChanges);
			if(productionApllication.CurrentApplicationState != Core.Shared.ApplicationState.Stopped)
			{
				throw new ApplicationStateException();
			}

			var productionApplicationEntity = _mapper.Map<ProductionApplication>(updateProductionApplicationDTO);

			_repositoryManager.ProductionApplication.Update(productionApplicationEntity);
			await _repositoryManager.SaveAsync();

			var productionApplicationResponse = _mapper.Map<ProductionApplicationDTO>(productionApplicationEntity);

			return productionApplicationResponse;
		}

		public async Task<ProductionApplicationDTO> DeleteAsync(Guid id, bool trackChanges)
		{
			var productionApplication = await _repositoryManager.ProductionApplication.FindById(p => p.Id == id, trackChanges);

			_repositoryManager.ProductionApplication.Delete(productionApplication);
			await _repositoryManager.SaveAsync();

			var productionApplicationResponse = _mapper.Map<ProductionApplicationDTO>(productionApplication);

			return productionApplicationResponse;
		}
	}
}
