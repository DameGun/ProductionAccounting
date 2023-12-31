﻿namespace ProductionAccounting.Core.Entities
{
	public class Invoice
	{
		public string InvoiceNo { get; set; }
		public string Sender {  get; set; }
		public string Recipient {  get; set; }
		public DateOnly Date { get; set; }
		public decimal TotalCost { get; set; }

		public IEnumerable<Box>? Boxes { get; set; }
		public IEnumerable<Pallet>? Pallets { get; set; }
	}
}
