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

			return services;
		}

		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IProductRepository, ProductRepository>();
		}

		public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
		}
	}
}
