namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface IBaseService<T, KEY>
	{
		Task<T> CreateAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task<T> DeleteAsync(KEY id);
		Task<T> GetByIdAsync(KEY id);
	}
}
