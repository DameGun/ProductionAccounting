using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.Core.Shared;

namespace ProductionAccounting.Core.Entities
{
    public class ProductionApplication
	{
		public Guid Id { get; set; }
		public int ProductId { get; set; }
		public int PackagesInBox {  get; set; }
		public int BoxesInPallet {  get; set; }
		public DateOnly ProdDate { get; set; }
		public DateOnly ExpDate { get; set; }
		public ApplicationState CurrentApplicationState { get; set; }

		public Product Product { get; set; }
	}
}
