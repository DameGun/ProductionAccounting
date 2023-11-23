using ProductionAccounting.Core.Entities;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
	{
		public InvoiceRepository(AppDbContext context) : base(context) { }
	}
}
