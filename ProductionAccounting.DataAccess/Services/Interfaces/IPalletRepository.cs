using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IPalletRepository : IBaseRepository<Pallet>
	{
		Task<Pallet> GetById(Guid id, bool trackChanges);
		Task<IEnumerable<Pallet>?> GetPalletsByInvoiceNo(string invoiceNo, bool trackChanges);
	}
}
