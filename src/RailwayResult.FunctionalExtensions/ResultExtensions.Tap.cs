namespace RailwayResult.FunctionalExtensions;

public static partial class ResultExtensions
{
	public static Result Tap(this Result result, Action func)
	{
		if (result.IsSuccess)
			func();

		return result;
	}

	public static async Task<Result> Tap(this Task<Result> resultTask, Action func)
	{
		var result = await resultTask;
		return result.Tap(func);
	}

	public static Result Tap(this Result result, Func<Result> func)
	{
		if (result.IsSuccess)
			return func();

		return result;
	}

	public static async Task<Result> Tap(this Task<Result> resultTask, Func<Result> func)
	{
		var result = await resultTask;
		return result.Tap(func);
	}

	public static Result<TValue> Tap<TValue>(this Result<TValue> result, Action<TValue> func)
	{
		if (result.IsSuccess)
			func(result.Value);

		return result;
	}

	public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<TValue>> resultTask, Action<TValue> func)
	{
		var result = await resultTask;
		return result.Tap(func);
	}

	public static Result<TValue> Tap<TValue>(this Result<TValue> result, Func<TValue, Result> func)
	{
		if (result.IsFailure)
			return result;

		var nestedResult = func(result.Value);
		if (nestedResult.IsFailure)
			return nestedResult.Error;

		return result;
	}

	public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Result> func)
	{
		var result = await resultTask;
		return result.Tap(func);
	}

	public static Result<(TFirst, TSecond)> Tap<TFirst, TSecond>(this Result<(TFirst, TSecond)> result, Action<TFirst, TSecond> func)
	{
		if (result.IsSuccess)
			func(result.Value.Item1, result.Value.Item2);

		return result;
	}

	public static async Task<Result<(TFirst, TSecond)>> Tap<TFirst, TSecond>(this Task<Result<(TFirst, TSecond)>> resultTask, Action<TFirst, TSecond> func)
	{
		var result = await resultTask;
		return result.Tap(func);
	}

	public static Result<(TFirst, TSecond)> Tap<TFirst, TSecond>(this Result<(TFirst, TSecond)> result, Func<TFirst, TSecond, Result> func)
	{
		if (result.IsFailure)
			return result;

		var nestedResult = func(result.Value.Item1, result.Value.Item2);
		if (nestedResult.IsFailure)
			return nestedResult.Error;

		return result;
	}

	public static async Task<Result<(TFirst, TSecond)>> Tap<TFirst, TSecond>(this Task<Result<(TFirst, TSecond)>> resultTask, Func<TFirst, TSecond, Result> func)
	{
		var result = await resultTask;
		return result.Tap(func);
	}

	[Obsolete("This methods seems useless, as Then methods should always unwrap returning result object.")]
	public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<Result<TValue>>> resultTask, Action<TValue> func)
	{
		var result = await resultTask;
		if (result.IsFailure)
			return result.Error;

		return result.Value.Tap(func);
	}
}
