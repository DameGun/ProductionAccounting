using ProductionAccounting.Core.Entities;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class PalletRepository : GenericRepository<Pallet, Guid>, IPalletRepository
	{
		public PalletRepository(AppDbContext context) : base(context) { }

		public async Task<IEnumerable<Pallet>?> GetPalletsByInvoiceNo(string invoiceNo)
		{
			return await GetAllByConditionAsync(p => p.InvoiceNo == invoiceNo);
		}
	}
}
