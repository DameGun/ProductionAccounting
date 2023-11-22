namespace ProductionAccounting.Application.Models.Invoice
{
	public class InvoiceDTO
	{
		public string InvoiceNo { get; set; }
		public string Sender { get; set; }
		public string Recipient { get; set; }
		public DateOnly Date { get; set; }
		public decimal TotalCost { get; set; }
	}
}
