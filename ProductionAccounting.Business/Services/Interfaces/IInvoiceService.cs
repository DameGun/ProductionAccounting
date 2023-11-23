using ProductionAccounting.Application.Models.Invoice;

namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface IInvoiceService
	{
		Task<InvoiceDTO> CreateAsync(CreateInvoiceDTO createInvoiceDTO);
		Task<InvoiceDTO> DeleteAsync(string invoiceNo);
	}
}
