using ProductionAccounting.Core.Aggregations;

namespace ProductionAccounting.Core.Entities
{
	public class ProductUnit
	{
		public Guid Serial {  get; set; }
		public int ProductId { get; set; }
		public DateOnly Date { get; set; }
		public DateOnly Expire { get; set; }
		public Guid BoxBarcode { get; set; }

		public Box? Box { get; set; }
		public Product? Product { get; set; }
	}
}
