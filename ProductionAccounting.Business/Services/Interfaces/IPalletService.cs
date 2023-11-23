using ProductionAccounting.Application.Models.Pallet;

namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface IPalletService
	{
		Task<PalletDTO> CreateAsync(CreatePalletDTO createPalletDTO);
		Task<PalletDTO> UpdateAsync(Guid id, UpdatePalletDTO updatePalletDTO, bool trackChanges);
		Task<PalletDTO> DeleteAsync(Guid id, bool trackChanges);
		Task<PalletDTO?> GetByIdAsync(Guid id, bool trackChanges);
	}
}
