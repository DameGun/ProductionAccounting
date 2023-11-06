using AutoMapper;
using ProductionAccounting.Application.Models.ProductionApplication;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Exceptions;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.Application.Services.Implementations
{
    public class ProductionApplicationService : IProductionApplicationService
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public ProductionApplicationService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ProductionApplicationDTO>> GetApplicationsByProductIdAsync(int productId)
		{
			var product = await _repositoryManager.ProductRepository.GetByIdAsync(productId);
			if (product == null) throw new NotFoundException();

			var applications = await _repositoryManager.ProductionApplication.GetApplicationsByProductId(productId);
			var applicationsDTO = _mapper.Map<IEnumerable<ProductionApplicationDTO>>(applications);

			return applicationsDTO;
		}

		public async Task<IEnumerable<ProductionApplicationDTO>> GetAllAsync()
		{
			var applications = await _repositoryManager.ProductionApplication.GetAllAsync();
			var applicationDTO = _mapper.Map<IEnumerable<ProductionApplicationDTO>>(applications);
			
			return applicationDTO;
		}

		public async Task<ProductionApplicationDTO> GetApplicationAsync(Guid applicationId)
		{
			var application = await _repositoryManager.ProductionApplication.GetByIdAsync(applicationId);
			if(application == null) throw new NotFoundException();

			var applicationDTO = _mapper.Map<ProductionApplicationDTO>(application);

			return applicationDTO;
		}

		public async Task<ProductionApplicationDTO> CreateProductionApplicationAsync(CreateProductionApplicationDTO productionApplicationDTO)
		{
			var product = await _repositoryManager.ProductRepository.GetByIdAsync(productionApplicationDTO.ProductId);
			if (product == null) throw new NotFoundException();

			var applicationEntity = _mapper.Map<ProductionApplication>(productionApplicationDTO);
			var dbResponse = await _repositoryManager.ProductionApplication.CreateAsync(applicationEntity);

			var applicationResponse = _mapper.Map<ProductionApplicationDTO>(dbResponse);

			return applicationResponse;
		}
	}
}
