using Microsoft.EntityFrameworkCore;
using ProductionAccounting.DataAccess.Services.Interfaces;

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

		public async Task<T?> GetByIdAsync(KEY id)
		{
			return await _appDbContext.Set<T>().FindAsync(id);
		}

		public async Task<T?> UpdateAsync(T entity)
		{
			_appDbContext.Entry(entity).State = EntityState.Modified;
			await _appDbContext.SaveChangesAsync();
			return entity;
		}
	}
}
