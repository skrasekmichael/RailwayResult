namespace RailwayResult.FunctionalExtensions.Tests.Data;

public sealed record Obj(string? Value)
{
	public static implicit operator O(string? value) => new(value);

	public static readonly O Null = new(null);
	public static readonly O Empty = new(string.Empty);
	public static readonly O A = new("A");
	public static readonly O B = new("B");
	public static readonly O C = new("C");
}
