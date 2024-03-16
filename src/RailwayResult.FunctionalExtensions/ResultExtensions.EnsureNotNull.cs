namespace RailwayResult.FunctionalExtensions;

public static partial class ResultExtensions
{
	public static Result<TObj> EnsureNotNull<TObj, TError>(this TObj? obj, TError error) where TError : ErrorBase
	{
		if (obj is null)
			return error;

		return obj;
	}

	public static async Task<Result<TObj>> EnsureNotNull<TObj, TError>(this Task<TObj?> objTask, TError error) where TError : ErrorBase
	{
		var obj = await objTask;
		return obj.EnsureNotNull(error);
	}

	public static Result<TValue> EnsureNotNull<TValue, TError>(this Result<TValue?> result, TError error) where TError : ErrorBase
	{
		if (result.IsFailure)
			return result.Error;

		if (result.Value is null)
			return error;

		return result.Value;
	}

	public static async Task<Result<TValue>> EnsureNotNull<TValue, TError>(this Task<Result<TValue?>> resultTask, TError error) where TError : ErrorBase
	{
		var result = await resultTask;
		return result.EnsureNotNull(error);
	}

	public static Result<TValue> EnsureNotNull<TValue, TProperty, TError>(this Result<TValue> result, Func<TValue, TProperty?> selector, TError error) where TError : ErrorBase
	{
		if (result.IsFailure)
			return result.Error;

		if (selector(result.Value) is null)
			return error;

		return result.Value;
	}

	public static async Task<Result<TValue>> EnsureNotNull<TValue, TProperty, TError>(this Task<Result<TValue>> resultTask, Func<TValue, TProperty?> selector, TError error) where TError : ErrorBase
	{
		var result = await resultTask;
		return result.EnsureNotNull(selector, error);
	}

	public static Result<(TFirst, TSecond)> EnsureNotNull<TFirst, TSecond, TProperty, TError>(this Result<(TFirst, TSecond)> result, Func<TFirst, TSecond, TProperty?> selector, TError error) where TError : ErrorBase
	{
		if (result.IsFailure)
			return result.Error;

		if (selector(result.Value.Item1, result.Value.Item2) is null)
			return error;

		return result.Value;
	}

	public static async Task<Result<(TFirst, TSecond)>> EnsureNotNull<TFirst, TSecond, TProperty, TError>(this Task<Result<(TFirst, TSecond)>> resultTask, Func<TFirst, TSecond, TProperty?> selector, TError error) where TError : ErrorBase
	{
		var result = await resultTask;
		return result.EnsureNotNull(selector, error);
	}

	public static Result<(TFirst, TSecond)> EnsureSecondNotNull<TFirst, TSecond, TError>(this Result<(TFirst, TSecond?)> result, TError error) where TError : ErrorBase
	{
		if (result.IsFailure)
			return result.Error;

		if (result.Value.Item2 is null)
			return error;

		return result.Value!;
	}

	public static async Task<Result<(TFirst, TSecond)>> EnsureSecondNotNull<TFirst, TSecond, TError>(this Task<Result<(TFirst, TSecond?)>> resultTask, TError error) where TError : ErrorBase
	{
		var result = await resultTask;
		return result.EnsureSecondNotNull(error);
	}
}
