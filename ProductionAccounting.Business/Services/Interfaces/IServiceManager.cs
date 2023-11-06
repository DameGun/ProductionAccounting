namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface IServiceManager
	{
		IProductService ProductService { get; }
		IProductionApplicationService ProductionApplicationService { get; }
		ICategoryService CategoryService { get; }
	}
}
