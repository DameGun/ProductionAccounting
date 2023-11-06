using ProductionAccounting.Application.Models.Product;

namespace ProductionAccounting.Application.Services.Interfaces
{
    public interface IProductService
	{
		Task<ProductDTO> CreateProductAsync(CreateProductDTO productDTO);
		Task<ProductDTO> GetProductAsync(int productId);
		Task<IEnumerable<ProductDTO>> GetAllAsync();
		Task<IEnumerable<ProductDTO>> GetProductsByCategoryId(int categoryId);
	}
}
