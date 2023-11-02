namespace ProductionAccounting.DataAccess.Entities
{
	public class Box
	{
		public Guid Barcode { get; set; }
		public double Weight {  get; set; }
		public int Packages { get; set; }
		public Guid PalletBarcode {  get; set; }
		public string InvoiceNo { get; set; }

		public Pallet? Pallet { get; set; }
		public Invoice? Invoice { get; set; }
		public IEnumerable<ProductUnit>? ProductUnits { get; set; }
	}
}
