namespace RailwayResult.FunctionalExtensions.Tests;

public sealed class BasicException : Exception
{
	public static void Throw()
	{
		throw new BasicException();
	}

	public static Out Throw<Out>()
	{
		throw new BasicException();
	}
}
