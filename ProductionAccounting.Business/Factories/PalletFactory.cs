using Microsoft.Extensions.Caching.Distributed;
using ProductionAccounting.Application.Models.Pallet;
using ProductionAccounting.Application.Models.ProductionApplication;
using System.Text.Json;

namespace ProductionAccounting.Application.Factories
{
	public class PalletFactory : IFactory<CreatePalletDTO>
	{
		private readonly IDistributedCache _cache;

		public PalletFactory(IDistributedCache cache)
		{
			_cache = cache;
		}

		public async Task<CreatePalletDTO> CreateAsync(params object[] parameters)
		{
			var productionApplicationJson = await _cache.GetStringAsync("productionApplication");
			var productionApplication = JsonSerializer.Deserialize<ProductionApplicationDTO>(productionApplicationJson);

			CreatePalletDTO createPalletDTO = new CreatePalletDTO
			{
				Weight = (productionApplication.Product.Weight * productionApplication.PackagesInBoxMax) * productionApplication.BoxesInPalletMax,
				Boxes = productionApplication.BoxesInPalletMax,
				ApplicationId = productionApplication.Id
			};

			return createPalletDTO;
		}
	}
}
