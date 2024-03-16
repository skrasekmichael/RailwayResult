namespace RailwayResult.FunctionExtensions;

public static partial class ResultExtensions
{
	public static Result ToResult<TValue>(this Result<TValue> result)
	{
		if (result.IsFailure)
			return result.Error;

		return Result.Success;
	}

	public static async Task<Result> ToResultAsync<TValue>(this Task<Result<TValue>> resultTask)
	{
		var result = await resultTask;
		return result.ToResult();
	}
}
