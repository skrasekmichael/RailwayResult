namespace RailwayResult;

public static partial class ResultExtensions
{
	public static async Task<Result> OnErrorAsync<TError>(this Result result, Func<Task> asyncFunc) where TError : Error
	{
		if (result.IsFailure && result.Error is TError)
			await asyncFunc();

		return result;
	}

	public static async Task<Result> OnErrorAsync<TError>(this Result result, Func<TError, Task> asyncFunc) where TError : Error
	{
		if (result.IsFailure && result.Error is TError error)
			await asyncFunc(error);

		return result;
	}

	public static async Task<Result> OnErrorAsync<TError>(this Task<Result> resultTask, Func<Task> asyncFunc) where TError : Error
	{
		var result = await resultTask;
		if (result.IsFailure && result.Error is TError)
			await asyncFunc();

		return result;
	}

	public static async Task<Result> OnErrorAsync<TError>(this Task<Result> resultTask, Func<TError, Task> asyncFunc) where TError : Error
	{
		var result = await resultTask;
		if (result.IsFailure && result.Error is TError error)
			await asyncFunc(error);

		return result;
	}

	public static async Task<Result<TValue>> OnErrorAsync<TValue, TError>(this Result<TValue> result, Func<Task> asyncFunc) where TError : Error
	{
		if (result.IsFailure && result.Error is TError)
			await asyncFunc();

		return result;
	}

	public static async Task<Result<TValue>> OnErrorAsync<TValue, TError>(this Result<TValue> result, Func<TError, Task> asyncFunc) where TError : Error
	{
		if (result.IsFailure && result.Error is TError error)
			await asyncFunc(error);

		return result;
	}

	public static async Task<Result<TValue>> OnErrorAsync<TValue, TError>(this Task<Result<TValue>> resultTask, Func<Task> asyncFunc) where TError : Error
	{
		var result = await resultTask;
		if (result.IsFailure && result.Error is TError)
			await asyncFunc();

		return result;
	}

	public static async Task<Result<TValue>> OnErrorAsync<TValue, TError>(this Task<Result<TValue>> resultTask, Func<TError, Task> asyncFunc) where TError : Error
	{
		var result = await resultTask;
		if (result.IsFailure && result.Error is TError error)
			await asyncFunc(error);

		return result;
	}
}
