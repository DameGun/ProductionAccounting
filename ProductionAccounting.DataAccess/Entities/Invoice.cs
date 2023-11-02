namespace ProductionAccounting.DataAccess.Entities
{
	public class Invoice
	{
		public string InvoiceNo { get; set; }
		public string Sender {  get; set; }
		public string Recipient {  get; set; }
		public DateTime Date { get; set; }
		public double TotalCost { get; set; }

		public IEnumerable<Box>? Boxes { get; set; }
		public IEnumerable<Pallet>? Pallets { get; set; }
	}
}
