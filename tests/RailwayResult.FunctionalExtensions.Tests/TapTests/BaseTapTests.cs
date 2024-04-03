namespace RailwayResult.FunctionalExtensions.Tests.TapTests;

public abstract class BaseTapTests
{
	protected Callback Callback { get; } = new();

	protected void Verify(Func<Result, Callback, Result> method, Result input, Result? expectedOutput, bool wasCallbackCalled)
	{
		if (expectedOutput is null)
		{
			var accessor = () => method.Invoke(input, Callback);
			accessor.Should().ThrowExactly<BasicException>();
		}
		else
		{
			method.Invoke(input, Callback).ShouldBe(expectedOutput);
		}
	}

	protected void Verify<T1, T2>(Func<T1, Callback, Result<T2>> method, T1 input, Result<T2>? expectedOutput, bool wasCallbackCalled)
	{
		if (expectedOutput is null)
		{
			var accessor = () => method.Invoke(input, Callback);
			accessor.Should().ThrowExactly<BasicException>();
		}
		else
		{
			method.Invoke(input, Callback).ShouldBe(expectedOutput);
		}
	}

	protected void Verify<T1, T2>(Func<Result<T1>, Callback, Result<T2>> method, Result<T1> input, Result<T2>? expectedOutput, bool wasCallbackCalled)
	{
		if (expectedOutput is null)
		{
			var accessor = () => method.Invoke(input, Callback);
			accessor.Should().ThrowExactly<BasicException>();
		}
		else
		{
			method.Invoke(input, Callback).ShouldBe(expectedOutput);
		}
	}

	protected async Task VerifyAsync(Func<Task<Result>, Callback, Task<Result>> asyncMethod, Result input, Result? expectedOutput, bool wasCallbackCalled)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(Task.FromResult(input), Callback);
			await accessor.Should().ThrowExactlyAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(Task.FromResult(input), Callback);
			result.ShouldBe(expectedOutput);
		}
	}

	protected async Task VerifyAsync<T1, T2>(Func<Task<T1>, Callback, Task<Result<T2>>> asyncMethod, T1 input, Result<T2>? expectedOutput, bool wasCallbackCalled)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(Task.FromResult(input), Callback);
			await accessor.Should().ThrowExactlyAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(Task.FromResult(input), Callback);
			result.ShouldBe(expectedOutput);
		}
	}

	protected async Task VerifyAsync<T1, T2>(Func<Task<Result<T1>>, Callback, Task<Result<T2>>> asyncMethod, Result<T1> input, Result<T2>? expectedOutput, bool wasCallbackCalled)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(Task.FromResult(input), Callback);
			await accessor.Should().ThrowExactlyAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(Task.FromResult(input), Callback);
			result.ShouldBe(expectedOutput);
		}
	}

	protected async Task VerifyAsync<T>(Func<Result<T>, Callback, Task<Result>> asyncMethod, Result<T> input, Result? expectedOutput, bool wasCallbackCalled)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(input, Callback);
			await accessor.Should().ThrowExactlyAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(input, Callback);
			result.ShouldBe(expectedOutput);
		}
	}

	protected async Task VerifyAsync<T1, T2>(Func<Result<T1>, Callback, Task<Result<T2>>> asyncMethod, Result<T1> input, Result<T2>? expectedOutput, bool wasCallbackCalled)
	{
		if (expectedOutput is null)
		{
			var accessor = async () => await asyncMethod.Invoke(input, Callback);
			await accessor.Should().ThrowExactlyAsync<BasicException>();
		}
		else
		{
			var result = await asyncMethod.Invoke(input, Callback);
			result.ShouldBe(expectedOutput);
		}
	}
}
