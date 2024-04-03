using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Extensions;

namespace RailwayResult.FunctionalExtensions.Tests.Tests;

public abstract class BaseTests
{
	protected static void Verify<T>(Func<Result<T>, Result> method, Result<T> input, Result? expectedOutput)
	{
		if (expectedOutput is null)
		{
			var accessor = () => method.Invoke(input);
			accessor.Should().ThrowExactly<BasicException>();
		}
		else
		{
			method.Invoke(input).ShouldBe(expectedOutput);
		}
	}

	protected static void Verify<T1, T2>(Func<T1, Result<T2>> method, T1 input, Result<T2>? expectedOutput)
	{
		if (expectedOutput is null)
		{
			var accessor = () => method.Invoke(input);
			accessor.Should().ThrowExactly<BasicException>();
		}
		else
		{
			method.Invoke(input).ShouldBe(expectedOutput);
		}
	}

	protected static void Verify<T1, T2>(Func<Result<T1>, Result<T2>> method, Result<T1> input, Result<T2>? expectedOutput)
	{
		if (expectedOutput is null)
		{
			var accessor = () => method.Invoke(input);
			accessor.Should().ThrowExactly<BasicException>();
		}
		else
		{
			method.Invoke(input).ShouldBe(expectedOutput);
		}
	}

	protected static async Task VerifyAsync<T>(Func<Task<Result<T>>, Task<Result>> asyncMethod, Result<T> input, Result? expectedOutput)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(Task.FromResult(input));
			await accessor.Should().ThrowExactlyAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(Task.FromResult(input));
			result.ShouldBe(expectedOutput);
		}
	}

	protected static async Task VerifyAsync<T1, T2>(Func<Task<T1>, Task<Result<T2>>> asyncMethod, T1 input, Result<T2>? expectedOutput)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(Task.FromResult(input));
			await accessor.Should().ThrowExactlyAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(Task.FromResult(input));
			result.ShouldBe(expectedOutput);
		}
	}

	protected static async Task VerifyAsync<T1, T2>(Func<Task<Result<T1>>, Task<Result<T2>>> asyncMethod, Result<T1> input, Result<T2>? expectedOutput)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(Task.FromResult(input));
			await accessor.Should().ThrowExactlyAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(Task.FromResult(input));
			result.ShouldBe(expectedOutput);
		}
	}

	protected static async Task VerifyAsync<T>(Func<Result<T>, Task<Result>> asyncMethod, Result<T> input, Result? expectedOutput)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(input);
			await accessor.Should().ThrowExactlyAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(input);
			result.ShouldBe(expectedOutput);
		}
	}

	protected static async Task VerifyAsync<T1, T2>(Func<Result<T1>, Task<Result<T2>>> asyncMethod, Result<T1> input, Result<T2>? expectedOutput)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(input);
			await accessor.Should().ThrowExactlyAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(input);
			result.ShouldBe(expectedOutput);
		}
	}
}
