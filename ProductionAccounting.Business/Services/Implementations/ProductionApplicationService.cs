using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using ProductionAccounting.Application.Models;
using ProductionAccounting.Application.Models.ProductionApplication;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Exceptions;
using ProductionAccounting.Core.Shared;
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

		public async Task<PagedResponse<ProductionApplicationDTO>> GetApplicationsByProductIdAsync(int productId, 
			RequestParameters requestParameters, bool trackChanges)
		{
			var product = await _repositoryManager.ProductRepository.FindById(p => p.Id == productId, trackChanges: false);

			var applicationsWithMetaData = await _repositoryManager.ProductionApplication
				.GetApplicationsByProductId(productId, requestParameters, trackChanges);
			var applicationsDTO = _mapper.Map<IEnumerable<ProductionApplicationDTO>>(applicationsWithMetaData);

			return new PagedResponse<ProductionApplicationDTO> { 
				Data = applicationsDTO,
				MetaData = applicationsWithMetaData.MetaData
			};
		}

		public async Task<PagedResponse<ProductionApplicationDTO>> GetAllAsync(RequestParameters requestParameters, bool trackChanges)
		{
			var applicationsWithMetaData = await _repositoryManager.ProductionApplication.GetAllAsync(requestParameters, trackChanges);
			var applicationDTO = _mapper.Map<IEnumerable<ProductionApplicationDTO>>(applicationsWithMetaData);

			return new PagedResponse<ProductionApplicationDTO>
			{
				Data = applicationDTO,
				MetaData = applicationsWithMetaData.MetaData
			};
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

		private void SetCountersToCache(ProductionApplicationDTO productionApplicationDTO)
		{
			_cache.SetString("totalBoxes", productionApplicationDTO.TotalBoxes.ToString());
			_cache.SetString("totalUnits", productionApplicationDTO.TotalUnits.ToString());
			_cache.SetString("totalPallets", productionApplicationDTO.TotalPallets.ToString());
		}

		private void SetBoxAndPalletGuidToCache(ProductionApplication productionApplication)
		{
			_cache.SetString("currentBoxGuid", productionApplication.LastBoxGuid.ToString());
			_cache.SetString("currentPalletGuid", productionApplication.LastPalletGuid.ToString());
		}

		public async Task<ProductionApplicationDTO> SetApplicationActiveAsync(Guid applicationId, bool trackChanges)
		{
			var application = await _repositoryManager.ProductionApplication.FindById(a => a.Id == applicationId, trackChanges);

			SetBoxAndPalletGuidToCache(application);

			var applicationResponse = _mapper.Map<ProductionApplicationDTO>(application);

			SetApplicationToCache(applicationResponse);

			SetCountersToCache(applicationResponse);

			return applicationResponse;
		}

		public async Task<ProductionApplicationDTO> UpdateActiveProductionApplicationAsync()
		{
			var productionApplicationJson = await _cache.GetStringAsync("productionApplication");
			var productionApplication = JsonSerializer.Deserialize<ProductionApplicationDTO>(productionApplicationJson);

			var updateProductionApplication = new ServerUpdateApplicationDTO
			{
				Id = productionApplication.Id,
				ProductId = productionApplication.Product.Id,
				PackagesInBox = productionApplication.PackagesInBoxMax,
				BoxesInPallet = productionApplication.BoxesInPalletMax,
				TotalUnits = Convert.ToInt32(await _cache.GetStringAsync("totalUnits")),
				TotalBoxes = Convert.ToInt32(await _cache.GetStringAsync("totalBoxes")),
				TotalPallets = Convert.ToInt32(await _cache.GetStringAsync("totalPallets")),
				LastBoxGuid = new Guid(await _cache.GetStringAsync("currentBoxGuid")),
				LastPalletGuid = new Guid(await _cache.GetStringAsync("currentPalletGuid")),
				ProdDate = productionApplication.ProdDate.ToUniversalTime(),
				ExpDate = productionApplication.ExpDate.ToUniversalTime(),
				CurrentApplicationState = ((int)productionApplication.CurrentApplicationState)
			};

			var productionApplicationEntity = _mapper.Map<ProductionApplication>(updateProductionApplication);

			_repositoryManager.ProductionApplication.Update(productionApplicationEntity);
			await _repositoryManager.SaveAsync();

			var productionApplicationDb = await _repositoryManager.ProductionApplication
				.FindById(a => a.Id == productionApplicationEntity.Id, trackChanges: false);

			var productionApplicationResponse = _mapper.Map<ProductionApplicationDTO>(productionApplicationDb);

			SetApplicationToCache(productionApplicationResponse);

			return productionApplicationResponse;
		}

		public async Task<ProductionApplicationDTO> UpdateAsync(Guid id, UpdateProductionApplicationDTO updateProductionApplicationDTO, bool trackChanges)
		{
			var productionApllication = await _repositoryManager.ProductionApplication.FindById(p => p.Id == id, trackChanges);
			//if(productionApllication.CurrentApplicationState != Core.Shared.ApplicationState.Stopped)
			//{
			//	throw new ApplicationStateException();
			//}

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
