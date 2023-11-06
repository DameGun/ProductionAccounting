using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IBoxRepository : IBaseRepository<Box, Guid>
	{
		Task<IEnumerable<Box>?> GetBoxesByPalletId(Guid palletBarcode);
		Task<IEnumerable<Box>?> GetBoxesByInvoiceNo(string invoiceNo);
	}
}
