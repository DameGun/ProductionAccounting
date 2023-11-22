using ProductionAccounting.Application.Models.ProductUnit;

namespace ProductionAccounting.Application.Services.Interfaces
{
    public interface IProductUnitService : IBaseService<ProductUnitDTO, CreateProductUnitDTO, Guid>
    {
    }
}
