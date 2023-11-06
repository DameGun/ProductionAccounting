using System.Linq.Expressions;

namespace ProductionAccounting.DataAccess.Services.Interfaces
{
	public interface IBaseRepository<T, KEY>
	{
		Task<T?> CreateAsync(T entity);
		Task<T?> UpdateAsync(T entity);
		Task<T?> DeleteAsync(KEY id);
		Task<T?> GetByIdAsync(KEY id);
		Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression);
		Task<IEnumerable<T>?> GetAllByConditionAsync(Expression<Func<T, bool>> expression);
		Task<IEnumerable<T>?> GetAllAsync();
	}
}
