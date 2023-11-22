namespace ProductionAccounting.Application.Factories
{
	public interface IFactory<T>
	{
		public Task<T> CreateAsync(params object[] parameters);
	}
}
