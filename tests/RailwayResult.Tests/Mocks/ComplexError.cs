using static RailwayResult.Tests.Mocks.ComplexError;

namespace RailwayResult.Tests.Mocks;

public sealed record ComplexError(
	string Key,
	string Message,
	string AdditionalString,
	int AdditionalInt,
	NestedRecord Record,
	List<NestedRecord> Records) : Error(Key, Message)
{
	public static readonly ComplexError One = new("key", "msg", "one", 1, new(2, "two"), [
		new(3, "three"),
		new(4, "four")
	]);

	public record NestedRecord(int A, string B);
}
