namespace RailwayResult;

public interface IResult
{
	public bool IsSuccess { get; }
	public bool IsFailure { get; }
	public Error Error { get; }
}

public interface IResult<TValue> : IResult
{
	public TValue Value { get; }
}
