using ProductionAccounting.Application.Models.Product;
using ProductionAccounting.Core.Shared;

namespace ProductionAccounting.Application.Models.ProductionApplication
{
    public class ProductionApplicationDTO
    {
        public Guid Id { get; set; }
        public int PackagesInBoxMax { get; set; }
        public int BoxesInPalletMax { get; set; }
        public int? CurrentBoxesCount { get; set; }
        public int? CurrentPalletsCount { get; set; }
        public DateTime ProdDate { get; set; }
        public DateTime ExpDate { get; set; }
        public ApplicationState CurrentApplicationState { get; set; }

        public ProductDTO? Product { get; set; }
    }
}
