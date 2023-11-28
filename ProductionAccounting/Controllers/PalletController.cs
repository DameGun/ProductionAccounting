using Microsoft.AspNetCore.Mvc;
using ProductionAccounting.Application.Models.Pallet;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Shared;

namespace ProductionAccounting.Api.Controllers
{
	[Route("api/pallets")]
	[ApiController]
	public class PalletController : ControllerBase
	{
		private readonly IServiceManager _serviceManager;

		public PalletController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[Route("{id:guid}")]
		[HttpGet]
		public async Task<IActionResult> GetPalletByIdAsync(Guid id)
		{
			var pallet = await _serviceManager.PalletService.GetByIdAsync(id, trackChanges: false);
			return Ok(pallet);
		}

		[Route("{id:guid}")]
		[HttpDelete]
		public async Task<IActionResult> DeletePalletAsync(Guid id)
		{
			var pallet = await _serviceManager.PalletService.DeleteAsync(id, true);
			return Ok(pallet);
		}

		[Route("{id:guid}")]
		[HttpPut]
		public async Task<IActionResult> UpdatePalletAsync(Guid id, [FromBody]UpdatePalletDTO updatePalletDTO)
		{
			var pallet = await _serviceManager.PalletService.UpdateAsync(id, updatePalletDTO, true);
			return Ok(pallet);
		}

	    [Route("{id:guid}/boxes")]
		[HttpGet]
		public async Task<IActionResult> GetBoxesAsync(Guid id, [FromQuery]RequestParameters requestParameters)
		{
			var boxes = await _serviceManager.BoxService
				.GetBoxesByPalletIdAsync(id, requestParameters, palletTrackChanges: false, boxTrackChanges: true);
			return Ok(boxes);
		}
	}
}
