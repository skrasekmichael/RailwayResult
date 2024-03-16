namespace RailwayResult.Exceptions;

public sealed class AccessingErrorOfSuccessResultException : InvalidOperationException
{
	public AccessingErrorOfSuccessResultException() : base("Error of success result cannot be accessed.") { }
}
