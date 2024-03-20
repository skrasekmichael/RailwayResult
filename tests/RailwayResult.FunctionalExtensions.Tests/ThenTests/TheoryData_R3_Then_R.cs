namespace RailwayResult.FunctionalExtensions.Tests.ThenTests;

public sealed class TheoryData_R3_Then_R : TheoryData<Func<R3, Result>, R3, Result>
{
	public TheoryData_R3_Then_R()
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
	}
}
