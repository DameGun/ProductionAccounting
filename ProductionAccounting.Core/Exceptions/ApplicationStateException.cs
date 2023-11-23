namespace ProductionAccounting.Core.Exceptions
{
	public class ApplicationStateException : Exception
	{
		public ApplicationStateException() : base("Cant change production application while it is in active or stopped state") { }
	}
}
