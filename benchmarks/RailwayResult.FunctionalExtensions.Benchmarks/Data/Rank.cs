namespace RailwayResult.FunctionalExtensions.Benchmarks.Data;

public sealed record Rank
{
	public required Guid Id { get; init; }
	public required string Name { get; set; }
	public required Permission Permissions { get; set; }
	public bool IsHeadOfFraction { get; init; } = false;
}
