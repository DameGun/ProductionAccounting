using ProductionAccounting.Application.Models;
using ProductionAccounting.Application.Models.Box;
using ProductionAccounting.Core.Shared;

namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface IBoxService
	{
		Task<BoxDTO> CreateAsync(CreateBoxDTO createBoxDTO);
		Task<BoxDTO> UpdateAsync(Guid id, UpdateBoxDTO updateBoxDTO, bool trackChanges);
		Task<BoxDTO> DeleteAsync(Guid id, bool trackChanges);
		Task<BoxDTO?> GetByIdAsync(Guid id, bool trackChanges);
		Task<PagedResponse<BoxDTO>> GetBoxesByPalletIdAsync(Guid palletId, 
			RequestParameters requestParameters, bool palletTrackChanges, bool boxTrackChanges);
	}
}
