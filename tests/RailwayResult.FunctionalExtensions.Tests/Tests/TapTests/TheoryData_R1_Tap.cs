using RailwayResult.FunctionalExtensions.Tests.Data;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.TapTests;

public sealed class TheoryData_R1_Tap : TheoryData<Func<R1, Callback, R1>, R1, R1?, bool>
{
	public TheoryData_R1_Tap()
	{
		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.Tap(_ => callback.Invoke()),
			O.A,
			O.A,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.Tap(_ => callback.Invoke()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.Tap(_ => callback.ResultInvoke()),
			O.A,
			O.A,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.Tap(_ => callback.ResultInvoke()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result should be on failure railway
		Add(
			(result, callback) => result.Tap(_ => callback.ResultInvoke(Errors.ErrorD)),
			O.A,
			Errors.ErrorD,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.Tap(_ => callback.ResultInvoke(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.Tap(_ => BasicException.Throw()),
			O.A,
			null,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.Tap(_ => BasicException.Throw<Result>()),
			O.A,
			null,
			false
		);
	}
}
