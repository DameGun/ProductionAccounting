using Microsoft.AspNetCore.Mvc;
using ProductionAccounting.Application.Models;
using ProductionAccounting.Application.Services.Interfaces;

namespace ProductionAccounting.Api.Controllers
{
	[Route("api/productUnits")]
	[ApiController]
	public class ActiveProductionController : ControllerBase
	{
		private readonly IServiceManager _serviceManager;

		public ActiveProductionController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpPost]
		public async Task<IActionResult> CreateProductUnitAsync([FromBody]ActiveProductionRequest activeProductionRequest)
		{
			var response = await _serviceManager.ProductionUnitService.CreateProductionUnitAsync(activeProductionRequest, true);

			return Ok(response);
		}
	}
}
