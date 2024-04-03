namespace RailwayResult.FunctionalExtensions.Tests.ThenTests;

public sealed class TheoryData_TaskOfR1_Then_TaskOfR : TheoryData<Func<Task<R1>, Task<Result>>, R1, Result?>
{
	public TheoryData_TaskOfR1_Then_TaskOfR()
	{
		Add(
			result => result.Then(_ => Result.Success),
			O.A,
			Result.Success
		);

		//then should return input failure result
		Add(
			result => result.Then(_ => Result.Success),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.Then<O>(_ => Errors.ErrorB),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.Then<O>(_ => Errors.ErrorB),
			O.A,
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.Then(_ => BasicException.Throw<Result>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.Then(_ => BasicException.Throw<Result>()),
			O.A,
			null
		);
	}
}
