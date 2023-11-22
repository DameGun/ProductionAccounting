namespace ProductionAccounting.Application.Models.ProductUnit
{
	public class CreateProductUnitDTO
	{
		public int ProductId { get; set; }
		public DateTime Date { get; set; }
		public DateTime Expire { get; set; }
		public Guid BoxBarcode { get; set; }
	}
}
