using ProductionAccounting.Application.Models.Invoice;
using ProductionAccounting.Application.Services.Interfaces;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.Application.Services.Implementations
{
	public class InvoiceService : IInvoiceService
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IServiceManager _serviceManager;

		public InvoiceService(IRepositoryManager repositoryManager, IServiceManager serviceManager)
		{
			_repositoryManager = repositoryManager;
			_serviceManager = serviceManager;
		}

		public async Task<InvoiceDTO> CreateAsync(CreateInvoiceDTO createInvoiceDTO)
		{
			throw new NotImplementedException();
		}

		public Task<InvoiceDTO> DeleteAsync(string invoiceNo)
		{
			throw new NotImplementedException();
		}
	}
}
