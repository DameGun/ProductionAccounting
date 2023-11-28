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
		public DateTime ProdDate { get; set; }
		public DateTime ExpDate { get; set; }
		public ApplicationState CurrentApplicationState { get; set; }

		public Product Product { get; set; }
		public List<Box>? Boxes { get; set; }
		public List<Pallet>? Pallets { get; set; }
	}
}
