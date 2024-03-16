using RailwayResult.Exceptions;

namespace RailwayResult;

public sealed class Result
{
	public bool IsSuccess { get; }
	public bool IsFailure => !IsSuccess;

	private readonly ErrorBase? _error = null;
	public ErrorBase Error => IsFailure ? _error! : throw new AccessingErrorOfSuccessResultException();

	public Result(ErrorBase error)
	{
		IsSuccess = false;
		_error = error;
	}

	private Result()
	{
		IsSuccess = true;
		_error = null;
	}

	public static readonly Result Success = new();

	public static implicit operator Result(ErrorBase error) => new(error);
}
