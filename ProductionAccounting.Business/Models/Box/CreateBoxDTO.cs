namespace ProductionAccounting.Application.Models.Box
{
	public class CreateBoxDTO
	{
		public double Weight { get; set; }
		public int Packages { get; set; }
		public Guid PalletBarcode { get; set; }
		public int CurrentQuantity { get; set; }
	}
}
