namespace RailwayResult.FunctionalExtensions.Tests.Data;

public sealed record GenericError<T>(string Key, string Message, T Data) : BasicError(Key, Message)
{
	public static readonly GenericError<int> GenericErrorA = new("A", "Generic Error of Integer", 100);
}

