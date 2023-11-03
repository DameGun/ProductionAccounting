using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Application.Mappings;
using ProductionAccounting.Application.Services.Implementations;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.DataAccess;
using ProductionAccounting.DataAccess.Services.Interfaces;
using ProductionAccounting.DataAccess.Services.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg =>
{
	cfg.AddMaps("ProductionAccounting.Application");
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDataAccess(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
