using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionAccounting.Core.Aggregations
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Product>? Products { get; set; }
    }
}
