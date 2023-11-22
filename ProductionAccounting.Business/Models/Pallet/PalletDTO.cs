namespace ProductionAccounting.Application.Models.Pallet
{
	public class PalletDTO
	{
		public Guid Barcode { get; set; }
		public double Weight { get; set; }
		public int Boxes { get; set; }
		public string InvoiceNo { get; set; }
	}
}
