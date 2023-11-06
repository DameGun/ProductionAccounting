using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IPalletRepository : IBaseRepository<Pallet, Guid>
	{
		Task<IEnumerable<Pallet>?> GetPalletsByInvoiceNo(string invoiceNo);
	}
}
