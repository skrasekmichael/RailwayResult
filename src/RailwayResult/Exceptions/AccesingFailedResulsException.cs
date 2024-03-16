namespace RailwayResult.Exceptions;

public sealed class AccessingValueOfFailureResultException : InvalidOperationException
{
	public AccessingValueOfFailureResultException() : base("Value of failure result cannot be accessed.") { }
}
