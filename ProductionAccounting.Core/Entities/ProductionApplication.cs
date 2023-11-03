using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.Core.Shared;

namespace ProductionAccounting.Core.Entities
{
    public class ProductionApplication
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int PackagesInBox {  get; set; }
		public int BoxesInPallet {  get; set; }
		public DateTime ProdDate { get; set; }
		public DateTime ExpDate { get; set; }
		public ApplicationState CurrentApplicationState { get; set; }

		public Product? Product { get; set; }
	}
}
