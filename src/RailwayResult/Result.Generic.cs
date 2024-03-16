using RailwayResult.Exceptions;

namespace RailwayResult;

public sealed class Result<TValue>
{
	public bool IsSuccess { get; }
	public bool IsFailure => !IsSuccess;

	private readonly TValue? _value;
	public TValue Value => IsSuccess ? _value! : throw new AccessingValueOfFailureResultException();

	private readonly Error? _error = null;
	public Error Error => IsFailure ? _error! : throw new AccessingErrorOfSuccessResultException();

	private Result(Error error)
	{
		IsSuccess = false;
		_error = error;
		_value = default;
	}

	private Result(TValue? value)
	{
		IsSuccess = true;
		_error = null;
		_value = value;
	}

	public TOut Match<TOut>(Func<TValue, TOut> successMap, Func<Error, TOut> failureMap)
	{
		return IsSuccess ? successMap(_value!) : failureMap(_error!);
	}

	public static Result<TValue> Success(TValue value) => new(value);

	public static implicit operator Result<TValue>(TValue? value) => new(value);
	public static implicit operator Result<TValue>(Error error) => new(error);
}
