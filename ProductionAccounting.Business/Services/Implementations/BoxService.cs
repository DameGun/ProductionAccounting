using AutoMapper;
using ProductionAccounting.Application.Models.Box;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.Application.Services.Implementations
{
	public class BoxService : IBoxService
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public BoxService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<BoxDTO> CreateAsync(CreateBoxDTO createBoxDTO)
		{	
			var boxEntity = _mapper.Map<Box>(createBoxDTO);

			_repositoryManager.BoxRepository.Create(boxEntity);
			await _repositoryManager.SaveAsync();

			var boxResponse = _mapper.Map<BoxDTO>(boxEntity);

			return boxResponse;
		}

		public async Task<BoxDTO> DeleteAsync(Guid id, bool trackChanges)
		{
			var box = await _repositoryManager.BoxRepository.FindById(b => b.Barcode == id, trackChanges);

			_repositoryManager.BoxRepository.Delete(box);
			await _repositoryManager.SaveAsync();

			var boxResponse = _mapper.Map<BoxDTO>(box);

			return boxResponse;
		}

		public async Task<IEnumerable<BoxDTO>?> GetBoxesByPalletIdAsync(Guid palletId, 
			RequestParameters requestParameters, bool palletTrackChanges, bool boxTrackChanges)
		{
			var pallet = await _repositoryManager.PalletRepository.FindById(p => p.Barcode == palletId, palletTrackChanges);

			var boxes = await _repositoryManager.BoxRepository.GetBoxesByPalletBarcode(palletId, boxTrackChanges, requestParameters);

			var boxesResponse = _mapper.Map<IEnumerable<BoxDTO>>(boxes);

			return boxesResponse;
		}

		public async Task<BoxDTO?> GetByIdAsync(Guid id, bool trackChanges)
		{
			var box = await _repositoryManager.BoxRepository.FindById(b => b.Barcode == id, trackChanges);
			var boxResponse = _mapper.Map<BoxDTO>(box);

			return boxResponse;
		}

		public async Task<BoxDTO> UpdateAsync(Guid id, UpdateBoxDTO updateBoxDTO, bool trackChanges)
		{
			var box = await _repositoryManager.BoxRepository.FindById(b => b.Barcode == id, trackChanges);

			var boxEntity = _mapper.Map(updateBoxDTO, box);

			_repositoryManager.BoxRepository.Update(boxEntity);
			await _repositoryManager.SaveAsync();

			var boxResponse = _mapper.Map<BoxDTO>(boxEntity);

			return boxResponse;
		}
	}
}
