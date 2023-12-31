﻿namespace ProductionAccounting.Core.Entities
{
	public class Pallet
	{
		public Guid Barcode { get; set; }
		public double Weight { get; set; }
		public int Boxes { get; set; }
		public string? InvoiceNo { get; set; }
		public Guid? ApplicationId { get; set; }

		public Invoice? Invoice { get; set; }
		public IEnumerable<Box>? BoxesInside { get; set; }
		public ProductionApplication? ProductionApplication { get; set; }
	}
}
