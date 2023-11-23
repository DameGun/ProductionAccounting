namespace ProductionAccounting.Core.Entities
{
	public class Box
	{
		public Guid Barcode { get; set; }
		public double Weight {  get; set; }
		public int Packages { get; set; }
		public Guid PalletBarcode {  get; set; }
		public string? InvoiceNo { get; set; }
		public Guid? ApplicationId { get; set; }
		
		public Pallet? Pallet { get; set; }
		public Invoice? Invoice { get; set; }
		public IEnumerable<ProductUnit>? ProductUnits { get; set; }
		public ProductionApplication? ProductionApplication { get; set; }
	}
}
