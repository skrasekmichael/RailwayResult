using RailwayResult.FunctionalExtensions.Tests.Data;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.OnErrorTests;

public sealed class TheoryData_TaskOfR_OnError : TheoryData<Func<Task<Result>, Callback, Task<Result>>, Result, Result?, bool>
{
	public TheoryData_TaskOfR_OnError()
	{
		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.OnError<Error>(callback.Invoke),
			Result.Success,
			Result.Success,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<Error>(callback.Invoke),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<BasicError>(callback.Invoke),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.OnError<Error>(() => callback.ResultInvoke()),
			Result.Success,
			Result.Success,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<Error>(() => callback.ResultInvoke()),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should not be invoked and result should stay on success railway
		Add(
			(result, callback) => result.OnError<Error>(() => callback.ResultInvoke(Errors.ErrorD)),
			Result.Success,
			Result.Success,
			false
		);

		//callback should be invoked and result stays on original failure railway
		Add(
			(result, callback) => result.OnError<Error>(() => callback.ResultInvoke(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//exception should be propagate and callback should not be invoked
		Add(
			(result, _) => result.OnError<Error>(() => BasicException.Throw()),
			Errors.ErrorA,
			null,
			false
		);

		//exception should be propagate and callback should not be invoked
		Add(
			(result, _) => result.OnError<Error>(() => BasicException.Throw<Result>()),
			Errors.ErrorA,
			null,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<Error>(callback.InvokeError),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<BasicError>(callback.InvokeError),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<GenericError<int>>(callback.InvokeError),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<BasicError>(callback.InvokeError),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);

		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.OnError<Error>(callback.InvokeError),
			Result.Success,
			Result.Success,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError(callback.GetTypedCallback((BasicError err) => _ = err)),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);
	}
}
