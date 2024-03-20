namespace RailwayResult;

public static partial class ResultExtensions
{
	public static async Task<Result> ThenAsync<TValue>(this Result<TValue> result, Func<TValue, Task<Result>> asyncMapper)
	{
		if (result.IsFailure)
			return result.Error;

		return await asyncMapper(result.Value);
	}

	public static async Task<Result> ThenAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<Result>> asyncMapper)
	{
		var result = await resultTask;
		return await result.ThenAsync(asyncMapper);
	}

	public static async Task<Result<TOut>> ThenAsync<TValue, TOut>(this Result<TValue> result, Func<TValue, Task<TOut>> asyncMapper)
	{
		if (result.IsFailure)
			return result.Error;

		return await asyncMapper(result.Value);
	}

	public static async Task<Result<TOut>> ThenAsync<TValue, TOut>(this Task<Result<TValue>> resultTask, Func<TValue, Task<TOut>> asyncMapper)
	{
		var result = await resultTask;
		return await result.ThenAsync(asyncMapper);
	}

	public static async Task<Result<TOut>> ThenAsync<TValue, TOut>(this Result<TValue> result, Func<TValue, Task<Result<TOut>>> asyncMapper)
	{
		if (result.IsFailure)
			return result.Error;

		return await asyncMapper(result.Value);
	}

	public static async Task<Result<TOut>> ThenAsync<TValue, TOut>(this Task<Result<TValue>> resultTask, Func<TValue, Task<Result<TOut>>> asyncMapper)
	{
		var result = await resultTask;
		return await result.ThenAsync(asyncMapper);
	}

	public static async Task<Result> ThenAsync<TFirst, TSecond>(this Result<(TFirst, TSecond)> result, Func<TFirst, TSecond, Task<Result>> asyncMapper)
	{
		if (result.IsFailure)
			return result.Error;

		return await asyncMapper(result.Value.Item1, result.Value.Item2);
	}

	public static async Task<Result> ThenAsync<TFirst, TSecond>(this Task<Result<(TFirst, TSecond)>> resultTask, Func<TFirst, TSecond, Task<Result>> asyncMapper)
	{
		var result = await resultTask;
		return await result.ThenAsync(asyncMapper);
	}

	public static async Task<Result<TOut>> ThenAsync<TFirst, TSecond, TOut>(this Result<(TFirst, TSecond)> result, Func<TFirst, TSecond, Task<TOut>> asyncMapper)
	{
		if (result.IsFailure)
			return result.Error;

		return await asyncMapper(result.Value.Item1, result.Value.Item2);
	}

	public static async Task<Result<TOut>> ThenAsync<TFirst, TSecond, TOut>(this Task<Result<(TFirst, TSecond)>> selfTask, Func<TFirst, TSecond, Task<TOut>> asyncMapper)
	{
		var self = await selfTask;
		return await self.ThenAsync(asyncMapper);
	}

	public static async Task<Result<TOut>> ThenAsync<TFirst, TSecond, TOut>(this Result<(TFirst, TSecond)> result, Func<TFirst, TSecond, Task<Result<TOut>>> asyncMapper)
	{
		if (result.IsFailure)
			return result.Error;

		return await asyncMapper(result.Value.Item1, result.Value.Item2);
	}

	public static async Task<Result<TOut>> ThenAsync<TFirst, TSecond, TOut>(this Task<Result<(TFirst, TSecond)>> resultTask, Func<TFirst, TSecond, Task<Result<TOut>>> asyncMapper)
	{
		var result = await resultTask;
		return await result.ThenAsync(asyncMapper);
	}

	public static async Task<Result> ThenAsync<TFirst, TSecond, TThird>(this Result<(TFirst, TSecond, TThird)> result, Func<TFirst, TSecond, TThird, Task<Result>> asyncMapper)
	{
		if (result.IsFailure)
			return result.Error;

		return await asyncMapper(result.Value.Item1, result.Value.Item2, result.Value.Item3);
	}

	public static async Task<Result> ThenAsync<TFirst, TSecond, TThird>(this Task<Result<(TFirst, TSecond, TThird)>> resultTask, Func<TFirst, TSecond, TThird, Task<Result>> asyncMapper)
	{
		var result = await resultTask;
		return await result.ThenAsync(asyncMapper);
	}

	public static async Task<Result<TOut>> ThenAsync<TFirst, TSecond, TThird, TOut>(this Result<(TFirst, TSecond, TThird)> result, Func<TFirst, TSecond, TThird, Task<TOut>> asyncMapper)
	{
		if (result.IsFailure)
			return result.Error;

		return await asyncMapper(result.Value.Item1, result.Value.Item2, result.Value.Item3);
	}

	public static async Task<Result<TOut>> ThenAsync<TFirst, TSecond, TThird, TOut>(this Task<Result<(TFirst, TSecond, TThird)>> resultTask, Func<TFirst, TSecond, TThird, Task<TOut>> asyncMapper)
	{
		var result = await resultTask;
		return await result.ThenAsync(asyncMapper);
	}

	public static async Task<Result<TOut>> ThenAsync<TFirst, TSecond, TThird, TOut>(this Result<(TFirst, TSecond, TThird)> result, Func<TFirst, TSecond, TThird, Task<Result<TOut>>> asyncMapper)
	{
		if (result.IsFailure)
			return result.Error;

		return await asyncMapper(result.Value.Item1, result.Value.Item2, result.Value.Item3);
	}

	public static async Task<Result<TOut>> ThenAsync<TFirst, TSecond, TThird, TOut>(this Task<Result<(TFirst, TSecond, TThird)>> resultTask, Func<TFirst, TSecond, TThird, Task<Result<TOut>>> asyncMapper)
	{
		var result = await resultTask;
		return await result.ThenAsync(asyncMapper);
	}
}
