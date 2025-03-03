using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Extensions;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.OnErrorAsyncTests;

public sealed class TheoryData_R_OnErrorAsync : TheoryData<Func<Result, Callback, Task<Result>>, Result, Result?, bool>
{
	public TheoryData_R_OnErrorAsync()
	{
		AddData_R_OnErrorAsync();
		AddData_TaskOfR_OnErrorAsync();
	}

	private void AddData_R_OnErrorAsync()
	{
		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.OnErrorAsync<Error>(callback.InvokeAsync),
			Result.Success,
			Result.Success,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<Error>(callback.InvokeAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<BasicError>(callback.InvokeAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.OnErrorAsync<Error>(() => callback.ResultInvokeAsync()),
			Result.Success,
			Result.Success,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<Error>(() => callback.ResultInvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should not be invoked and result should stay on success railway
		Add(
			(result, callback) => result.OnErrorAsync<Error>(() => callback.ResultInvokeAsync(Errors.ErrorD)),
			Result.Success,
			Result.Success,
			false
		);

		//callback should be invoked and result stays on original failure railway
		Add(
			(result, callback) => result.OnErrorAsync<Error>(() => callback.ResultInvokeAsync(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//exception should be propagate and callback should not be invoked
		Add(
			(result, _) => result.OnErrorAsync<Error>(() => BasicException.Throw<Task>()),
			Errors.ErrorA,
			null,
			false
		);

		//exception should be propagate and callback should not be invoked
		Add(
			(result, _) => result.OnErrorAsync<Error>(() => BasicException.Throw<Task<Result>>()),
			Errors.ErrorA,
			null,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<Error>(callback.InvokeErrorAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<BasicError>(callback.InvokeErrorAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<GenericError<int>>(callback.InvokeErrorAsync),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<BasicError>(callback.InvokeErrorAsync),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);

		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.OnErrorAsync<Error>(callback.InvokeErrorAsync),
			Result.Success,
			Result.Success,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync(callback.GetTypedAsyncCallback((BasicError err) => Task.CompletedTask)),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);
	}

	private void AddData_TaskOfR_OnErrorAsync()
	{
		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<Error>(callback.InvokeAsync),
			Result.Success,
			Result.Success,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<Error>(callback.InvokeAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<BasicError>(callback.InvokeAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<Error>(() => callback.ResultInvokeAsync()),
			Result.Success,
			Result.Success,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<Error>(() => callback.ResultInvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should not be invoked and result should stay on success railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<Error>(() => callback.ResultInvokeAsync(Errors.ErrorD)),
			Result.Success,
			Result.Success,
			false
		);

		//callback should be invoked and result stays on original failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<Error>(() => callback.ResultInvokeAsync(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//exception should be propagate and callback should not be invoked
		Add(
			(result, _) => result.ToResultTask().OnErrorAsync<Error>(() => BasicException.Throw<Task>()),
			Errors.ErrorA,
			null,
			false
		);

		//exception should be propagate and callback should not be invoked
		Add(
			(result, _) => result.ToResultTask().OnErrorAsync<Error>(() => BasicException.Throw<Task<Result>>()),
			Errors.ErrorA,
			null,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<Error>(callback.InvokeErrorAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<BasicError>(callback.InvokeErrorAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<GenericError<int>>(callback.InvokeErrorAsync),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<BasicError>(callback.InvokeErrorAsync),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);

		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<Error>(callback.InvokeErrorAsync),
			Result.Success,
			Result.Success,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync(callback.GetTypedAsyncCallback((BasicError err) => Task.CompletedTask)),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);
	}
}
