using ProductionAccounting.Application.Models.Product;

namespace ProductionAccounting.Application.Services.Interfaces
{
    public interface IProductService
	{
		Task<ProductDTO> CreateAsync(CreateProductDTO createProductDTO);
		Task<ProductDTO> UpdateAsync(int id, UpdateProductDTO updateProductDTO, bool trackChanges);
		Task<ProductDTO> DeleteAsync(int id, bool trackChanges);
		Task<IEnumerable<ProductDTO>?> GetAllAsync(bool trackChanges);
		Task<ProductDTO?> GetByIdAsync(int id, bool trackChanges);
		Task<IEnumerable<ProductDTO>> GetProductsByCategoryId(int categoryId, bool categoryTrackChanges, bool productsTrackChanges);
	}
}