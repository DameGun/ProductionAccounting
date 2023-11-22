using ProductionAccounting.Application.Models.Box;
using ProductionAccounting.Application.Models.Pallet;

namespace ProductionAccounting.Application.Models.Invoice
{
	public class CreateInvoiceDTO
	{
		public string Sender {  get; set; }
		public string Recipient { get; set; }
		public DateOnly Date {  get; set; }
		public IEnumerable<CreateBoxDTO> Boxes {  get; set; }
		public IEnumerable<CreatePalletDTO> Pallets { get; set; }
	}
}
