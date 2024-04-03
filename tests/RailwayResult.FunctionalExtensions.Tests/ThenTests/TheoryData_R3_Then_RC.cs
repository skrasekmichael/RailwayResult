namespace RailwayResult.FunctionalExtensions.Tests.ThenTests;

public sealed class TheoryData_R3_Then_RC : TheoryData<Func<R3, RC>, R3, RC?>
{
	public TheoryData_R3_Then_RC()
	{
		Add(
			result => result.Then((a, b, c) => a.Value + b.Value + c.Value)!,
			(O.A, O.B, O.C),
			"ABC"
		);

		Add(
			result => result.Then((_, _, _) => "CC")!,
			(O.A, O.B, O.C),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.Then((_, _, _) => "CC")!,
			Errors.ErrorA,
			Errors.ErrorA
		);

		Add(
			result => result.Then((a, b, c) => RC.Success(a.Value + b.Value + c.Value)),
			(O.A, O.B, O.C),
			"ABC"
		);

		Add(
			result => result.Then((_, _, _) => RC.Success("CC")),
			(O.A, O.B, O.C),
			"CC"
		);

		//then should return input failure result
		Add(
			result => result.Then((_, _, _) => RC.Success("CC")),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return nested failure result
		Add(
			result => result.Then<O, O, O, string?>((_, _, _) => Errors.ErrorB),
			(O.A, O.B, O.C),
			Errors.ErrorB
		);

		//then should return input failure result
		Add(
			result => result.Then<O, O, O, string?>((_, _, _) => Errors.ErrorB),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should return input failure result
		Add(
			result => result.Then((_, _, _) => BasicException.Throw<string?>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.Then((_, _, _) => BasicException.Throw<string?>()),
			(O.A, O.B, O.C),
			null
		);

		//then should return input failure result
		Add(
			result => result.Then((_, _, _) => BasicException.Throw<RC>()),
			Errors.ErrorA,
			Errors.ErrorA
		);

		//then should propagate exception
		Add(
			result => result.Then((_, _, _) => BasicException.Throw<RC>()),
			(O.A, O.B, O.C),
			null
		);
	}
}
