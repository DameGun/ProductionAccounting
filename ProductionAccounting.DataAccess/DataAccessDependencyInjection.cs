using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductionAccounting.DataAccess.Services.Interfaces;
using ProductionAccounting.DataAccess.Services.Repository;

namespace ProductionAccounting.DataAccess
{
	public static class DataAccessDependencyInjection
	{
		public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration) {
			services.AddDatabase(configuration);

			services.AddRepositories();

			services.AddRepositoryManager();

			return services;
		}

		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IBoxRepository, BoxRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IInvoiceRepository, InvoiceRepository>();
			services.AddScoped<IPalletRepository, PalletRepository>();
			services.AddScoped<IProductionApplication, ProductionApplicationRepository>();
			services.AddScoped<IProductUnitRepository, ProductUnitRepository>();
		}

		public static void AddRepositoryManager(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryManager, RepositoryManager>();
		}

		public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
			});
		}
	}
}
