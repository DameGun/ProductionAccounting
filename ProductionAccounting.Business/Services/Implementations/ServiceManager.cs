using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using ProductionAccounting.Application.Factories;
using ProductionAccounting.Application.Models.Box;
using ProductionAccounting.Application.Models.Pallet;
using ProductionAccounting.Application.Models.ProductUnit;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.Application.Services.Implementations
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<IProductService> _productService;
		private readonly Lazy<IProductionApplicationService> _productionApplicationService;
		private readonly Lazy<ICategoryService> _categoryService;
		private readonly Lazy<IProductUnitService> _productUnitService;
		private readonly Lazy<IBoxService> _boxService;
		private readonly Lazy<IPalletService> _palletService;

		private readonly Lazy<IFactory<CreateProductUnitDTO>> _productUnitFactory;
		private readonly Lazy<IFactory<CreateBoxDTO>> _boxFactory;
		private readonly Lazy<IFactory<CreatePalletDTO>> _palletFactory;
		private readonly Lazy<IProductionUnitService> _productionUnitService;

		public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IDistributedCache cache)
		{
			_productService = new Lazy<IProductService>(
				() => new ProductService(repositoryManager, mapper));

			_productionApplicationService = new Lazy<IProductionApplicationService>(
				() => new ProductionApplicationService(repositoryManager, mapper, cache));

			_categoryService = new Lazy<ICategoryService>(
				() => new CategoryService(repositoryManager, mapper));

			_palletService = new Lazy<IPalletService>(
				() => new PalletService(repositoryManager, mapper));

			_boxService = new Lazy<IBoxService>(
				() => new BoxService(repositoryManager, mapper));

			_productUnitService = new Lazy<IProductUnitService>(
				() => new ProductUnitService(repositoryManager, mapper));

			_productUnitFactory = new Lazy<IFactory<CreateProductUnitDTO>>(
				() => new ProductUnitFactory(cache));

			_boxFactory = new Lazy<IFactory<CreateBoxDTO>>(
				() => new BoxFactory(cache));

			_palletFactory = new Lazy<IFactory<CreatePalletDTO>>(
				() => new PalletFactory(cache));

			_productionUnitService = new Lazy<IProductionUnitService>(
				() => new ProductionUnitService(this, cache));
		}

		public IProductService ProductService => _productService.Value;
		public IProductionApplicationService ProductionApplicationService => _productionApplicationService.Value;
		public ICategoryService CategoryService => _categoryService.Value;
		public IProductUnitService ProductUnitService => _productUnitService.Value;
		public IBoxService BoxService => _boxService.Value;
		public IPalletService PalletService => _palletService.Value;
		public IFactory<CreateProductUnitDTO> ProductUnitFactory => _productUnitFactory.Value;
		public IFactory<CreateBoxDTO> BoxFactory => _boxFactory.Value;
		public IFactory<CreatePalletDTO> PalletFactory => _palletFactory.Value;
		public IProductionUnitService ProductionUnitService => _productionUnitService.Value;
	}
}
