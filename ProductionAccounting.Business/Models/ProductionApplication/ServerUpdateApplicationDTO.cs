namespace ProductionAccounting.Application.Models.ProductionApplication
{
	public class ServerUpdateApplicationDTO
	{
		public Guid Id { get; set; }
		public int ProductId { get; set; }
		public int PackagesInBox { get; set; }
		public int BoxesInPallet { get; set; }
		public int TotalUnits { get; set; }
		public int TotalBoxes { get; set; }
		public int TotalPallets { get; set; }
		public Guid LastBoxGuid { get; set; }
		public Guid LastPalletGuid { get; set; }
		public DateTime ProdDate { get; set; }
		public DateTime ExpDate { get; set; }
		public int CurrentApplicationState { get; set; }
	}
}
