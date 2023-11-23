using Microsoft.AspNetCore.Mvc;
using ProductionAccounting.Application.Models.Box;
using ProductionAccounting.Application.Services.Interfaces;

namespace ProductionAccounting.Api.Controllers
{
	[Route("api/boxes")]
	[ApiController]
	public class BoxController : ControllerBase
	{
		private readonly IServiceManager _serviceManager;

		public BoxController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[Route("{id:guid}")]
		[HttpGet]
		public async Task<IActionResult> GetBoxAsync(Guid id)
		{
			var box = await _serviceManager.BoxService.GetByIdAsync(id, trackChanges: false);
			return Ok(box);
		}

		[Route("{id:guid}")]
		[HttpDelete]
		public async Task<IActionResult> DeleteBoxAsync(Guid id)
		{
			var box = await _serviceManager.BoxService.DeleteAsync(id, true);
			return Ok(box);
		}

		[Route("{id:guid}")]
		[HttpPut]
		public async Task<IActionResult> UpdateBoxAsync(Guid id, [FromBody]UpdateBoxDTO updateBoxDTO)
		{
			var box = await _serviceManager.BoxService.UpdateAsync(id, updateBoxDTO, true);
			return Ok(box);
		}

		[Route("{id:guid}/productUnits")]
		[HttpGet]
		public async Task<IActionResult> GetProductUnitsAsync(Guid id)
		{
			var productsUnits = await _serviceManager.ProductUnitService
				.GetProductUnitsByBoxIdAsync(id, boxTrackChanges: false, unitsTrackChanges: true);
			return Ok(productsUnits);
		}
	}
}
