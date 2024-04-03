namespace RailwayResult.FunctionalExtensions.Benchmarks.Data;

public sealed record Tag
{
	public required Guid Id { get; init; }
	public required string Name { get; set; }
}
