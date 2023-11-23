using ProductionAccounting.Application.Models.ProductionApplication;

namespace ProductionAccounting.Application.Models.Box
{
	public class BoxDTO
	{
		public Guid Barcode { get; set; }
		public double Weight { get; set; }
		public int Packages { get; set; }
		public Guid PalletBarcode { get; set; }
		public string? InvoiceNo { get; set; }
		public Guid ApplicationId { get; set; }

		public ProductionApplicationDTO? ProductionApplication { get; set; }
	}
}
