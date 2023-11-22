using ProductionAccounting.Application.Factories;
using ProductionAccounting.Application.Models.Box;
using ProductionAccounting.Application.Models.Pallet;
using ProductionAccounting.Application.Models.ProductUnit;

namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface IServiceManager
	{
		IProductService ProductService { get; }
		IProductionApplicationService ProductionApplicationService { get; }
		ICategoryService CategoryService { get; }
		IProductUnitService ProductUnitService { get; }
		IBoxService BoxService { get; }
		IPalletService PalletService { get; }
		IFactory<CreateProductUnitDTO> ProductUnitFactory { get; }
		IFactory<CreateBoxDTO> BoxFactory { get; }
		IFactory<CreatePalletDTO> PalletFactory { get; }
		IProductionUnitService ProductionUnitService { get; }
	}
}
