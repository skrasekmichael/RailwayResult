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

	public TOut Match<TOut>(Func<TOut> onSuccessMap, Func<Error, TOut> onFailureMap)
	{
		return IsSuccess ? onSuccessMap() : onFailureMap(_error!);
	}

	public override string ToString()
	{
		return IsSuccess switch
		{
			true => "Result SUCCESS",
			false => "Result FAILURE " + _error!.ToString()
		};
	}

	public static readonly Result Success = new();

	public static implicit operator Result(Error error) => new(error);
}
