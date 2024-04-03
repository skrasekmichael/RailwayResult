namespace RailwayResult.FunctionalExtensions.Benchmarks.Data;

public sealed record FractionMember
{
	public required Guid Id { get; init; }
	public required Guid BeingId { get; init; }
	public required string Name { get; set; }
	public required Rank Rank { get; set; }
}
