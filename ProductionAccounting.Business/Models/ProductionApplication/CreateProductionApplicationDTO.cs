using ProductionAccounting.Core.Shared;

namespace ProductionAccounting.Application.Models.ProductionApplication
{
	public class CreateProductionApplicationDTO
	{
		public int ProductId { get; set; }
		public int PackagesInBox { get; set; }
		public int BoxesInPallet { get; set; }
		public DateOnly ProdDate { get; set; }
		public DateOnly ExpDate { get; set; }
		public ApplicationState CurrentApplicationState { get; set; }
	}
}
