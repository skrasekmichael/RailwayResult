namespace RailwayResult.FunctionalExtensions.Tests.Data;

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

	public void InvokeError<TError>(TError error) where TError : Error
	{
		_ = error;
		WasCalled = true;
	}

	public Task InvokeErrorAsync<TError>(TError error) where TError : Error
	{
		_ = error;
		WasCalled = true;
		return Task.CompletedTask;
	}

	public Action<TError> GetTypedCallback<TError>(Action<TError> callback) where TError : Error
	{
		WasCalled = true;
		return callback;
	}

	public Func<TError, Task> GetTypedAsyncCallback<TError>(Func<TError, Task> callbackAsync) where TError : Error
	{
		WasCalled = true;
		return callbackAsync;
	}
}
