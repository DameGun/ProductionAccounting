using Microsoft.AspNetCore.Mvc;
using ProductionAccounting.Application.Services.Interfaces;

namespace ProductionAccounting.Api.Controllers
{
	[Route("api/productUnits")]
	[ApiController]
	public class ProductUnitController : ControllerBase
	{
		private readonly IServiceManager _serviceManager;

		public ProductUnitController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[Route("{id:guid}")]
		[HttpGet]
		public async Task<IActionResult> GetProductUnitAsync(Guid id)
		{
			var productUnit = await _serviceManager.ProductUnitService.GetByIdAsync(id, trackChanges: false);
			return Ok(productUnit);
		}
	}
}
