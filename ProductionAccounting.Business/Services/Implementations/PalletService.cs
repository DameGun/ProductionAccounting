using AutoMapper;
using ProductionAccounting.Application.Models.Pallet;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.Application.Services.Implementations
{
	public class PalletService : IPalletService
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public PalletService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<PalletDTO> CreateAsync(CreatePalletDTO createPalletDTO)
		{
			var palletEntity = _mapper.Map<Pallet>(createPalletDTO);

			var dbResponse = await _repositoryManager.PalletRepository.CreateAsync(palletEntity);

			var palletResponse = _mapper.Map<PalletDTO>(dbResponse);

			return palletResponse;
		}

		public Task<PalletDTO> DeleteAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<PalletDTO>?> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<PalletDTO?> GetByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<PalletDTO> UpdateAsync(PalletDTO entity)
		{
			throw new NotImplementedException();
		}
	}
}
