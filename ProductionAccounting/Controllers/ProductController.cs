using Microsoft.AspNetCore.Mvc;
using ProductionAccounting.Application.Models.Product;
using ProductionAccounting.Application.Services.Interfaces;
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
			if (productDTO == null) return BadRequest("ProductDto object is null");

			var createdProduct = await _service.ProductService.CreateProductAsync(productDTO);

			return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, productDTO);
		}

		[HttpGet]
		public async Task<IActionResult> GetProductsAsync()
		{
			var products = await _service.ProductService.GetAllAsync();
			return Ok(products);
		}

		[Route("{id:int}", Name = "ProductById")]
		[HttpGet]
		public async Task<IActionResult> GetProductAsync(int id)
		{
			var product = await _service.ProductService.GetProductAsync(id);
			return Ok(product);
		}

		[Route("category")]
		[HttpGet]
		public async Task<IActionResult> GetProductsByCategoryIdAsync([Required]int categoryId)
		{
			var products = await _service.ProductService.GetProductsByCategoryId(categoryId);
			return Ok(products);
		}
	}
}
