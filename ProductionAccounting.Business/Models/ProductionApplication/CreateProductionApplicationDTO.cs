using ProductionAccounting.Core.Shared;

namespace ProductionAccounting.Application.Models.ProductionApplication
{
	public class CreateProductionApplicationDTO
	{
		public int ProductId { get; set; }
		public int PackagesInBox { get; set; }
		public int BoxesInPallet { get; set; }
		public DateTime ProdDate { get; set; }
		public DateTime ExpDate { get; set; }
		public int CurrentApplicationState { get; set; }
	}
}
