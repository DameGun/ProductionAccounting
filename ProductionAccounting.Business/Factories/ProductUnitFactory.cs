﻿using Microsoft.Extensions.Caching.Distributed;
using ProductionAccounting.Application.Models.ProductionApplication;
using ProductionAccounting.Application.Models.ProductUnit;
using System.Text.Json;

namespace ProductionAccounting.Application.Factories
{
	public class ProductUnitFactory : IFactory<CreateProductUnitDTO>
	{
		private readonly IDistributedCache _cache;

		public ProductUnitFactory(IDistributedCache cache)
		{
			_cache = cache;
		}

		public async Task<CreateProductUnitDTO> CreateAsync(params object[] parameters)
		{
			var productionApplicationJson = await _cache.GetStringAsync("productionApplication");
			var productionApplication = JsonSerializer.Deserialize<ProductionApplicationDTO>(productionApplicationJson);

			var currentBoxGuid = await _cache.GetStringAsync("currentBoxGuid");

			CreateProductUnitDTO createProductUnitDTO = new CreateProductUnitDTO
			{
				ProductId = productionApplication.Product.Id,
				Date = productionApplication.ProdDate,
				Expire = productionApplication.ExpDate,
				BoxBarcode = new Guid(currentBoxGuid)
			};

			return createProductUnitDTO;
		}
	}
}
