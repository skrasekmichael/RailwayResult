namespace RailwayResult.FunctionExtensions;

public static partial class ResultExtensions
{
	public static Result<TObj> Ensure<TObj, TError>(this TObj obj, Rule<TObj> rule, TError error) where TError : ErrorBase
	{
		if (!rule(obj))
			return error;

		return obj;
	}

	public static async Task<Result<TObj>> Ensure<TObj, TError>(this Task<TObj> objTask, Rule<TObj> rule, TError error) where TError : ErrorBase
	{
		var obj = await objTask;
		return obj.Ensure(rule, error);
	}

	public static Result<TObj> Ensure<TObj, TRule>(this TObj obj, params TRule[] rules) where TRule : IRuleWithError<TObj>
	{
		foreach (var rule in rules)
		{
			var ruleResult = rule.Apply(obj);
			if (ruleResult.IsFailure)
				return ruleResult;
		}

		return obj;
	}

	public static async Task<Result<TObj>> Ensure<TObj, TRule>(this Task<TObj> objTask, params TRule[] rules) where TRule : IRuleWithError<TObj>
	{
		var obj = await objTask;
		return obj.Ensure(rules);
	}

	public static Result<TValue> Ensure<TValue, TError>(this Result<TValue> result, Rule<TValue> rule, TError error) where TError : ErrorBase
	{
		if (result.IsFailure)
			return result;

		if (!rule(result.Value))
			return error;

		return result;
	}

	public static async Task<Result<TValue>> Ensure<TValue, TError>(this Task<Result<TValue>> selfTask, Rule<TValue> rule, TError error) where TError : ErrorBase
	{
		var self = await selfTask;
		return self.Ensure(rule, error);
	}

	public static Result<TValue> Ensure<TValue, TRule>(this Result<TValue> result, params TRule[] rules) where TRule : IRuleWithError<TValue>
	{
		if (result.IsFailure)
			return result;

		foreach (var rule in rules)
		{
			var ruleResult = rule.Apply(result.Value);
			if (ruleResult.IsFailure)
				return ruleResult;
		}

		return result;
	}

	public static async Task<Result<TValue>> Ensure<TValue, TRule>(this Task<Result<TValue>> resultTask, params TRule[] rules) where TRule : IRuleWithError<TValue>
	{
		var result = await resultTask;
		return result.Ensure(rules);
	}

	public static Result<(TFirst, TSecond)> Ensure<TFirst, TSecond, TError>(this Result<(TFirst, TSecond)> result, Rule<TFirst, TSecond> rule, TError error) where TError : ErrorBase
	{
		if (result.IsFailure)
			return result;

		if (!rule(result.Value.Item1, result.Value.Item2))
			return error;

		return result;
	}

	public static async Task<Result<(TFirst, TSecond)>> Ensure<TFirst, TSecond, TError>(this Task<Result<(TFirst, TSecond)>> selfTask, Rule<TFirst, TSecond> rule, TError error) where TError : ErrorBase
	{
		var self = await selfTask;
		return self.Ensure(rule, error);
	}

	public static Result<(TFirst, TSecond)> Ensure<TFirst, TSecond, TRule>(this Result<(TFirst, TSecond)> self, TRule rule) where TRule : IRuleWithError<(TFirst, TSecond)>
	{
		if (self.IsFailure)
			return self;

		return rule.Apply(self.Value);
	}

	public static async Task<Result<(TFirst, TSecond)>> Ensure<TFirst, TSecond, TRule>(this Task<Result<(TFirst, TSecond)>> selfTask, TRule rule) where TRule : IRuleWithError<(TFirst, TSecond)>
	{
		var self = await selfTask;
		return self.Ensure(rule);
	}
}
