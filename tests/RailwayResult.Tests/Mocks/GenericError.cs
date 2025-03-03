namespace RailwayResult.Tests.Mocks;

public sealed record GenericError<T>(string Key, string Message, T Data) : BasicError(Key, Message)
{
	public static readonly GenericError<int> GenericErrorA = new("A", "Error A", 100);
}

