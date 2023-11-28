using Microsoft.AspNetCore.Mvc;
using ProductionAccounting.Application.Models.Product;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Shared;
using System.ComponentModel.DataAnnotations;

namespace ProductionAccounting.Api.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IServiceManager _service;

		public ProductController(IServiceManager service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDTO productDTO)
		{
			var createdProduct = await _service.ProductService.CreateAsync(productDTO);
			return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, productDTO);
		}

		[HttpGet]
		public async Task<IActionResult> GetProductsAsync([FromQuery]RequestParameters requestParameters)
		{
			var products = await _service.ProductService.GetAllAsync(requestParameters, trackChanges: true);
			return Ok(products);
		}

		[Route("{id:int}", Name = "ProductById")]
		[HttpGet]
		public async Task<IActionResult> GetProductAsync(int id)
		{
			var product = await _service.ProductService.GetByIdAsync(id, trackChanges: true);
			return Ok(product);
		}

		[Route("{id:int}")]
		[HttpPut]
		public async Task<IActionResult> UpdateProductAsync(int id, [FromBody]UpdateProductDTO updateProductDTO)
		{
			var product = await _service.ProductService.UpdateAsync(id, updateProductDTO, true);
			return Ok(product);
		}

		[Route("{id:int}")]
		[HttpDelete]
		public async Task<IActionResult> DeleteProductAsync(int id)
		{
			var product = await _service.ProductService.DeleteAsync(id, true);
			return Ok(product);
		}
	}
}
