using RailwayResult.FunctionalExtensions.Tests.Data;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.ThenTests;

public sealed class TheoryData_R1_Then_R : TheoryData<Func<R1, Result>, R1, Result?>
{
	public TheoryData_R1_Then_R()
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
