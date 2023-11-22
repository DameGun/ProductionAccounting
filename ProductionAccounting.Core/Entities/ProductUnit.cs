using ProductionAccounting.Core.Aggregations;

namespace ProductionAccounting.Core.Entities
{
	public class ProductUnit
	{
		public Guid Serial {  get; set; }
		public int ProductId { get; set; }
		public DateTime Date { get; set; }
		public DateTime Expire { get; set; }
		public Guid BoxBarcode { get; set; }

		public Box? Box { get; set; }
		public Product? Product { get; set; }
	}
}
