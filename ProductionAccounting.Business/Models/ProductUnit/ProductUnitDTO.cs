using ProductionAccounting.Application.Models.Product;

namespace ProductionAccounting.Application.Models.ProductUnit
{
	public class ProductUnitDTO
	{
		public Guid Serial { get; set; }
		public ProductDTO Product { get; set; }
		public DateTime Date { get; set; }
		public DateTime Expire { get; set; }
		public Guid BoxBarcode { get; set; }
	}
}
