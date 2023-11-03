using Microsoft.AspNetCore.Mvc;
using ProductionAccounting.Application.Services.Interfaces;

namespace ProductionAccounting.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var products = await _productService.GetAllAsync();
			return Ok(products);
		}
	}
}
