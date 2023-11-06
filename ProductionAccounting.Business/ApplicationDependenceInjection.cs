using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductionAccounting.Application.Services.Implementations;
using ProductionAccounting.Application.Services.Interfaces;

namespace ProductionAccounting.Application
{
	public static class ApplicationDependenceInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddServices();

			services.AddServiceManager();

			return services;
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IProductionApplicationService, ProductionApplicationService>();
		}

		public static void AddServiceManager(this IServiceCollection services)
		{
			services.AddScoped<IServiceManager, ServiceManager>();
		}
	}
}
