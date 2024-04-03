using RailwayResult.FunctionalExtensions.Tests.Data;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.ThenTests;

public sealed class TheoryData_TaskOfR3_Then_TaskOfR : TheoryData<Func<Task<R3>, Task<Result>>, R3, Result?>
{
	public TheoryData_TaskOfR3_Then_TaskOfR()
	{
		Add(
			result => result.Then((_, _, _) => Result.Success),
			(O.A, O.B, O.C),
			Result.Success
		);

		//then should return input failure result
		Add(
			result => result.Then((_, _, _) => Result.Success),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.Then<O, O, O>((_, _, _) => Errors.ErrorB),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.Then<O, O, O>((_, _, _) => Errors.ErrorB),
			(O.A, O.B, O.C),
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.Then((_, _, _) => BasicException.Throw<Result>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.Then((_, _, _) => BasicException.Throw<Result>()),
			(O.A, O.B, O.C),
			null
		);
	}
}
