using Microsoft.EntityFrameworkCore;
using ProductionAccounting.DataAccess.Services.Interfaces;
using System.Linq.Expressions;

namespace ProductionAccounting.DataAccess.Services.Repository
{
	public abstract class GenericRepository<T> : IBaseRepository<T> where T : class
	{
		private AppDbContext _appDbContext;

		public GenericRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public void Create(T entity) => _appDbContext.Set<T>().Add(entity);

		public void Delete(T entity) => _appDbContext.Set<T>().Remove(entity);

		public void Update(T entity) => _appDbContext.Set<T>().Update(entity);

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
			!trackChanges ?
				_appDbContext.Set<T>()
					.Where(expression)
					.AsNoTracking() :
				_appDbContext.Set<T>()
					.Where(expression);

		public IQueryable<T> FindAll(bool trackChanges) =>
			!trackChanges ?
				_appDbContext.Set<T>()
					.AsNoTracking() :
				_appDbContext.Set<T>();

		public async Task<T?> FindById(Expression<Func<T, bool>> expression, bool trackChanges) =>
				await FindByCondition(expression, trackChanges).SingleOrDefaultAsync();
				
		public IQueryable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties) => 
			Include(includeProperties);

		public IQueryable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			return Include(includeProperties).Where(predicate).AsQueryable();
		}

		private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = _appDbContext.Set<T>().AsNoTracking();
			return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		}

		//public IQueryable<T> GetWithPaging(Expression<Func<T, bool>> expression, RequestParameters requestParameters, bool trackChanges)
		//{
		//	return FindByCondition(expression, trackChanges)
		//			.Skip((requestParameters.PageNumber - 1) * requestParameters.PageSize)
		//			.Take(requestParameters.PageSize);
		//}
	}
}
