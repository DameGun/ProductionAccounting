using System.Linq.Expressions;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IBaseRepository<T>
	{
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);
		IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
		IQueryable<T> FindAll(bool trackChanges);
		Task<T?> FindById(Expression<Func<T, bool>> expression, bool trackChanges);
		//IQueryable<T> GetWithPaging(Expression<Func<T, bool>> expression, RequestParameters requestParameters, bool trackChanges); 
		IQueryable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
		IQueryable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
	}
}
