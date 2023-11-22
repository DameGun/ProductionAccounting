using ProductionAccounting.Application.Models.Pallet;

namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface IPalletService : IBaseService<PalletDTO, CreatePalletDTO, Guid>
	{
	}
}
