﻿namespace RailwayResult.FunctionalExtensions.Tests.EnsureTests;

public sealed class TheoryData_R2_Ensure : TheoryData<Func<R2, R2>, R2, R2>
{
	public TheoryData_R2_Ensure()
	{
		//ensure should pass
		Add(
			result => result.Ensure((a, b) => a == b, Errors.ErrorA),
			(O.Empty, O.Empty),
			(O.Empty, O.Empty)
		);

		//ensure should fail
		Add(
			result => result.Ensure((a, b) => a != b, Errors.ErrorA),
			(O.Empty, O.Empty),
			Errors.ErrorA
		);

		//ensure should return input failure result
		Add(
			result => result.Ensure((a, b) => a == b, Errors.ErrorA),
			Errors.ErrorD,
			Errors.ErrorD
		);

		//rule with error should pass
		Add(
			result => result.Ensure(Rules.CountIs(0, 0)),
			(O.Empty, O.Empty),
			(O.Empty, O.Empty)
		);

		//rule with error should fail
		Add(
			result => result.Ensure(Rules.CountIs(0, 1)),
			(O.Empty, O.Empty),
			Rules.CountIs(0, 1).Error
		);

		//ensure should return input failure result
		Add(
			result => result.Ensure(Rules.CountIs(0, 1)),
			Errors.ErrorD,
			Errors.ErrorD
		);
	}
}
