namespace ProductionAccounting.Core.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException() : base($"The item doesn't exist in the database.") { }
	}
}
