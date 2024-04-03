using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Extensions;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.TapAsyncTests;

public sealed class TheoryData_R1_TapAsync : TheoryData<Func<R1, Callback, Task<R1>>, R1, R1?, bool>
{
	public TheoryData_R1_TapAsync()
	{
		// --- R1 ThenAsync ---

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.TapAsync(_ => callback.InvokeAsync()),
			O.A,
			O.A,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.TapAsync(_ => callback.InvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.TapAsync(_ => callback.ResultInvokeAsync()),
			O.A,
			O.A,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.TapAsync(_ => callback.ResultInvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result should be on failure railway
		Add(
			(result, callback) => result.TapAsync(_ => callback.ResultInvokeAsync(Errors.ErrorD)),
			O.A,
			Errors.ErrorD,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.TapAsync(_ => callback.ResultInvokeAsync(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.TapAsync(_ => BasicException.Throw<Task>()),
			O.A,
			null,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.TapAsync(_ => BasicException.Throw<Task<Result>>()),
			O.A,
			null,
			false
		);

		// --- TaskOfR1 ThenAsync ---

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync(_ => callback.InvokeAsync()),
			O.A,
			O.A,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync(_ => callback.InvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync(_ => callback.ResultInvokeAsync()),
			O.A,
			O.A,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync(_ => callback.ResultInvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result should be on failure railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync(_ => callback.ResultInvokeAsync(Errors.ErrorD)),
			O.A,
			Errors.ErrorD,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync(_ => callback.ResultInvokeAsync(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.ToResultTask().TapAsync(_ => BasicException.Throw<Task>()),
			O.A,
			null,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.ToResultTask().TapAsync(_ => BasicException.Throw<Task<Result>>()),
			O.A,
			null,
			false
		);
	}
}
