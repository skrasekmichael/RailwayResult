namespace RailwayResult;

public static partial class ResultExtensions
{
	public static async Task<Result> TapAsync(this Result result, Func<Task> asyncFunc)
	{
		if (result.IsSuccess)
			await asyncFunc();

		return result;
	}

	public static async Task<Result> TapAsync(this Task<Result> resultTask, Func<Task> asyncFunc)
	{
		var result = await resultTask;
		return await result.TapAsync(asyncFunc);
	}

	public static async Task<Result> TapAsync(this Result result, Func<Task<Result>> asyncFunc)
	{
		if (result.IsSuccess)
			return await asyncFunc();

		return result;
	}

	public static async Task<Result> TapAsync(this Task<Result> resultTask, Func<Task<Result>> asyncFunc)
	{
		var result = await resultTask;
		return await result.TapAsync(asyncFunc);
	}

	public static async Task<Result<TValue>> TapAsync<TValue>(this Result<TValue> result, Func<TValue, Task> asyncFunc)
	{
		if (result.IsSuccess)
			await asyncFunc(result.Value);

		return result;
	}

	public static async Task<Result<TValue>> TapAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task> asyncFunc)
	{
		var result = await resultTask;
		return await result.TapAsync(asyncFunc);
	}

	public static async Task<Result<TValue>> TapAsync<TValue>(this Result<TValue> result, Func<TValue, Task<Result>> asyncFunc)
	{
		if (result.IsFailure)
			return result;

		var nestedResult = await asyncFunc(result.Value);
		if (nestedResult.IsFailure)
			return nestedResult.Error;

		return result;
	}

	public static async Task<Result<TValue>> TapAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<Result>> asyncFunc)
	{
		var result = await resultTask;
		return await result.TapAsync(asyncFunc);
	}

	public static async Task<Result<(TFirst, TSecond)>> TapAsync<TFirst, TSecond>(this Result<(TFirst, TSecond)> result, Func<TFirst, TSecond, Task> asyncFunc)
	{
		if (result.IsSuccess)
			await asyncFunc(result.Value.Item1, result.Value.Item2);

		return result;
	}

	public static async Task<Result<(TFirst, TSecond)>> TapAsync<TFirst, TSecond>(this Task<Result<(TFirst, TSecond)>> resultTask, Func<TFirst, TSecond, Task> asyncFunc)
	{
		var result = await resultTask;
		return await result.TapAsync(asyncFunc);
	}

	public static async Task<Result<(TFirst, TSecond)>> TapAsync<TFirst, TSecond>(this Result<(TFirst, TSecond)> result, Func<TFirst, TSecond, Task<Result>> asyncFunc)
	{
		if (result.IsFailure)
			return result;

		var nestedResult = await asyncFunc(result.Value.Item1, result.Value.Item2);
		if (nestedResult.IsFailure)
			return nestedResult.Error;

		return result;
	}

	public static async Task<Result<(TFirst, TSecond)>> TapAsync<TFirst, TSecond>(this Task<Result<(TFirst, TSecond)>> resultTask, Func<TFirst, TSecond, Task<Result>> asyncFunc)
	{
		var result = await resultTask;
		return await result.TapAsync(asyncFunc);
	}
}
