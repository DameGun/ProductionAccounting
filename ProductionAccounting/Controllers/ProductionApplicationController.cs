using Microsoft.AspNetCore.Mvc;
using ProductionAccounting.Application.Models.ProductionApplication;
using ProductionAccounting.Application.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ProductionAccounting.Api.Controllers
{
	[Route("api/applications")]
	[ApiController]
	public class ProductionApplicationController : ControllerBase
	{
		private readonly IServiceManager _service;

		public ProductionApplicationController(IServiceManager service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<IActionResult> CreateProductionApplicationAsync([FromBody]CreateProductionApplicationDTO productionApplicationDTO)
		{
			if (productionApplicationDTO == null) return BadRequest("ProductionApplicationDTO object is null");

			var createdApplication = await _service.ProductionApplicationService.CreateAsync(productionApplicationDTO, true);

			return CreatedAtRoute("ApplicationById", new { id = createdApplication.Id }, createdApplication);
		}

		[Route("product")]
		[HttpGet]
		public async Task<IActionResult> GetApplicationsByProductIdAsync([Required]int productId)
		{
			var applications = await _service.ProductionApplicationService
				.GetApplicationsByProductIdAsync(productId, trackChanges: true);
			return Ok(applications);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var applications = await _service.ProductionApplicationService.GetAllAsync(trackChanges: true);
			return Ok(applications);
		}

		[Route("{id:guid}", Name = "ApplicationById")]
		[HttpGet]
		public async Task<IActionResult> GetApplicationAsync(Guid id)
		{
			var application = await _service.ProductionApplicationService.GetByIdAsync(id, trackChanges: true);
			return Ok(application);
		}

		[Route("setApplicationActive/{id:guid}")]
		[HttpPost]
		public async Task<IActionResult> SetApplicationActive(Guid id)
		{
			var application = await _service.ProductionApplicationService
				.SetApplicationActiveAsync(id, trackChanges: true);
			return Ok(application);
		}

		[Route("{id:guid}")]
		[HttpPut]
		public async Task<IActionResult> UpdateProductionApplicationAsync(Guid id, 
			[FromBody]UpdateProductionApplicationDTO updateProductionApplicationDTO)
		{
			var productionApplication = await _service.ProductionApplicationService
				.UpdateAsync(id, updateProductionApplicationDTO, trackChanges: true);
			return Ok(productionApplication);
		}

		[Route("{id:guid}")]
		[HttpDelete]
		public async Task<IActionResult> DeleteProductionApplicationAsync(Guid id)
		{
			var productionApplication = await _service.ProductionApplicationService.DeleteAsync(id, trackChanges: true);
			return Ok(productionApplication);
		}
	}
}
