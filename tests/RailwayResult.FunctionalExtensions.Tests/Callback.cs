namespace RailwayResult.FunctionalExtensions.Tests;

public sealed class Callback
{
	public bool WasCalled { get; private set; } = false;

	public void Invoke() => WasCalled = true;

	public Result ResultInvoke(BasicError? error = null)
	{
		WasCalled = true;
		return error is null ? Result.Success : error;
	}

	public Task InvokeAsync()
	{
		WasCalled = true;
		return Task.CompletedTask;
	}

	public Task<Result> ResultInvokeAsync(BasicError? error = null)
	{
		WasCalled = true;
		return Task.FromResult(error is null ? Result.Success : error);
	}

}
