﻿namespace RailwayResult.FunctionalExtensions.Tests.ThenAsyncTests;

public sealed class TheoryData_R2_ThenAsync_TaskOfRC : TheoryData<Func<R2, Task<RC>>, R2, RC>
{
	public TheoryData_R2_ThenAsync_TaskOfRC()
	{
		// --- R2 ThenAsync TaskOfRC ---

		Add(
			result => result.ThenAsync((a, b) => Task.FromResult(a.Value + b.Value))!,
			(O.A, O.B),
			"AB"
		);

		Add(
			result => result.ThenAsync((_, _) => Task.FromResult("CC"))!,
			(O.A, O.B),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _) => Task.FromResult("CC"))!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.ThenAsync((a, b) => RC.Success(a.Value + b.Value).ToResultTask())!,
			(O.A, O.B),
			"AB"
		);

		Add(
			result => result.ThenAsync((_, _) => RC.Success("CC").ToResultTask())!,
			(O.A, O.B),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _) => RC.Success("CC").ToResultTask())!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _) => Errors.ErrorC.ToResultTask<string?, BasicError>())!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ThenAsync((_, _) => Errors.ErrorC.ToResultTask<string?, BasicError>())!,
			(O.A, O.B),
			Errors.ErrorC
		);

		// --- TaskOfR2 ThenAsync TaskOfRC ---

		Add(
			result => result.ToResultTask().ThenAsync((a, b) => Task.FromResult(a.Value + b.Value))!,
			(O.A, O.B),
			"AB"
		);

		Add(
			result => result.ToResultTask().ThenAsync((_, _) => Task.FromResult("CC"))!,
			(O.A, O.B),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => Task.FromResult("CC"))!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.ToResultTask().ThenAsync((a, b) => RC.Success(a.Value + b.Value).ToResultTask())!,
			(O.A, O.B),
			"AB"
		);

		Add(
			result => result.ToResultTask().ThenAsync((_, _) => RC.Success("CC").ToResultTask())!,
			(O.A, O.B),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => RC.Success("CC").ToResultTask())!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => Errors.ErrorC.ToResultTask<string?, BasicError>())!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _) => Errors.ErrorC.ToResultTask<string?, BasicError>())!,
			(O.A, O.B),
			Errors.ErrorC
		);
	}
}
