﻿namespace RailwayResult.FunctionalExtensions.Tests.TapTests;

public sealed class TheoryData_TaskOfR_Tap : TheoryData<Func<Task<Result>, Callback, Task<Result>>, Result, Result, bool>
{
	public TheoryData_TaskOfR_Tap()
	{
		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.Tap(callback.Invoke),
			Result.Success,
			Result.Success,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.Tap(callback.Invoke),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.Tap(() => callback.ResultInvoke()),
			Result.Success,
			Result.Success,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.Tap(() => callback.ResultInvoke()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result should be on failure railway
		Add(
			(result, callback) => result.Tap(() => callback.ResultInvoke(Errors.ErrorD)),
			Result.Success,
			Errors.ErrorD,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.Tap(() => callback.ResultInvoke(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);
	}
}
