using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Shared;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IBoxRepository : IBaseRepository<Box>
	{ 
		Task<IEnumerable<Box>?> GetBoxesByInvoiceNo(string invoiceNo, bool trackChanges);
		Task<IEnumerable<Box>?> GetBoxesByPalletBarcode(Guid palletBarcode, bool trackChanges, RequestParameters requestParameters);
	}
}
