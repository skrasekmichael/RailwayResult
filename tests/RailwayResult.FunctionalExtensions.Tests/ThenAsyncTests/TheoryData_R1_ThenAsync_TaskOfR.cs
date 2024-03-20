namespace RailwayResult.FunctionalExtensions.Tests.ThenAsyncTests;

public sealed class TheoryData_R1_ThenAsync_TaskOfR : TheoryData<Func<R1, Task<Result>>, R1, Result>
{
	public TheoryData_R1_ThenAsync_TaskOfR()
	{
		// --- R1 ThenAsync TaskOfR ---

		Add(
			result => result.ThenAsync(_ => Result.Success.ToResultTask()),
			O.A,
			Result.Success
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync(_ => Result.Success.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ThenAsync(_ => Errors.ErrorB.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ThenAsync(_ => Errors.ErrorB.ToResultTask()),
			O.A,
			Errors.ErrorB
		);

		// --- TaskOfR1 ThenAsync TaskOfR ---

		Add(
			result => result.ToResultTask().ThenAsync(_ => Result.Success.ToResultTask()),
			O.A,
			Result.Success
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync(_ => Result.Success.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.ToResultTask().ThenAsync(_ => Errors.ErrorB.ToResultTask()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.ToResultTask().ThenAsync(_ => Errors.ErrorB.ToResultTask()),
			O.A,
			Errors.ErrorB
		);
	}
}
