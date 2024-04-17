using System.Text.Json.Serialization;

using RailwayResult.Exceptions;
using RailwayResult.JsonConverters;

namespace RailwayResult;

[JsonConverter(typeof(GenericResultJsonConverterFactory))]
public sealed class Result<TValue> : IResult<TValue>
{
	public bool IsSuccess => _error is null;

	public bool IsFailure => !IsSuccess;

	private readonly TValue? _value;

	public TValue Value => IsSuccess ? _value! : throw new AccessingValueOfFailureResultException();

	private readonly Error? _error = null;

	public Error Error => IsFailure ? _error! : throw new AccessingErrorOfSuccessResultException();

	public Result(Error error)
	{
		_error = error;
		_value = default;
	}

	private Result(TValue? value)
	{
		_error = null;
		_value = value;
	}

	public TOut Match<TOut>(Func<TValue, TOut> onSuccessMap, Func<Error, TOut> onFailureMap)
	{
		return IsSuccess ? onSuccessMap(_value!) : onFailureMap(_error!);
	}

	public override string ToString()
	{
		return IsSuccess switch
		{
			true => "Result SUCCESS " + _value!.ToString(),
			false => "Result FAILURE " + _error!.ToString()
		};
	}

	public static Result<TValue> Success(TValue value) => new(value);

	public static IResult<TValue> FromValue(TValue value) => new Result<TValue>(value);
	public static IResult FromError<TError>(TError error) where TError : Error => new Result<TValue>(error);

	public static implicit operator Result<TValue>(TValue? value) => new(value);
	public static implicit operator Result<TValue>(Error error) => new(error);
}
