using AutoMapper;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.Application.Services.Implementations
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<IProductService> _productService;
		private readonly Lazy<IProductionApplicationService> _productionApplicationService;
		private readonly Lazy<ICategoryService> _categoryService;

		public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
			_productionApplicationService = new Lazy<IProductionApplicationService>(() => new ProductionApplicationService(repositoryManager, mapper));
			_categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper));
		}

		public IProductService ProductService => _productService.Value;

		public IProductionApplicationService ProductionApplicationService => _productionApplicationService.Value;

		public ICategoryService CategoryService => _categoryService.Value;
	}
}
