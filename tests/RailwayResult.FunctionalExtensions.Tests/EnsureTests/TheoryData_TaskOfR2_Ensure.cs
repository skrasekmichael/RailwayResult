namespace RailwayResult.FunctionalExtensions.Tests.EnsureTests;

public sealed class TheoryData_TaskOfR2_Ensure : TheoryData<Func<Task<R2>, Task<R2>>, R2, R2>
{
	public TheoryData_TaskOfR2_Ensure()
	{
		//ensure should pass
		Add(
			result => result.Ensure((a, b) => a == b, Errors.ErrorA),
			(string.Empty, string.Empty),
			(string.Empty, string.Empty)
		);

		//ensure should fail
		Add(
			result => result.Ensure((a, b) => a != b, Errors.ErrorA),
			(string.Empty, string.Empty),
			Errors.ErrorA
		);

		//ensure should return input failure result
		Add(
			result => result.Ensure((a, b) => a != b, Errors.ErrorA),
			Errors.ErrorD,
			Errors.ErrorD
		);

		//all rules should pass
		Add(
			result => result.Ensure(Rules.CountIs(0, 0)),
			(string.Empty, string.Empty),
			(string.Empty, string.Empty)
		);

		//last rule should fail
		Add(
			result => result.Ensure(Rules.CountIs(0, 1)),
			(string.Empty, string.Empty),
			Rules.CountIs(0, 1).Error
		);

		//ensure should return input failure result before any rule check
		Add(
			result => result.Ensure(Rules.CountIs(0, 1)),
			Errors.ErrorD,
			Errors.ErrorD
		);
	}
}
