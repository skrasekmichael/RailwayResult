namespace RailwayResult.FunctionalExtensions.Tests;

public static class ErrorExtensions
{
	public static Result ToResult<TError>(this TError error) where TError : Error => error;

	public static Result<T> ToResult<T, TError>(this TError error) where TError : Error => error;

	public static Task<Result> ToResultTask<TError>(this TError error) where TError : Error
	{
		Result r = error;
		return Task.FromResult(r);
	}

	public static Task<Result<T>> ToResultTask<T, TError>(this TError error) where TError : Error
	{
		Result<T> r = error;
		return Task.FromResult(r);
	}
}
