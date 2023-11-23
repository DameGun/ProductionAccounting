using ProductionAccounting.Application.Models.ProductUnit;

namespace ProductionAccounting.Application.Services.Interfaces
{
    public interface IProductUnitService
    {
        Task<ProductUnitDTO> CreateAsync(CreateProductUnitDTO createProductUnitDTO);
        Task<ProductUnitDTO> GetByIdAsync(Guid id, bool trackChanges);
        Task<IEnumerable<ProductUnitDTO>?> GetProductUnitsByBoxIdAsync(Guid boxId, bool boxTrackChanges, bool unitsTrackChanges);
    }
}
