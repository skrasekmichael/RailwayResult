namespace RailwayResult.FunctionExtensions;

public static partial class ResultExtensions
{
	public static Result<TValue> Tap<TValue>(this Result<TValue> result, Action<TValue> func)
	{
		if (result.IsFailure)
			return result;

		func(result.Value);
		return result;
	}

	public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<TValue>> resultTask, Action<TValue> func)
	{
		var result = await resultTask;
		return result.Tap(func);
	}

	public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<Result<TValue>>> resultTask, Action<TValue> func)
	{
		var result = await resultTask;
		if (result.IsFailure)
			return result.Error;

		return result.Value.Tap(func);
	}

	public static Result<(TFirst, TSecond)> Tap<TFirst, TSecond>(this Result<(TFirst, TSecond)> result, Action<TFirst, TSecond> func)
	{
		if (result.IsFailure)
			return result;

		func(result.Value.Item1, result.Value.Item2);
		return result;
	}

	public static async Task<Result<(TFirst, TSecond)>> Tap<TFirst, TSecond>(this Task<Result<(TFirst, TSecond)>> resultTask, Action<TFirst, TSecond> func)
	{
		var result = await resultTask;
		return result.Tap(func);
	}

	public static async Task<Result> TapAsync(this Result result, Func<Task> asyncFunc)
	{
		if (result.IsFailure)
			return result.Error;

		await asyncFunc();
		return Result.Success;
	}

	public static async Task<Result> TapAsync(this Task<Result> resultTask, Func<Task> asyncFunc)
	{
		var result = await resultTask;
		return await result.TapAsync(asyncFunc);
	}

	public static async Task<Result<TValue>> TapAsync<TValue>(this Result<TValue> result, Func<TValue, Task> asyncFunc)
	{
		if (result.IsFailure)
			return result;

		await asyncFunc(result.Value);
		return result;
	}

	public static async Task<Result<TValue>> TapAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task> asyncFunc)
	{
		var result = await resultTask;
		return await result.TapAsync(asyncFunc);
	}
}
