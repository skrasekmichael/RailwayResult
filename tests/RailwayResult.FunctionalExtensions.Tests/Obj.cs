namespace RailwayResult.FunctionalExtensions.Tests;

public sealed record Obj(string? Value)
{
	public static implicit operator O(string? value) => new(value);

	public static readonly O Null = new(null);
	public static readonly O Empty = new(string.Empty);
}
