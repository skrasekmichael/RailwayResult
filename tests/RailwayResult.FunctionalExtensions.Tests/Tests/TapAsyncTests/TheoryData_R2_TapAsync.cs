using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Extensions;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.TapAsyncTests;

public sealed class TheoryData_R2_TapAsync : TheoryData<Func<R2, Callback, Task<R2>>, R2, R2?, bool>
{
	public TheoryData_R2_TapAsync()
	{
		// --- R2 TapAsync ---

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.TapAsync((_, _) => callback.InvokeAsync()),
			(O.A, O.B),
			(O.A, O.B),
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.TapAsync((_, _) => callback.InvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.TapAsync((_, _) => callback.ResultInvokeAsync()),
			(O.A, O.B),
			(O.A, O.B),
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.TapAsync((_, _) => callback.ResultInvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result should be on failure railway
		Add(
			(result, callback) => result.TapAsync((_, _) => callback.ResultInvokeAsync(Errors.ErrorD)),
			(O.A, O.B),
			Errors.ErrorD,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.TapAsync((_, _) => callback.ResultInvokeAsync(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.TapAsync((_, _) => BasicException.Throw<Task>()),
			(O.A, O.B),
			null,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.TapAsync((_, _) => BasicException.Throw<Task<Result>>()),
			(O.A, O.B),
			null,
			false
		);

		// --- TaskOfR2 TapAsync ---

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync((_, _) => callback.InvokeAsync()),
			(O.A, O.B),
			(O.A, O.B),
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync((_, _) => callback.InvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result stays on success railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync((_, _) => callback.ResultInvokeAsync()),
			(O.A, O.B),
			(O.A, O.B),
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync((_, _) => callback.ResultInvokeAsync()),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//callback should be invoked and result should be on failure railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync((_, _) => callback.ResultInvokeAsync(Errors.ErrorD)),
			(O.A, O.B),
			Errors.ErrorD,
			true
		);

		//callback should not be invoked and result stays on failure railway
		Add(
			(result, callback) => result.ToResultTask().TapAsync((_, _) => callback.ResultInvokeAsync(Errors.ErrorD)),
			Errors.ErrorA,
			Errors.ErrorA,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.ToResultTask().TapAsync((_, _) => BasicException.Throw<Task>()),
			(O.A, O.B),
			null,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.ToResultTask().TapAsync((_, _) => BasicException.Throw<Task<Result>>()),
			(O.A, O.B),
			null,
			false
		);
	}
}
