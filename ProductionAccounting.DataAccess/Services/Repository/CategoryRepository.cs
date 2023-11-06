using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class CategoryRepository : GenericRepository<Category, int>, ICategoryRepository
	{
		public CategoryRepository(AppDbContext dbContext) : base(dbContext) { }
	}
}
