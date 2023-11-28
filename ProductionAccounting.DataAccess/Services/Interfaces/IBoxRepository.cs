using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.Core.Shared.RequestFeatures;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IBoxRepository : IBaseRepository<Box>
	{ 
		Task<IEnumerable<Box>?> GetBoxesByInvoiceNo(string invoiceNo, bool trackChanges);
		Task<PagedList<Box>> GetBoxesByPalletBarcode(Guid palletBarcode, RequestParameters requestParameters, bool trackChanges);
	}
}
