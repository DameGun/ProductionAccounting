using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class BoxRepository : GenericRepository<Box>, IBoxRepository
	{
		public BoxRepository(AppDbContext context) : base(context) { }

		public async Task<IEnumerable<Box>?> GetBoxesByInvoiceNo(string invoiceNo, bool trackChanges)
		{
			return await FindByCondition(b => b.InvoiceNo == invoiceNo, trackChanges).ToListAsync();
		}

		public async Task<IEnumerable<Box>?> GetBoxesByPalletBarcode(Guid palletBarcode, bool trackChanges, RequestParameters requestParameters)
		{
			return await FindByCondition(b => b.PalletBarcode == palletBarcode, trackChanges).ToListAsync();
		}
	}
}
