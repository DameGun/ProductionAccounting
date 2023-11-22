using AutoMapper;
using ProductionAccounting.Application.Models.Box;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Entities;
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

			var dbResponse = await _repositoryManager.BoxRepository.CreateAsync(boxEntity);

			var boxResponse = _mapper.Map<BoxDTO>(dbResponse);

			return boxResponse;
		}

		public Task<BoxDTO> DeleteAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<BoxDTO>?> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<BoxDTO?> GetByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<BoxDTO> UpdateAsync(BoxDTO entity)
		{
			throw new NotImplementedException();
		}
	}
}
