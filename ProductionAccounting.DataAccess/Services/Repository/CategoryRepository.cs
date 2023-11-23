using Microsoft.EntityFrameworkCore;
using ProductionAccounting.Core.Aggregations;
using ProductionAccounting.DataAccess.Services.Interfaces;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(AppDbContext dbContext) : base(dbContext) { }

		public async Task<IEnumerable<Category>> GetAllAsync(bool trackChanges)
		{
			return await FindAll(trackChanges).ToListAsync();
		}
	}
}
