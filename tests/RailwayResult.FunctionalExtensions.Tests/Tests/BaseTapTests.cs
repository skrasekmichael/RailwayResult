using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Extensions;

namespace RailwayResult.FunctionalExtensions.Tests.Tests;

public abstract class BaseTapTests
{
	protected Callback Callback { get; } = new();

	protected void Verify(Func<Result, Callback, Result> method, Result input, Result? expectedOutput, bool wasCallbackInvoked)
	{
		if (expectedOutput is null)
		{
			var accessor = () => method.Invoke(input, Callback);
			accessor.ShouldThrow<BasicException>();
		}
		else
		{
			method.Invoke(input, Callback).ShouldBe(expectedOutput);
		}

		Callback.WasCalled.ShouldBe(wasCallbackInvoked);
	}

	protected void Verify<T1, T2>(Func<Result<T1>, Callback, Result<T2>> method, Result<T1> input, Result<T2>? expectedOutput, bool wasCallbackInvoked)
	{
		if (expectedOutput is null)
		{
			var accessor = () => method.Invoke(input, Callback);
			accessor.ShouldThrow<BasicException>();
		}
		else
		{
			method.Invoke(input, Callback).ShouldBe(expectedOutput);
		}

		Callback.WasCalled.ShouldBe(wasCallbackInvoked);
	}

	protected async Task VerifyAsync(Func<Result, Callback, Task<Result>> asyncMethod, Result input, Result? expectedOutput, bool wasCallbackInvoked)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(input, Callback);
			await accessor.ShouldThrowAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(input, Callback);
			result.ShouldBe(expectedOutput);
		}

		Callback.WasCalled.ShouldBe(wasCallbackInvoked);
	}

	protected async Task VerifyAsync(Func<Task<Result>, Callback, Task<Result>> asyncMethod, Result input, Result? expectedOutput, bool wasCallbackInvoked)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(Task.FromResult(input), Callback);
			await accessor.ShouldThrowAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(Task.FromResult(input), Callback);
			result.ShouldBe(expectedOutput);
		}

		Callback.WasCalled.ShouldBe(wasCallbackInvoked);
	}

	protected async Task VerifyAsync<T1, T2>(Func<Task<Result<T1>>, Callback, Task<Result<T2>>> asyncMethod, Result<T1> input, Result<T2>? expectedOutput, bool wasCallbackInvoked)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(Task.FromResult(input), Callback);
			await accessor.ShouldThrowAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(Task.FromResult(input), Callback);
			result.ShouldBe(expectedOutput);
		}

		Callback.WasCalled.ShouldBe(wasCallbackInvoked);
	}

	protected async Task VerifyAsync<T1, T2>(Func<Result<T1>, Callback, Task<Result<T2>>> asyncMethod, Result<T1> input, Result<T2>? expectedOutput, bool wasCallbackInvoked)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(input, Callback);
			await accessor.ShouldThrowAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(input, Callback);
			result.ShouldBe(expectedOutput);
		}

		Callback.WasCalled.ShouldBe(wasCallbackInvoked);
	}
}
