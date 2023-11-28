using ProductionAccounting.Application.Models;
using ProductionAccounting.Application.Models.Product;
using ProductionAccounting.Core.Shared;

namespace ProductionAccounting.Application.Services.Interfaces
{
    public interface IProductService
	{
		Task<ProductDTO> CreateAsync(CreateProductDTO createProductDTO);
		Task<ProductDTO> UpdateAsync(int id, UpdateProductDTO updateProductDTO, bool trackChanges);
		Task<ProductDTO> DeleteAsync(int id, bool trackChanges);
		Task<PagedResponse<ProductDTO>> GetAllAsync(RequestParameters requestParameters, bool trackChanges);
		Task<ProductDTO?> GetByIdAsync(int id, bool trackChanges);
		Task<PagedResponse<ProductDTO>> GetProductsByCategoryId(int categoryId, 
			RequestParameters requestParameters, bool categoryTrackChanges, bool productsTrackChanges);
	}
}