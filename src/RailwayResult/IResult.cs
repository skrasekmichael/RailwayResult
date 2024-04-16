namespace RailwayResult;

public interface IResult
{
	public bool IsSuccess { get; }
	public bool IsFailure { get; }
	public Error Error { get; }

	public static abstract IResult FromError<TError>(TError error) where TError : Error;
}

public interface IResult<TValue> : IResult
{
	public TValue Value { get; }

	public static abstract IResult<TValue> FromValue(TValue value);
}
