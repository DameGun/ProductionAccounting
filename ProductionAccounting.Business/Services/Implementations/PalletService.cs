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

			_repositoryManager.PalletRepository.Create(palletEntity);
			await _repositoryManager.SaveAsync();

			var palletResponse = _mapper.Map<PalletDTO>(palletEntity);

			return palletResponse;
		}

		public async Task<PalletDTO> DeleteAsync(Guid id, bool trackChanges)
		{
			var pallet = await _repositoryManager.PalletRepository.FindById(p => p.Barcode == id, trackChanges);

			_repositoryManager.PalletRepository.Delete(pallet);
			await _repositoryManager.SaveAsync();

			var palletResponse = _mapper.Map<PalletDTO>(pallet);

			return palletResponse;
		}

		public async Task<PalletDTO?> GetByIdAsync(Guid id, bool trackChanges)
		{
			var pallet = await _repositoryManager.PalletRepository.GetById(id, trackChanges);

			var palletResponse = _mapper.Map<PalletDTO>(pallet);

			return palletResponse;
		}

		public async Task<PalletDTO> UpdateAsync(Guid id, UpdatePalletDTO updatePalletDTO, bool trackChanges)
		{
			var pallet = await _repositoryManager.PalletRepository.FindById(p => p.Barcode == id, trackChanges);

			var palletEntity = _mapper.Map(updatePalletDTO, pallet);

			_repositoryManager.PalletRepository.Update(palletEntity);
			await _repositoryManager.SaveAsync();

			var palletResponse = _mapper.Map<PalletDTO>(palletEntity);

			return palletResponse;
		}
	}
}
