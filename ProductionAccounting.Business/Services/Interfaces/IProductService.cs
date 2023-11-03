using ProductionAccounting.Application.Models;

namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface IProductService : IBaseService<ProductDTO, int>
	{
		Task<IEnumerable<ProductDTO>> GetAllAsync();
	}
}
