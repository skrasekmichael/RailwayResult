namespace RailwayResult.FunctionExtensions;

public static partial class ResultExtensions
{
	public static Result<TObj> EnsureNotNull<TObj, TError>(this TObj? obj, TError error) where TError : ErrorBase
	{
		if (obj is null)
			return error;

		return obj;
	}

	public static Result<TValue> EnsureNotNull<TValue, TError>(this Result<TValue?> self, TError error) where TError : ErrorBase
	{
		if (self.IsFailure)
			return self.Error;

		if (self.Value is null)
			return error;

		return self.Value;
	}

	public static async Task<Result<TValue>> EnsureNotNull<TValue, TError>(this Task<Result<TValue?>> selfTask, TError error) where TError : ErrorBase
	{
		var self = await selfTask;
		return self.EnsureNotNull(error);
	}

	public static Result<TValue> EnsureNotNull<TValue, TProperty, TError>(this Result<TValue> self, Func<TValue, TProperty?> selector, TError error) where TError : ErrorBase
	{
		if (self.IsFailure)
			return self.Error;

		if (selector(self.Value) is null)
			return error;

		return self.Value;
	}

	public static Result<(TFirst, TSecond)> EnsureNotNull<TFirst, TSecond, TProperty, TError>(this Result<(TFirst, TSecond)> self, Func<TFirst, TSecond, TProperty?> selector, TError error) where TError : ErrorBase
	{
		if (self.IsFailure)
			return self.Error;

		if (selector(self.Value.Item1, self.Value.Item2) is null)
			return error;

		return self.Value;
	}

	public static async Task<Result<(TFirst, TSecond)>> EnsureNotNull<TFirst, TSecond, TProperty, TError>(this Task<Result<(TFirst, TSecond)>> selfTask, Func<TFirst, TSecond, TProperty?> selector, TError error) where TError : ErrorBase
	{
		var self = await selfTask;
		return self.EnsureNotNull(selector, error);
	}

	public static Result<(TFirst, TSecond)> EnsureSecondNotNull<TFirst, TSecond, TError>(this Result<(TFirst, TSecond?)> self, TError error) where TError : ErrorBase
	{
		if (self.IsFailure)
			return self.Error;

		if (self.Value.Item2 is null)
			return error;

		return self.Value!;
	}

	public static async Task<Result<(TFirst, TSecond)>> EnsureSecondNotNull<TFirst, TSecond, TError>(this Task<Result<(TFirst, TSecond?)>> selfTask, TError error) where TError : ErrorBase
	{
		var self = await selfTask;
		return self.EnsureSecondNotNull(error);
	}
}
