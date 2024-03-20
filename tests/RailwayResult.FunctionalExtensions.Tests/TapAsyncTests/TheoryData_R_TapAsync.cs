namespace RailwayResult.FunctionalExtensions.Tests.TapAsyncTests;

public sealed class TheoryData_R_TapAsync : TheoryData<Func<Result, Callback, Task<Result>>, Result, Result, bool>
{
	public TheoryData_R_TapAsync()
	{
		// --- R TapAsync ---

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.TapAsync(callback.InvokeAsync),
			Result.Success,
			Result.Success,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.TapAsync(callback.InvokeAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.TapAsync(() => callback.ResultInvokeAsync()),
			Result.Success,
			Result.Success,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.TapAsync(() => callback.ResultInvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result should be on failure railway
		Add(
			(result, callback) => result.TapAsync(() => callback.ResultInvokeAsync(Errors.ErrorD)),
			Result.Success,
			Errors.ErrorD,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.TapAsync(() => callback.ResultInvokeAsync(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		// --- TaskOfR TapAsync ---

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync(callback.InvokeAsync),
			Result.Success,
			Result.Success,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync(callback.InvokeAsync),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync(() => callback.ResultInvokeAsync()),
			Result.Success,
			Result.Success,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync(() => callback.ResultInvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result should be on failure railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync(() => callback.ResultInvokeAsync(Errors.ErrorD)),
			Result.Success,
			Errors.ErrorD,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync(() => callback.ResultInvokeAsync(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);
	}
}
