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

			var createdApplication = await _service.ProductionApplicationService.CreateProductionApplicationAsync(productionApplicationDTO);

			return CreatedAtRoute("ApplicationById", new { id = createdApplication.Id }, createdApplication);
		}

		[Route("product")]
		[HttpGet]
		public async Task<IActionResult> GetApplicationsByProductIdAsync([Required]int productId)
		{
			var applications = await _service.ProductionApplicationService.GetApplicationsByProductIdAsync(productId);
			return Ok(applications);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var applications = await _service.ProductionApplicationService.GetAllAsync();
			return Ok(applications);
		}

		[Route("{id:guid}", Name = "ApplicationById")]
		[HttpGet]
		public async Task<IActionResult> GetApplicationAsync(Guid id)
		{
			var application = await _service.ProductionApplicationService.GetApplicationAsync(id);
			return Ok(application);
		}

		[Route("setApplicationActive/{id:guid}")]
		[HttpPost]
		public async Task<IActionResult> SetApplicationActive(Guid id)
		{
			var application = await _service.ProductionApplicationService.SetApplicationActiveAsync(id);
			return Ok(application);
		}
	}
}
