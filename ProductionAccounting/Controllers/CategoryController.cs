using Microsoft.AspNetCore.Mvc;
using ProductionAccounting.Application.Models.Category;
using ProductionAccounting.Application.Services.Interfaces;

namespace ProductionAccounting.Api.Controllers
{
	[Route("api/categories")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IServiceManager _service;

		public CategoryController(IServiceManager service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategoryAsync([FromBody]CreateCategoryDTO categoryDTO)
		{
			if (categoryDTO == null) return BadRequest("CategoryDTO object is null");

			var createdCategory = await _service.CategoryService.CreateCategoryAsync(categoryDTO);

			return CreatedAtRoute("CategoryById", new { id =  createdCategory.Id }, createdCategory);
		}

		[HttpGet]
		public async Task<IActionResult> GetCategoriesAsync()
		{
			var categories = await _service.CategoryService.GetAllAsync();
			return Ok(categories);
		}

		[Route("{id:int}", Name = "CategoryById")]
		[HttpGet]
		public async Task<IActionResult> GetCategoryAsync(int id)
		{
			var category = await _service.CategoryService.GetCategoryAsync(id);
			return Ok(category);
		}
	}
}
