﻿namespace RailwayResult.FunctionalExtensions.Tests.EnsureTests;

public sealed class TheoryData_R2_EnsureNotNull : TheoryData<Func<R2N, R2>, R2N, R2>
{
	public TheoryData_R2_EnsureNotNull()
	{
		//ensure should pass
		Add(
			result => result.EnsureNotNull((a, _) => a, Errors.ErrorA)!,
			(O.Empty, null),
			(O.Empty, null)!
		);

		//ensure should pass
		Add(
			result => result.EnsureNotNull((_, b) => b, Errors.ErrorA)!,
			(null, O.Empty),
			(null, O.Empty)!
		);

		//ensure should fail
		Add(
			result => result.EnsureNotNull((a, _) => a, Errors.ErrorA)!,
			(null, O.Empty),
			Errors.ErrorA
		);

		//ensure should fail
		Add(
			result => result.EnsureNotNull((_, b) => b, Errors.ErrorA)!,
			(O.Empty, null),
			Errors.ErrorA
		);

		//ensure should return input failure result
		Add(
			result => result.EnsureNotNull((a, _) => a, Errors.ErrorA)!,
			Errors.ErrorD,
			Errors.ErrorD
		);

		//ensure should return input failure result
		Add(
			result => result.EnsureNotNull((_, b) => b, Errors.ErrorA)!,
			Errors.ErrorD,
			Errors.ErrorD
		);

		//ensure should pass
		Add(
			result => result.EnsureSecondNotNull(Errors.ErrorA)!,
			(null, O.Empty),
			(null, O.Empty)!
		);

		//ensure should fail
		Add(
			result => result.EnsureSecondNotNull(Errors.ErrorA)!,
			(O.Empty, null),
			Errors.ErrorA
		);

		//ensure should return input failure result
		Add(
			result => result.EnsureSecondNotNull(Errors.ErrorA)!,
			Errors.ErrorD,
			Errors.ErrorD
		);
	}
}
