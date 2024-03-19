﻿namespace RailwayResult.FunctionalExtensions.Tests.EnsureTests;

public sealed class TheoryData_R1_Ensure : TheoryData<Func<R1, R1>, R1, R1>
{
	public TheoryData_R1_Ensure()
	{
		//ensure should pass
		Add(
			result => result.Ensure(Rules.IsNullOrWhiteSpaceRule, Errors.ErrorA),
			string.Empty,
			string.Empty
		);

		//ensure should fail
		Add(
			result => result.Ensure(s => !Rules.IsNullOrWhiteSpaceRule(s), Errors.ErrorA),
			string.Empty,
			Errors.ErrorA
		);

		//ensure should return input failure result
		Add(
			result => result.Ensure(Rules.IsNullOrWhiteSpaceRule, Errors.ErrorA),
			Errors.ErrorD,
			Errors.ErrorD
		);

		//all rules should pass
		Add(
			result => result.Ensure(Rules.IsEmpty, Rules.IsNullOrWhiteSpace, Rules.CountIs(0)),
			string.Empty,
			string.Empty
		);

		//last rule should fail
		Add(
			result => result.Ensure(Rules.IsEmpty, Rules.IsNullOrWhiteSpace, Rules.CountIs(1)),
			string.Empty,
			Rules.CountIs(1).Error
		);

		//ensure should return input failure result before any rule check
		Add(
			result => result.Ensure(Rules.IsEmpty, Rules.IsNullOrWhiteSpace, Rules.CountIs(1)),
			Errors.ErrorD,
			Errors.ErrorD
		);
	}
}