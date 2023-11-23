using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class PalletRepository : GenericRepository<Pallet>, IPalletRepository
	{
		public PalletRepository(AppDbContext context) : base(context) { }


		// Add include functionality in future when invoice implemented
		public async Task<Pallet?> GetById(Guid id, bool trackChanges)
		{
			return await FindById(p => p.Barcode == id, trackChanges);
		}

		public async Task<IEnumerable<Pallet>?> GetPalletsByInvoiceNo(string invoiceNo, bool trackChanges)
		{
			return await FindByCondition(p => p.InvoiceNo == invoiceNo, trackChanges).ToListAsync();
		}
	}
}
