namespace RailwayResult.FunctionalExtensions;

public static partial class ResultExtensions
{
	public static Result<(TFirst, TSecond)> And<TFirst, TSecond>(this Result<TFirst> result, Func<TSecond> func)
	{
		if (result.IsFailure)
			return result.Error;

		return (result.Value, func());
	}

	public static async Task<Result<(TFirst, TSecond)>> And<TFirst, TSecond>(this Task<Result<TFirst>> resultTask, Func<TSecond> func)
	{
		var result = await resultTask;
		return result.And(func);
	}

	public static Result<(TFirst, TSecond)> And<TFirst, TSecond>(this Result<TFirst> result, Func<Result<TSecond>> func)
	{
		if (result.IsFailure)
			return result.Error;

		var nestedResult = func();
		if (nestedResult.IsFailure)
			return nestedResult.Error;

		return (result.Value, nestedResult.Value);
	}

	public static async Task<Result<(TFirst, TSecond)>> And<TFirst, TSecond>(this Task<Result<TFirst>> resultTask, Func<Result<TSecond>> func)
	{
		var result = await resultTask;
		return result.And(func);
	}

	public static Result<(TFirst, TSecond)> And<TFirst, TSecond>(this Result<TFirst> result, Func<TFirst, Result<TSecond>> func)
	{
		if (result.IsFailure)
			return result.Error;

		var nestedResult = func(result.Value);
		if (nestedResult.IsFailure)
			return nestedResult.Error;

		return (result.Value, nestedResult.Value);
	}

	public static async Task<Result<(TFirst, TSecond)>> And<TFirst, TSecond>(this Task<Result<TFirst>> resultTask, Func<TFirst, Result<TSecond>> func)
	{
		var result = await resultTask;
		return result.And(func);
	}

	public static Result<(TFirst, TSecond, TThird)> And<TFirst, TSecond, TThird>(this Result<(TFirst, TSecond)> result, Func<TFirst, TSecond, Result<TThird>> func)
	{
		if (result.IsFailure)
			return result.Error;

		var nestedResult = func(result.Value.Item1, result.Value.Item2);
		if (nestedResult.IsFailure)
			return nestedResult.Error;

		return (result.Value.Item1, result.Value.Item2, nestedResult.Value);
	}

	public static async Task<Result<(TFirst, TSecond, TThird)>> And<TFirst, TSecond, TThird>(this Task<Result<(TFirst, TSecond)>> resultTask, Func<TFirst, TSecond, Result<TThird>> func)
	{
		var result = await resultTask;
		return result.And(func);
	}

	public static async Task<Result<(TFirst, TSecond)>> AndAsync<TFirst, TSecond>(this Result<TFirst> result, Func<TFirst, Task<TSecond>> asyncFunc)
	{
		if (result.IsFailure)
			return result.Error;

		return (result.Value, await asyncFunc(result.Value));
	}

	public static async Task<Result<(TFirst, TSecond)>> AndAsync<TFirst, TSecond>(this Task<Result<TFirst>> resultTask, Func<TFirst, Task<TSecond>> asyncFunc)
	{
		var result = await resultTask;
		return await result.AndAsync(asyncFunc);
	}

	public static async Task<Result<(TFirst, TSecond)>> AndAsync<TFirst, TSecond>(this Result<TFirst> result, Func<TFirst, Task<Result<TSecond>>> asyncFunc)
	{
		if (result.IsFailure)
			return result.Error;

		var nestedResult = await asyncFunc(result.Value);
		if (nestedResult.IsFailure)
			return nestedResult.Error;

		return (result.Value, nestedResult.Value);
	}

	public static async Task<Result<(TFirst, TSecond)>> AndAsync<TFirst, TSecond>(this Task<Result<TFirst>> resultTask, Func<TFirst, Task<Result<TSecond>>> asyncFunc)
	{
		var result = await resultTask;
		return await result.AndAsync(asyncFunc);
	}
}
