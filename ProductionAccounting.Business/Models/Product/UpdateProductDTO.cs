namespace ProductionAccounting.Application.Models.Product
{
	public class UpdateProductDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Weight { get; set; }
		public int CategoryId { get; set; }
		public decimal Cost { get; set; }
	}
}
