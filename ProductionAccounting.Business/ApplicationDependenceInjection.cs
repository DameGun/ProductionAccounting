using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductionAccounting.Application.Factories;
using ProductionAccounting.Application.Models.Box;
using ProductionAccounting.Application.Models.Pallet;
using ProductionAccounting.Application.Models.ProductUnit;
using ProductionAccounting.Application.Services.Implementations;
using ProductionAccounting.Application.Services.Interfaces;

namespace ProductionAccounting.Application
{
	public static class ApplicationDependenceInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddServices();

			services.AddFactoryServices();

			services.AddServiceManager();

			return services;
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IProductionApplicationService, ProductionApplicationService>();
			services.AddScoped<IPalletService, PalletService>();
			services.AddScoped<IBoxService, BoxService>();
			services.AddScoped<IProductUnitService, ProductUnitService>();	
			services.AddScoped<IInvoiceService, InvoiceService>();
		}

		public static void AddFactoryServices(this IServiceCollection services)
		{
			services.AddScoped<IFactory<CreateProductUnitDTO>, ProductUnitFactory>();
			services.AddScoped<IFactory<CreateBoxDTO>, BoxFactory>();
			services.AddScoped<IFactory<CreatePalletDTO>, PalletFactory>();
			services.AddScoped<IProductionUnitService, ProductionUnitService>();
		}

		public static void AddServiceManager(this IServiceCollection services)
		{
			services.AddScoped<IServiceManager, ServiceManager>();
		}
	}
}
