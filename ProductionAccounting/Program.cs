using LoggerService;
using NLog;
using ProductionAccounting.Api.Extensions;
using ProductionAccounting.Application;
using ProductionAccounting.DataAccess;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureLoggerService();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg =>
{
	cfg.AddMaps("ProductionAccounting.Application");
});

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsProduction())
{
	app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
