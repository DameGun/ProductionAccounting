using Microsoft.Extensions.Caching.Distributed;
using ProductionAccounting.Application.Models;
using ProductionAccounting.Application.Services.Interfaces;

namespace ProductionAccounting.Application.Services.Implementations
{
	public class ProductionUnitService : IProductionUnitService
	{
		private readonly IServiceManager _serviceManager;
		private readonly IDistributedCache _cache;

		public ProductionUnitService(IServiceManager serviceManager, IDistributedCache cache)
		{
			_serviceManager = serviceManager;
			_cache = cache;
		}

		public async Task<ActiveProductionResponse> CreateProductionUnitAsync(ActiveProductionRequest activeProductionRequest, bool trackChanges)
		{
			if (activeProductionRequest.CurrentBoxQuantity == 1)
			{
				if(activeProductionRequest.CurrentPalletQuantity == 0)
				{
					var createPalletDTO = await _serviceManager.PalletFactory.CreateAsync();
					var palletResponse = await _serviceManager.PalletService.CreateAsync(createPalletDTO);

					_cache.SetString("currentPalletGuid", palletResponse.Barcode.ToString());
				}

				var createdBoxDTO = await _serviceManager.BoxFactory.CreateAsync();
				var boxResponse = await _serviceManager.BoxService.CreateAsync(createdBoxDTO);

				_cache.SetString("currentBoxGuid", boxResponse.Barcode.ToString());
			}

			var createProductUnitDTO = await _serviceManager.ProductUnitFactory.CreateAsync();
			var productUnitResponse = await _serviceManager.ProductUnitService.CreateAsync(createProductUnitDTO);

			await _serviceManager.ProductionApplicationService.UpdateActiveProductionApplicationAsync();

			return new ActiveProductionResponse {
				TotalBoxes = Convert.ToInt32(await _cache.GetStringAsync("totalBoxes")),
				TotalPallets = Convert.ToInt32(await _cache.GetStringAsync("totalPallets")),
				TotalUnits = Convert.ToInt32(await _cache.GetStringAsync("totalUnits"))
			};
		}
	}
}
