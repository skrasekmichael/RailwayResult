using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Extensions;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.OnErrorAsyncTests;

public sealed class TheoryData_R1_OnErrorAsync : TheoryData<Func<R1, Callback, Task<R1>>, R1, R1?, bool>
{
	public TheoryData_R1_OnErrorAsync()
	{
		AddData_R1_OnErrorAsync();
		AddData_TaskOfR1_OnErrorAsync();
	}

	private void AddData_R1_OnErrorAsync()
	{
		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.OnErrorAsync<O, Error>(callback.InvokeAsync),
			O.A,
			O.A,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<O, Error>(callback.InvokeAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<O, BasicError>(callback.InvokeAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.OnErrorAsync<O, Error>(() => callback.ResultInvokeAsync()),
			O.B,
			O.B,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<O, Error>(() => callback.ResultInvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should not be invoked and result should stay on success railway
		Add(
			(result, callback) => result.OnErrorAsync<O, Error>(() => callback.ResultInvokeAsync(Errors.ErrorD)),
			O.A,
			O.A,
			false
		);

		//callback should be invoked and result stays on original failure railway
		Add(
			(result, callback) => result.OnErrorAsync<O, Error>(() => callback.ResultInvokeAsync(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//exception should be propagate and callback should not be invoked
		Add(
			(result, _) => result.OnErrorAsync<O, Error>(() => BasicException.Throw<Task>()),
			Errors.ErrorA,
			null,
			false
		);

		//exception should be propagate and callback should not be invoked
		Add(
			(result, _) => result.OnErrorAsync<O, Error>(() => BasicException.Throw<Task<Result>>()),
			Errors.ErrorA,
			null,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<O, Error>(callback.InvokeErrorAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<O, BasicError>(callback.InvokeErrorAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<O, GenericError<int>>(callback.InvokeErrorAsync),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnErrorAsync<O, BasicError>(callback.InvokeErrorAsync),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);

		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.OnErrorAsync<O, Error>(callback.InvokeErrorAsync),
			O.A,
			O.A,
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

	private void AddData_TaskOfR1_OnErrorAsync()
	{
		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<O, Error>(callback.InvokeAsync),
			O.A,
			O.A,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<O, Error>(callback.InvokeAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<O, BasicError>(callback.InvokeAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<O, Error>(() => callback.ResultInvokeAsync()),
			O.B,
			O.B,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<O, Error>(() => callback.ResultInvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should not be invoked and result should stay on success railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<O, Error>(() => callback.ResultInvokeAsync(Errors.ErrorD)),
			O.A,
			O.A,
			false
		);

		//callback should be invoked and result stays on original failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<O, Error>(() => callback.ResultInvokeAsync(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//exception should be propagate and callback should not be invoked
		Add(
			(result, _) => result.ToResultTask().OnErrorAsync<O, Error>(() => BasicException.Throw<Task>()),
			Errors.ErrorA,
			null,
			false
		);

		//exception should be propagate and callback should not be invoked
		Add(
			(result, _) => result.ToResultTask().OnErrorAsync<O, Error>(() => BasicException.Throw<Task<Result>>()),
			Errors.ErrorA,
			null,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<O, Error>(callback.InvokeErrorAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<O, BasicError>(callback.InvokeErrorAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<O, GenericError<int>>(callback.InvokeErrorAsync),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<O, BasicError>(callback.InvokeErrorAsync),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);

		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.ToResultTask().OnErrorAsync<O, Error>(callback.InvokeErrorAsync),
			O.A,
			O.A,
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
