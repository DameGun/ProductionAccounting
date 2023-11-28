using ProductionAccounting.Core.Shared.RequestFeatures;

namespace ProductionAccounting.Application.Models
{
	public class PagedResponse<T>
	{
		public IEnumerable<T> Data { get; set; }
		public MetaData MetaData { get; set; }
	}
}
