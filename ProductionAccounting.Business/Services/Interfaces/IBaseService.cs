namespace ProductionAccounting.Application.Services.Interfaces
{
	public interface IBaseService<T, CreateT, KEY>
	{
		Task<T> CreateAsync(CreateT entity);
		Task<T> UpdateAsync(T entity);
		Task<T> DeleteAsync(KEY id);
		Task<T?> GetByIdAsync(KEY id);
		Task<IEnumerable<T>?> GetAllAsync();

	}
}
