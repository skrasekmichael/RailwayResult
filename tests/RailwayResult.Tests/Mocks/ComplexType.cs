using static RailwayResults.Tests.Mocks.ComplexError;

namespace RailwayResults.Tests.Mocks;

public sealed record ComplexType(
	string Data,
	int Int,
	NestedRecord Record,
	List<NestedRecord> Records)
{
	public static readonly ComplexType Data1A2B3C = new("Data", 0, new(1, "A"), [
		new(2, "B"),
		new(3, "C")
	]);

	public record NestedRecord(int Index, string Letter);
}
