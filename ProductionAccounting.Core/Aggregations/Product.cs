using ProductionAccounting.Core.Entities;

namespace ProductionAccounting.Core.Aggregations
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int CategoryId { get; set; }
        public decimal Cost { get; set; }

        public Category Category { get; set; }
        public IEnumerable<ProductUnit>? ProductUnits { get; set; }
		public IEnumerable<ProductionApplication>? Applications { get; set; }
	}
}
