using ProductionAccounting.Core.Entities;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class BoxRepository : GenericRepository<Box, Guid>, IBoxRepository
	{
		public BoxRepository(AppDbContext context) : base(context) { }

		public async Task<IEnumerable<Box>?> GetBoxesByInvoiceNo(string invoiceNo)
		{
			return await GetAllByConditionAsync(b => b.InvoiceNo == invoiceNo);
		}

		public async Task<IEnumerable<Box>?> GetBoxesByPalletId(Guid palletBarcode)
		{
			return await GetAllByConditionAsync(b => b.PalletBarcode == palletBarcode);
		}
	}
}
