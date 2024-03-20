namespace RailwayResult.FunctionalExtensions.Tests.TapTests;

public sealed class TheoryData_TaskOfR1_Tap : TheoryData<Func<Task<R1>, Callback, Task<R1>>, R1, R1, bool>
{
	public TheoryData_TaskOfR1_Tap()
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
	}
}
