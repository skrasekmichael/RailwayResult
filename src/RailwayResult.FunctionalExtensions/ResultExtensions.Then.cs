﻿namespace RailwayResult.FunctionalExtensions;

public static partial class ResultExtensions
{
	public static Result Then<TValue>(this Result<TValue> result, Func<TValue, Result> mapper)
	{
		if (result.IsFailure)
			return result.Error;

		return mapper(result.Value);
	}

	public static async Task<Result> Then<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Result> mapper)
	{
		var result = await resultTask;
		return result.Then(mapper);
	}

	public static Result<TOut> Then<TValue, TOut>(this Result<TValue> result, Func<TValue, TOut> mapper)
	{
		if (result.IsFailure)
			return result.Error;

		return mapper(result.Value);
	}

	public static async Task<Result<TOut>> Then<TValue, TOut>(this Task<Result<TValue>> resultTask, Func<TValue, TOut> mapper)
	{
		var result = await resultTask;
		return result.Then(mapper);
	}

	public static Result<TOut> Then<TValue, TOut>(this Result<TValue> result, Func<TValue, Result<TOut>> mapper)
	{
		if (result.IsFailure)
			return result.Error;

		return mapper(result.Value);
	}

	public static async Task<Result<TOut>> Then<TValue, TOut>(this Task<Result<TValue>> resultTask, Func<TValue, Result<TOut>> mapper)
	{
		var result = await resultTask;
		return result.Then(mapper);
	}

	public static Result Then<TFirst, TSecond>(this Result<(TFirst, TSecond)> result, Func<TFirst, TSecond, Result> mapper)
	{
		if (result.IsFailure)
			return result.Error;

		return mapper(result.Value.Item1, result.Value.Item2);
	}

	public static async Task<Result> Then<TFirst, TSecond>(this Task<Result<(TFirst, TSecond)>> resultTask, Func<TFirst, TSecond, Result> mapper)
	{
		var result = await resultTask;
		return result.Then(mapper);
	}

	public static Result<TOut> Then<TFirst, TSecond, TOut>(this Result<(TFirst, TSecond)> result, Func<TFirst, TSecond, TOut> mapper)
	{
		if (result.IsFailure)
			return result.Error;

		return mapper(result.Value.Item1, result.Value.Item2);
	}

	public static async Task<Result<TOut>> Then<TFirst, TSecond, TOut>(this Task<Result<(TFirst, TSecond)>> selfTask, Func<TFirst, TSecond, TOut> mapper)
	{
		var self = await selfTask;
		return self.Then(mapper);
	}

	public static Result<TOut> Then<TFirst, TSecond, TOut>(this Result<(TFirst, TSecond)> result, Func<TFirst, TSecond, Result<TOut>> mapper)
	{
		if (result.IsFailure)
			return result.Error;

		return mapper(result.Value.Item1, result.Value.Item2);
	}

	public static async Task<Result<TOut>> Then<TFirst, TSecond, TOut>(this Task<Result<(TFirst, TSecond)>> resultTask, Func<TFirst, TSecond, Result<TOut>> mapper)
	{
		var result = await resultTask;
		return result.Then(mapper);
	}

	public static Result Then<TFirst, TSecond, TThird>(this Result<(TFirst, TSecond, TThird)> result, Func<TFirst, TSecond, TThird, Result> mapper)
	{
		if (result.IsFailure)
			return result.Error;

		return mapper(result.Value.Item1, result.Value.Item2, result.Value.Item3);
	}

	public static async Task<Result> Then<TFirst, TSecond, TThird>(this Task<Result<(TFirst, TSecond, TThird)>> resultTask, Func<TFirst, TSecond, TThird, Result> mapper)
	{
		var result = await resultTask;
		return result.Then(mapper);
	}

	public static Result<TOut> Then<TFirst, TSecond, TThird, TOut>(this Result<(TFirst, TSecond, TThird)> result, Func<TFirst, TSecond, TThird, TOut> mapper)
	{
		if (result.IsFailure)
			return result.Error;

		return mapper(result.Value.Item1, result.Value.Item2, result.Value.Item3);
	}

	public static async Task<Result<TOut>> Then<TFirst, TSecond, TThird, TOut>(this Task<Result<(TFirst, TSecond, TThird)>> resultTask, Func<TFirst, TSecond, TThird, TOut> mapper)
	{
		var result = await resultTask;
		return result.Then(mapper);
	}

	public static Result<TOut> Then<TFirst, TSecond, TThird, TOut>(this Result<(TFirst, TSecond, TThird)> result, Func<TFirst, TSecond, TThird, Result<TOut>> mapper)
	{
		if (result.IsFailure)
			return result.Error;

		return mapper(result.Value.Item1, result.Value.Item2, result.Value.Item3);
	}

	public static async Task<Result<TOut>> Then<TFirst, TSecond, TThird, TOut>(this Task<Result<(TFirst, TSecond, TThird)>> resultTask, Func<TFirst, TSecond, TThird, Result<TOut>> mapper)
	{
		var result = await resultTask;
		return result.Then(mapper);
	}
}
