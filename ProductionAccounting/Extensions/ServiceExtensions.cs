using LoggerService;

namespace ProductionAccounting.Api.Extensions
{
	public static class ServiceExtensions
	{
		// Configuring CORS policy, for now this api allow requests from any origin
		// "AllowAnyOrigin", but it is important to be careful and restrictive as much as possible.
		// WithOrigins("https://example.com") better to use instead, "WithMethods" and "WithHeaders" configuring.

		public static void ConfigureCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
					builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());
			});
		}

		public static void ConfigureLoggerService(this IServiceCollection services)
		{
			services.AddSingleton<ILoggerManager, LoggerManager>();
		}
	}
}
