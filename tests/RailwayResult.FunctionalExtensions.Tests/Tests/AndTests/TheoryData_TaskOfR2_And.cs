using RailwayResult.FunctionalExtensions.Tests.Data;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.AndTests;

public sealed class TheoryData_TaskOfR2_And : TheoryData<Func<Task<R2>, Task<R3>>, R2, R3?>
{
	public TheoryData_TaskOfR2_And()
	{
		//nested result should be unwrapped
		Add(
			result => result.And((_, _) => R1.Success(O.C)),
			(O.A, O.B),
			(O.A, O.B, O.C)
		);

		//and should return input failure result
		Add(
			result => result.And((_, _) => R1.Success(O.C)),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should return error from nested result
		Add(
			result => result.And<O, O, O>((_, _) => Errors.ErrorB),
			(O.A, O.B),
			Errors.ErrorB
		);

		//and should return input failure result
		Add(
			result => result.And<O, O, O>((_, _) => BasicException.Throw<O>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should propagate exception
		Add(
			result => result.And<O, O, O>((_, _) => BasicException.Throw<O>()),
			(O.A, O.B),
			null
		);

		//and should return input failure result
		Add(
			result => result.And((_, _) => BasicException.Throw<R1>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//and should propagate exception
		Add(
			result => result.And((_, _) => BasicException.Throw<R1>()),
			(O.A, O.B),
			null
		);
	}
}
