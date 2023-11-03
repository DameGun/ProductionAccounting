using System.ComponentModel.DataAnnotations;

namespace ProductionAccounting.Core.Entities
{
	public class Pallet
	{
		public Guid Barcode { get; set; }
		public double Weight { get; set; }
		public int Boxes { get; set; }
		public string? InvoiceNo { get; set; }

		public Invoice? Invoice { get; set; }
		public IEnumerable<Box>? BoxesInside { get; set; }
	}
}
