using Microsoft.EntityFrameworkCore;
using ProductionAccounting.DataAccess.Services.Interfaces;
using System.Linq.Expressions;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public abstract class GenericRepository<T, KEY> : IBaseRepository<T, KEY> where T : class
	{
		private AppDbContext _appDbContext;

		public GenericRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<T?> CreateAsync(T entity)
		{
			await _appDbContext.Set<T>().AddAsync(entity);
			await _appDbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<T?> DeleteAsync(KEY id)
		{
			var entity = await GetByIdAsync(id);
			if (entity != null)
			{
				_appDbContext.Set<T>().Remove(entity);
				await _appDbContext.SaveChangesAsync();
				return entity;
			}
			return null;
		}

		public async Task<IEnumerable<T>?> GetAllByConditionAsync(Expression<Func<T, bool>> expression) => 
			await _appDbContext.Set<T>().Where(expression).ToListAsync();

		public async Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression) =>
			await _appDbContext.Set<T>().Where(expression).FirstOrDefaultAsync();

		public async Task<IEnumerable<T>?> GetAllAsync() =>
			await _appDbContext.Set<T>().ToListAsync();

		public async Task<T?> GetByIdAsync(KEY id) =>
			await _appDbContext.Set<T>().FindAsync(id);

		public async Task<T?> UpdateAsync(T entity)
		{
			_appDbContext.Entry(entity).State = EntityState.Modified;
			await _appDbContext.SaveChangesAsync();
			return entity;
		}
	}
}
