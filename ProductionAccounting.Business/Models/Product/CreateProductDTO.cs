namespace ProductionAccounting.Application.Models.Product
{
	public class CreateProductDTO
	{
		public string Name { get; set; }
		public double Weight { get; set; }
		public int CategoryId { get; set; }
		public decimal Cost { get; set; }
	}
}
