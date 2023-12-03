using Microsoft.AspNetCore.Mvc;
using ProductionAccounting.Application.Models.Category;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Shared;

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

			var createdCategory = await _service.CategoryService.CreateAsync(categoryDTO);

			return CreatedAtRoute("CategoryById", new { id =  createdCategory.Id }, createdCategory);
		}

		[HttpGet]
		public async Task<IActionResult> GetCategoriesAsync([FromQuery]RequestParameters requestParameters)
		{
			var categories = await _service.CategoryService.GetAllAsync(requestParameters, trackChanges: false);
			return Ok(categories);
		}

		[Route("{id:int}", Name = "CategoryById")]
		[HttpGet]
		public async Task<IActionResult> GetCategoryAsync(int id)
		{
			var category = await _service.CategoryService.GetByIdAsync(id, trackChanges: true);
			return Ok(category);
		}

		[Route("{id:int}")]
		[HttpDelete]
		public async Task<IActionResult> DeleteCategoryAsync(int id)
		{
			var category = await _service.CategoryService.DeleteAsync(id, true);
			return Ok(category);
		}

		[Route("{id:int}")]
		[HttpPut]
		public async Task<IActionResult> UpdateCategoryAsync(int id, [FromBody]UpdateCategoryDTO updateCategoryDTO)
		{
			var category = await _service.CategoryService.UpdateAsync(id, updateCategoryDTO, trackChanges: false);
			return Ok(category);
		}

		[Route("{id:int}/products")]
		[HttpGet]
		public async Task<IActionResult> GetProductsByCategoryIdAsync(int id, [FromQuery] RequestParameters requestParameters)
		{
			var products = await _service.ProductService
				.GetProductsByCategoryId(id, requestParameters, categoryTrackChanges: false, productsTrackChanges: true);
			return Ok(products);
		}
	}
}
