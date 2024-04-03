namespace RailwayResult.FunctionalExtensions.Tests.ThenAsyncTests;

public sealed class TheoryData_R3_ThenAsync_TaskOfR : TheoryData<Func<R3, Task<Result>>, R3, Result?>
{
	public TheoryData_R3_ThenAsync_TaskOfR()
	{
		// --- R3 ThenAsync TaskOfR ---

		Add(
			result => result.ThenAsync((_, _, _) => Result.Success.ToResultTask()),
			(O.A, O.B, O.C),
			Result.Success
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _, _) => Result.Success.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _, _) => Errors.ErrorB.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ThenAsync((_, _, _) => Errors.ErrorB.ToResultTask()),
			(O.A, O.B, O.C),
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync((_, _, _) => BasicException.Throw<Task<Result>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ThenAsync((_, _, _) => BasicException.Throw<Task<Result>>()),
			(O.A, O.B, O.C),
			null
		);

		// --- TaskOfR3 ThenAsync TaskOfR ---

		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => Result.Success.ToResultTask()),
			(O.A, O.B, O.C),
			Result.Success
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => Result.Success.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => Errors.ErrorB.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => Errors.ErrorB.ToResultTask()),
			(O.A, O.B, O.C),
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => BasicException.Throw<Task<Result>>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.ToResultTask().ThenAsync((_, _, _) => BasicException.Throw<Task<Result>>()),
			(O.A, O.B, O.C),
			null
		);
	}
}
