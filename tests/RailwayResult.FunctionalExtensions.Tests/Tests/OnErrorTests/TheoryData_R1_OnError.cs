using RailwayResult.FunctionalExtensions.Tests.Data;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.OnErrorTests;

public sealed class TheoryData_R1_OnError : TheoryData<Func<R1, Callback, R1>, R1, R1?, bool>
{
	public TheoryData_R1_OnError()
	{
		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.OnError<Obj, Error>(callback.Invoke),
			O.A,
			O.A,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<Obj, Error>(callback.Invoke),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<Obj, BasicError>(callback.Invoke),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.OnError<Obj, Error>(() => callback.ResultInvoke()),
			O.B,
			O.B,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<Obj, Error>(() => callback.ResultInvoke()),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should not be invoked and result should stay on success railway
		Add(
			(result, callback) => result.OnError<Obj, Error>(() => callback.ResultInvoke(Errors.ErrorD)),
			O.A,
			O.A,
			false
		);

		//callback should be invoked and result stays on original failure railway
		Add(
			(result, callback) => result.OnError<Obj, Error>(() => callback.ResultInvoke(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//exception should be propagate and callback should not be invoked
		Add(
			(result, _) => result.OnError<Obj, Error>(() => BasicException.Throw()),
			Errors.ErrorA,
			null,
			false
		);

		//exception should be propagate and callback should not be invoked
		Add(
			(result, _) => result.OnError<Obj, Error>(() => BasicException.Throw<Result>()),
			Errors.ErrorA,
			null,
			false
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<Obj, Error>(callback.InvokeError),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<Obj, BasicError>(callback.InvokeError),
			Errors.ErrorA,
			Errors.ErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<Obj, GenericError<int>>(callback.InvokeError),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);

		//callback should be invoked and result stays on failure railway
		Add(
			(result, callback) => result.OnError<Obj, BasicError>(callback.InvokeError),
			GenericError<int>.GenericErrorA,
			GenericError<int>.GenericErrorA,
			true
		);

		//callback should not be invoked and result stays on success railway
		Add(
			(result, callback) => result.OnError<Obj, Error>(callback.InvokeError),
			O.A,
			O.A,
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
