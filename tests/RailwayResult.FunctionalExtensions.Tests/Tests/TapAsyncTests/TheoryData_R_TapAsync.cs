﻿using RailwayResult.FunctionalExtensions.Tests.Data;
using RailwayResult.FunctionalExtensions.Tests.Extensions;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.TapAsyncTests;

public sealed class TheoryData_R_TapAsync : TheoryData<Func<Result, Callback, Task<Result>>, Result, Result?, bool>
{
	public TheoryData_R_TapAsync()
	{
		AddData_R_TapAsync();
		AddData_TaskOfR_TapAsync();
	}

	private void AddData_R_TapAsync()
	{
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

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.TapAsync(() => BasicException.Throw<Task>()),
			Result.Success,
			null,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.TapAsync(() => BasicException.Throw<Task<Result>>()),
			Result.Success,
			null,
			false
		);
	}

	private void AddData_TaskOfR_TapAsync()
	{
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

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.ToResultTask().TapAsync(() => BasicException.Throw<Task>()),
			Result.Success,
			null,
			false
		);

		//tap should propagate exception and callback should not be invoked
		Add(
			(result, _) => result.ToResultTask().TapAsync(() => BasicException.Throw<Task<Result>>()),
			Result.Success,
			null,
			false
		);
	}

}
