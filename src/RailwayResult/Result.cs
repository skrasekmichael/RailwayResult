using RailwayResult.Exceptions;

namespace RailwayResult;

public sealed class Result
{
	public bool IsSuccess { get; }
	public bool IsFailure => !IsSuccess;

	private readonly Error? _error = null;
	public Error Error => IsFailure ? _error! : throw new AccessingErrorOfSuccessResultException();

	public Result(Error error)
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

	public static implicit operator Result(Error error) => new(error);
}
