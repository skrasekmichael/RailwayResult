﻿using RailwayResult.FunctionalExtensions.Tests.Data;

namespace RailwayResult.FunctionalExtensions.Tests.Tests.ThenTests;

public sealed class TheoryData_R2_Then_RC : TheoryData<Func<R2, RC>, R2, RC?>
{
	public TheoryData_R2_Then_RC()
	{
		Add(
			result => result.Then((a, b) => a.Value + b.Value)!,
			(O.A, O.B),
			"AB"
		);

		Add(
			result => result.Then((_, _) => "CC")!,
			(O.A, O.B),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.Then((_, _) => "CC")!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.Then((a, b) => RC.Success(a.Value + b.Value))!,
			(O.A, O.B),
			"AB"
		);

		Add(
			result => result.Then((_, _) => RC.Success("CC"))!,
			(O.A, O.B),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.Then((_, _) => RC.Success("CC"))!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.Then<O, O, string?>((_, _) => Errors.ErrorC)!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.Then<O, O, string?>((_, _) => Errors.ErrorC)!,
			(O.A, O.B),
			Errors.ErrorC
		);

		//then should return input failure result
		Add(
			result => result.Then((_, _) => BasicException.Throw<string?>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.Then((_, _) => BasicException.Throw<string?>()),
			(O.A, O.B),
			null
		);

		//then should return input failure result
		Add(
			result => result.Then((_, _) => BasicException.Throw<RC>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.Then((_, _) => BasicException.Throw<RC>()),
			(O.A, O.B),
			null
		);
	}
}
