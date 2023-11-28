using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Core.Entities;
using ProductionAccounting.Core.Shared;
using ProductionAccounting.Core.Shared.RequestFeatures;
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

		public async Task<PagedList<Box>> GetBoxesByPalletBarcode(Guid palletBarcode, RequestParameters requestParameters, bool trackChanges)
		{
			var boxes = await FindByCondition(b => b.PalletBarcode == palletBarcode, trackChanges).ToListAsync();

			return PagedList<Box>.ToPagingResponse(boxes, requestParameters.PageNumber, requestParameters.PageSize);
		}
	}
}
