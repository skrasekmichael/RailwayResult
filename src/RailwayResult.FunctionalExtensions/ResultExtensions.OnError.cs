namespace RailwayResult;

public static partial class ResultExtensions
{
	public static Result OnError<TError>(this Result result, Action func) where TError : Error
	{
		if (result.IsFailure && result.Error is TError)
			func();

		return result;
	}

	public static Result OnError<TError>(this Result result, Action<TError> func) where TError : Error
	{
		if (result.IsFailure && result.Error is TError error)
			func(error);

		return result;
	}

	public static async Task<Result> OnError<TError>(this Task<Result> resultTask, Action func) where TError : Error
	{
		var result = await resultTask;
		if (result.IsFailure && result.Error is TError)
			func();

		return result;
	}

	public static async Task<Result> OnError<TError>(this Task<Result> resultTask, Action<TError> func) where TError : Error
	{
		var result = await resultTask;
		if (result.IsFailure && result.Error is TError error)
			func(error);

		return result;
	}

	public static Result<TValue> OnError<TValue, TError>(this Result<TValue> result, Action func) where TError : Error
	{
		if (result.IsFailure && result.Error is TError)
			func();

		return result;
	}

	public static Result<TValue> OnError<TValue, TError>(this Result<TValue> result, Action<TError> func) where TError : Error
	{
		if (result.IsFailure && result.Error is TError error)
			func(error);

		return result;
	}

	public static async Task<Result<TValue>> OnError<TValue, TError>(this Task<Result<TValue>> resultTask, Action func) where TError : Error
	{
		var result = await resultTask;
		if (result.IsFailure && result.Error is TError)
			func();

		return result;
	}

	public static async Task<Result<TValue>> OnError<TValue, TError>(this Task<Result<TValue>> resultTask, Action<TError> func) where TError : Error
	{
		var result = await resultTask;
		if (result.IsFailure && result.Error is TError error)
			func(error);

		return result;
	}
}
