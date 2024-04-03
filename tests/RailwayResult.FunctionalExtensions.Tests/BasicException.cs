namespace RailwayResult.FunctionalExtensions.Tests;

public sealed class BasicException : Exception
{
	public static Out Throw<Out>()
	{
		throw new BasicException();
	}
}
