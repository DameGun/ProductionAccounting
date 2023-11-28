using ProductionAccounting.Application.Models;
using ProductionAccounting.Application.Models.ProductUnit;
using ProductionAccounting.Core.Shared;

namespace ProductionAccounting.Application.Services.Interfaces
{
    public interface IProductUnitService
    {
        Task<ProductUnitDTO> CreateAsync(CreateProductUnitDTO createProductUnitDTO);
        Task<ProductUnitDTO> GetByIdAsync(Guid id, bool trackChanges);
        Task<PagedResponse<ProductUnitDTO>> GetProductUnitsByBoxIdAsync(Guid boxId, 
            RequestParameters requestParameters, bool boxTrackChanges, bool unitsTrackChanges);
    }
}
