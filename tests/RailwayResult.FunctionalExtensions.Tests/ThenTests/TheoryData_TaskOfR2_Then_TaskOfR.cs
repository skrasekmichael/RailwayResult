namespace RailwayResult.FunctionalExtensions.Tests.ThenTests;

public sealed class TheoryData_TaskOfR2_Then_TaskOfR : TheoryData<Func<Task<R2>, Task<Result>>, R2, Result?>
{
	public TheoryData_TaskOfR2_Then_TaskOfR()
	{
		Add(
			result => result.Then((_, _) => Result.Success),
			(O.A, O.B),
			Result.Success
		);

		//then should return input failure result
		Add(
			result => result.Then((_, _) => Result.Success),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.Then<O, O>((_, _) => Errors.ErrorB),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.Then<O, O>((_, _) => Errors.ErrorB),
			(O.A, O.B),
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.Then((_, _) => BasicException.Throw<Result>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.Then((_, _) => BasicException.Throw<Result>()),
			(O.A, O.B),
			null
		);
	}
}
