namespace RailwayResults.Tests.Mocks;

public sealed record BasicError(string Key, string Message) : Error(Key, Message)
{
	public static readonly BasicError ErrorA = new("Key", "Error A");
}
