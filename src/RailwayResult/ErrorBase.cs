namespace RailwayResult;

public abstract record ErrorBase
{
	public string Key { get; protected init; } = null!;
	public string Message { get; protected init; } = null!;
}
