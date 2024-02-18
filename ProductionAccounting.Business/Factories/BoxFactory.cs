using Microsoft.Extensions.Caching.Distributed;
using ProductionAccounting.Application.Models.Box;
using ProductionAccounting.Application.Models.ProductionApplication;
using System.Text.Json;

namespace ProductionAccounting.Application.Factories
{
	public class BoxFactory : IFactory<CreateBoxDTO>
	{
		private readonly IDistributedCache _cache;

		public BoxFactory(IDistributedCache cache)
		{
			_cache = cache;
		}

		public async Task<CreateBoxDTO> CreateAsync(params object[] parameters)
		{
			var productionApplicationJson = await _cache.GetStringAsync("productionApplication");
			var productionApplication = JsonSerializer.Deserialize<ProductionApplicationDTO>(productionApplicationJson);

			var currentPalletGuid = await _cache.GetStringAsync("currentPalletGuid");

			CreateBoxDTO createBoxDTO = new CreateBoxDTO
			{
				Weight = productionApplication.Product.Weight * productionApplication.PackagesInBoxMax,
				Packages = productionApplication.PackagesInBoxMax,
				PalletBarcode = new Guid(currentPalletGuid),
				ApplicationId = productionApplication.Id
			};

			var totalBoxes = Convert.ToInt32(await _cache.GetStringAsync("totalBoxes"));

			await _cache.SetStringAsync("totalBoxes", (++totalBoxes).ToString());

			return createBoxDTO;
		}
	}
}
