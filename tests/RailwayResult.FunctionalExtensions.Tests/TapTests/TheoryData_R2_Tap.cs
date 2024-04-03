namespace RailwayResult.FunctionalExtensions.Tests.TapTests;

public sealed class TheoryData_R2_Tap : TheoryData<Func<R2, Callback, R2>, R2, R2?, bool>
{
	public TheoryData_R2_Tap()
	{
		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.Tap((_, _) => callback.Invoke()),
			(O.A, O.B),
			(O.A, O.B),
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.Tap((_, _) => callback.Invoke()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.Tap((_, _) => callback.ResultInvoke()),
			(O.A, O.B),
			(O.A, O.B),
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.Tap((_, _) => callback.ResultInvoke()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result should be on failure railway
		Add(
			(result, callback) => result.Tap((_, _) => callback.ResultInvoke(Errors.ErrorD)),
			(O.A, O.B),
			Errors.ErrorD,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.Tap((_, _) => callback.ResultInvoke(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.Tap((_, _) => BasicException.Throw()),
			(O.A, O.B),
			null,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.Tap((_, _) => BasicException.Throw<Result>()),
			(O.A, O.B),
			null,
			false
		);
	}
}
