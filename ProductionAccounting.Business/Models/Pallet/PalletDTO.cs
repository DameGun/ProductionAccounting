using ProductionAccounting.Application.Models.ProductionApplication;

namespace ProductionAccounting.Application.Models.Pallet
{
	public class PalletDTO
	{
		public Guid Barcode { get; set; }
		public double Weight { get; set; }
		public int Boxes { get; set; }
		public string? InvoiceNo { get; set; }
		public Guid ApplicationId { get; set; }

		public ProductionApplicationDTO? ProductionApplication { get; set; }
	}
}
